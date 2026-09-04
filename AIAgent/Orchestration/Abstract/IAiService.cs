namespace AIAgent.Orchestration.Abstract
{
    public interface IAiService
    {
        Task<string> AskAsync(string message);

        public Task<string> SendToNvidiaAsync(string apiKey, string maxTokens, string model, List<object> messages, object tools);
    }
}
