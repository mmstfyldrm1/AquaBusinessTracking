using AIAgent.Orchestration.Abstract;
using AIAgent.Services.Manager;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AIAgent.Orchestration.Manager
{
    public class AiManager : IAiService
    {
        private readonly AiToolRegistry _toolRegistry;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AiManager(AiToolRegistry toolRegistry, IConfiguration configuration, HttpClient httpClient)
        {
            _toolRegistry = toolRegistry;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string> AskAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return "Lütfen bir soru yazın.";

            var apiKey = _configuration["Nvidia:ApiKey"];
            var model = _configuration["Nvidia:Model"];
            var maxTokens = _configuration["Nvidia:MaxTokens"];

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("NVIDIA API Key bulunamadı.");

            if (string.IsNullOrWhiteSpace(model))
                throw new Exception("NVIDIA Model bulunamadı.");

            var messages = new List<object>
            {
                new
                {
                    role = "system",
                    content =
                        "You are an AI assistant for a MES (Manufacturing Execution System). " +
                        "When answering questions about production, machines, energy, factory operations, and MES data, use the available Tools. " +
                        "IMPORTANT: Base your answer ONLY on the data returned by the Tools. " +
                        "If the Tool result is empty or contains irrelevant records, clearly state this. " +
                        "Never fabricate data, make assumptions, estimates, or predictions. " +
                        "If multiple records are returned, evaluate each record separately; unless the user explicitly requests it, do not automatically aggregate or combine the records, list them individually. " +
                        "If answering the question requires information from more than one Tool, call all the necessary Tools — " +
                        "either together in the same step if they are independent of each other, " +
                        "or one after another if the result of one Tool is needed as input for another. " +
                        "Do not stop after calling only one Tool if the user's question clearly requires additional data from other Tools. " +
                        "Always respond to the user in Turkish, regardless of the language of the system prompt, Tool results, or user query."
                },
                new
                {
                    role = "user",
                    content = message
                }
            };

            var tools = _toolRegistry
                .GetAll()
                .Select(tool => new
                {
                    type = "function",
                    function = new
                    {
                        name = tool.Name,
                        description = tool.Description,
                        parameters = tool.ParametersSchema

                    }
                })
                .ToList();

            const int maxToolCalls = 5;

            for (int i = 0; i < maxToolCalls; i++)
            {
                var response = await SendToNvidiaAsync(apiKey, maxTokens, model, messages, tools);

                Console.WriteLine("========== AI RAW RESPONSE ==========");
                Console.WriteLine(response);
                Console.WriteLine("=====================================");

                using var documents = JsonDocument.Parse(response);

                var roots = documents.RootElement;

                if (!roots.TryGetProperty("choices", out var choices))
                {
                    throw new Exception(
                        $"NVIDIA response içinde 'choices' bulunamadı.\nResponse: {response}");
                }

                if (choices.GetArrayLength() == 0)
                {
                    throw new Exception(
                        $"NVIDIA response 'choices' boş döndü.\nResponse: {response}");
                }

                var messageElements = choices[0].GetProperty("message");

                Console.WriteLine("========== AI MESSAGE ==========");
                Console.WriteLine(messageElements.GetRawText());
                Console.WriteLine("================================");



                using var document = JsonDocument.Parse(response);

                var root = document.RootElement;
                var messageElement = root.GetProperty("choices")[0].GetProperty("message");




                // Model doğrudan cevap verdiyse
                if (!messageElement.TryGetProperty("tool_calls", out var toolCalls))
                {
                    if (messageElement.TryGetProperty("content", out var content))
                    {
                        return content.GetString() ?? string.Empty;
                    }

                    return "AI'dan geçerli bir cevap alınamadı.";
                }

                // Önce AI'nın assistant mesajını conversation'a ekle
                object? contentValue = messageElement.TryGetProperty("content", out var contentEl) && contentEl.ValueKind != JsonValueKind.Null
                ? contentEl.GetString()
                : null;

                // tool_calls'ı ham JSON olarak koru (yapısı bozulmasın)
                JsonElement? toolCallsValue = messageElement.TryGetProperty("tool_calls", out var tcEl) ? tcEl : null;

                var cleanAssistantMessage = new Dictionary<string, object?>
                {
                    ["role"] = "assistant",
                };

                if (contentValue != null)
                {
                    cleanAssistantMessage["content"] = contentValue;
                }
                else
                {
                    cleanAssistantMessage["content"] = "";
                }

                if (toolCallsValue.HasValue)
                {
                    cleanAssistantMessage["tool_calls"] = JsonSerializer.Deserialize<object>(toolCallsValue.Value.GetRawText());
                }

                messages.Add(cleanAssistantMessage);

                // Modelin istediği Tool'ları çalıştır
                foreach (var toolCall in toolCalls.EnumerateArray())
                {
                    var toolCallId = toolCall.GetProperty("id").GetString();
                    var function = toolCall.GetProperty("function");
                    var toolName = function.GetProperty("name").GetString();
                    var arguments = function.GetProperty("arguments").GetString();
                    if (string.IsNullOrWhiteSpace(toolName))
                    {
                        throw new Exception(
                            "NVIDIA geçersiz Tool adı döndürdü.");
                    }

                    var tool = _toolRegistry.Get(toolName);
                    var argumentsJs = function.GetProperty("arguments").GetString();
                    var toolResult = await tool.ExecuteAsync(argumentsJs);
                    var toolResultJson = JsonSerializer.Serialize(toolResult);
                    messages.Add(new
                    {
                        role = "tool",
                        tool_call_id = toolCallId,
                        content = toolResultJson
                    });
                }
            }

            throw new Exception("AI maksimum Tool çağrısı limitine ulaştı.");

        }

        public async Task<string> SendToNvidiaAsync(string apiKey, string maxTokens, string model, List<object> messages, object tools)
        {
            var requestBody = new
            {
                model = model,
                messages = messages,
                tools = tools,
                max_tokens = int.Parse(maxTokens),
                temperature = 1,
                top_p = 0.95,
                stream = false
            };

            var jsonBody = JsonSerializer.Serialize(requestBody);

            const int maxRetries = 5;
            Exception? lastException = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, "https://integrate.api.nvidia.com/v1/chat/completions");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }

                lastException = new Exception(
                    $"NVIDIA API Hatası | StatusCode: {(int)response.StatusCode} {response.StatusCode} | Response: {responseContent}");

                if ((int)response.StatusCode >= 500 && attempt < maxRetries)
                {
                    Console.WriteLine($"NVIDIA 5xx döndü ({attempt}. deneme), tekrar deneniyor...");
                    await Task.Delay(TimeSpan.FromMilliseconds(5000 * attempt)); // 0.5s, 1s, 1.5s
                    continue;
                }

                throw lastException;
            }

            throw lastException!;
        }
    }
}

