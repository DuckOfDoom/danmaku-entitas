using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class InitializeGameplaySystem : IInitializeSystem
    {
        private readonly GameplayContext _context;

        public InitializeGameplaySystem(GameplayContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var playerEntity = _context.CreateEntity();
            
            playerEntity.isPlayer = true;
            playerEntity.AddSprite("circle");
            playerEntity.AddPlayerMovementDirection(new Vector2(0, 0));
            playerEntity.AddPosition(0, 0);
        }
    }
}
