using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace DuckOfDoom.Danmaku
{
    [Gameplay, Unique]
    public class GameTimeComponent : IComponent
    {
        public int Frames { get; set; }
        public float Seconds { get; set; }
        
        public float DeltaTime { get; set; }
    }
}
