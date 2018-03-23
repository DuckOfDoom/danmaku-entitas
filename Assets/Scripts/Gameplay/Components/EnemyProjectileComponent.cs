using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class EnemyProjectileComponent : IComponent
    {
        public float Damage { get; set; }
    }
}
