using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class PositionComponent : IComponent
    {
        public Vector2 Value { get; set; }
    }

    [Gameplay]
    public class RotationComponent : IComponent
    {
        public float Angle { get; set; }
    }
    
    [Gameplay]
    public class VelocityComponent : IComponent
    {
        public Vector2 Linear { get; set; }
        public float Angular { get; set; }
    }
}