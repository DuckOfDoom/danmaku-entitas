using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class Collidable : IComponent
    {
        public float CollisionRadius { get; set; }
    }

}
