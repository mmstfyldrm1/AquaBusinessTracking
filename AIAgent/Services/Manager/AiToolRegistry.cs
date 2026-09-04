using AIAgent.Tools;

namespace AIAgent.Services.Manager
{
    public class AiToolRegistry
    {
        private readonly Dictionary<string, IAiTool> _tools;

        public AiToolRegistry(IEnumerable<IAiTool> tools)
        {
            _tools = tools.ToDictionary(
                x => x.Name,
                StringComparer.OrdinalIgnoreCase);
        }

        public IReadOnlyCollection<IAiTool> GetAll()
        {
            return _tools.Values.ToList();
        }

        public IAiTool Get(string name)
        {
            if (!_tools.TryGetValue(name, out var tool))
            {
                throw new Exception(
                    $"AI Tool bulunamadı: {name}");
            }

            return tool;
        }
    }
}