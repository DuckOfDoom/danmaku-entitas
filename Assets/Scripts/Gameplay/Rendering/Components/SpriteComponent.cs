using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class SpriteComponent : IComponent
    {
        public string SpriteName { get; set; }
    }
    
    [Gameplay]
    public class SpriteRendererComponent : IComponent
    {
        public SpriteRenderer SpriteRenderer { get; set; }
    }
}