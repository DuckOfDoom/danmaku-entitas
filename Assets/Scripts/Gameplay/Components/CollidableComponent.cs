using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class CollidableComponent : IComponent
    {
        public float CollisionRadius { get; set; }
    }

    [Gameplay]
    public class PlayerCollision : IComponent
    {
        public GameplayEntity CollidedWith { get; set; }
    }
}
