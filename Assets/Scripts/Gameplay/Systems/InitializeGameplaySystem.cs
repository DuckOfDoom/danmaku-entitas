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
            playerEntity.AddHealth(99999);
            playerEntity.AddPlayerMovementDirection(new Vector2(0, 0));
            playerEntity.AddCollidable(1f);
            playerEntity.AddPosition(new Vector2(0, 0));

            var projectileEntity = _context.CreateEntity();
            projectileEntity.isEnemyProjectile = true;
            projectileEntity.AddSprite("circle");
            projectileEntity.AddCollidable(1f);
            projectileEntity.AddPosition(new Vector2(0, 3));
        }
    }
}
