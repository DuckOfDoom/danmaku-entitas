using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class InitializePlayerSystem : IInitializeSystem
    {
        private readonly GameplayContext _context;

        public InitializePlayerSystem(GameplayContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var playerEntity = _context.CreateEntity();
            
            playerEntity.isPlayer = true;
            playerEntity.AddSprite("circle");
            playerEntity.AddHealth(150);
            playerEntity.AddPlayerMovementDirection(new Vector2(0, 0));
            playerEntity.AddCollidable(1f);
            playerEntity.AddPosition(new Vector2(0, 0));

            var projectileEntity = _context.CreateEntity();
            projectileEntity.isEnemy = true;
            projectileEntity.AddDamageDealer(1.5f);
            projectileEntity.AddSprite("circle");
            projectileEntity.AddCollidable(1f);
            projectileEntity.AddPosition(new Vector2(0, 3));
        }
    }
}
