using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class Health : IComponent
    {
        public float Value { get; set; }
    }
}
