using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    [Gameplay, Unique]
    public class WispComponent : IComponent
    {
        
    }
    
    [Gameplay, Unique]
    public class WispMovementDelta : IComponent
    {
        public Vector2 Delta { get; set; }
    }
    
    [Gameplay]
    public class WispCollision : IComponent
    {
        public GameplayEntity CollidedWith { get; set; }
    }
}