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
                        "Sen bir MES sisteminin yapay zeka asistanısın. " +
                        "Üretim, makine, enerji ve fabrika verileri hakkında " +
                        "cevap verirken mevcut Tool'ları kullan. " +
                        "Tool sonucunda gelen verileri analiz ederek kullanıcıya " +
                        "Türkçe ve anlaşılır şekilde cevap ver."
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
                        parameters = new
                        {
                            type = "object",
                            parameters = tool.ParametersSchema
                        }
                    }
                })
                .ToList();

            const int maxToolCalls = 5;

            for (int i = 0; i < maxToolCalls; i++)
            {
                var response = await SendToNvidiaAsync(
                    apiKey,
                    maxTokens,
                    model,
                    messages,
                    tools);

                using var document = JsonDocument.Parse(response);

                var root = document.RootElement;
                var messageElement = root.GetProperty("choices")[0].GetProperty("message");

                // Model doğrudan cevap verdiyse
                if (!messageElement.TryGetProperty(
                        "tool_calls",
                        out var toolCalls))
                {
                    if (messageElement.TryGetProperty(
                            "content",
                            out var content))
                    {
                        return content.GetString() ?? string.Empty;
                    }

                    return "AI'dan geçerli bir cevap alınamadı.";
                }

                // Önce AI'nın assistant mesajını conversation'a ekle
                messages.Add(
                    JsonSerializer.Deserialize<object>(
                        messageElement.GetRawText())!
                );

                // Modelin istediği Tool'ları çalıştır
                foreach (var toolCall in toolCalls.EnumerateArray())
                {
                    var toolCallId =
                        toolCall
                            .GetProperty("id")
                            .GetString();

                    var function =
                        toolCall.GetProperty("function");

                    var toolName =
                        function
                            .GetProperty("name")
                            .GetString();

                    var arguments =
                        function
                            .GetProperty("arguments")
                            .GetString();

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

            throw new Exception(
                "AI maksimum Tool çağrısı limitine ulaştı.");
        }

        public async Task<string> SendToNvidiaAsync(string apiKey, string maxTokens, string model, List<object> messages, object tools)
        {
            var requestBody = new
            {
                model = model,
                messages = messages,
                tools = tools,
                max_tokens = decimal.Parse(maxTokens),
                temperature = 0,
                stream = false,
                chat_template_kwargs = new { thinking = false }
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://integrate.api.nvidia.com/v1/chat/completions");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            using var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"NVIDIA API Hatası | " +
                    $"StatusCode: {(int)response.StatusCode} {response.StatusCode} | " +
                    $"Reason: {response.ReasonPhrase} | " +
                    $"Response: {responseContent}");
            }

            return responseContent;
        }
    }
}

