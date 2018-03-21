using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    [Gameplay, Unique]
    public class PlayerComponent : IComponent
    {
        
    }
    
    [Gameplay, Unique]
    public class PlayerMovementDirectionComponent : IComponent
    {
        public Vector2 Direction { get; set; }
    }

    [Gameplay]
    public class PositionComponent : IComponent
    {
        public Vector2 Value { get; set; }
    }
}