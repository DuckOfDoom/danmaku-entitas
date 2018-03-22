using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class HealthComponent : IComponent
    {
        public float Value { get; set; }
    }
}
