namespace AIAgent.Tools
{
    public interface IAiTool
    {
        string Name { get; }

        string Description { get; }

        object ParametersSchema { get; }

        Task<object> ExecuteAsync(string? argumentsJson = null);
    }
}
