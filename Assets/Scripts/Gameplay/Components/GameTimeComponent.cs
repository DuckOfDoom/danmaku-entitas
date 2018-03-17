using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace DuckOfDoom.Danmaku
{
    [Gameplay, Unique]
    public class GameTimeComponent : IComponent
    {
        public ulong Tick { get; set; }
    }
}
