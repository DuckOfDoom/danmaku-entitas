using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace DuckOfDoom.Danmaku
{
    [Unique]
    public class LogComponent : IComponent
    {
        public string Message { get; set; }
    }
}
