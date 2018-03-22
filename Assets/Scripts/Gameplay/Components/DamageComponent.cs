using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class DamageComponent : IComponent
    {
        public float Amount { get; set; }
    }
}