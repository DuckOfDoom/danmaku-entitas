using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class CollisionDetectionSystem : IExecuteSystem
    {
        private readonly GameplayContext _context;
        private readonly IGroup<GameplayEntity> _playerGroup;
        private readonly IGroup<GameplayEntity> _projectilesGroup;
        
        public CollisionDetectionSystem(GameplayContext context)
        {
            _context = context;
            
            _playerGroup = context.GetGroup(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Player
                )
            );

            _projectilesGroup = context.GetGroup(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Collidable
                )
            );
        }

        public void Execute()
        {
            var player = _playerGroup.GetSingleEntity();
            var playerPosition = player.position.Value;
            var playerCollisionRadius = player.collidable.CollisionRadius;

            var projectiles = _projectilesGroup.GetEntities();
            for (int i = 0; i < projectiles.Length; i++)
            {
                var e = projectiles[i];
                if (e.hasPlayerCollision) // Players shouldnt collide with himself
                    continue;
                
                var projectilePosition = e.position.Value;
                var projectileCollisionRadius = e.collidable.CollisionRadius;

                var dist = Vector2.Distance(playerPosition, projectilePosition);
                if (dist < playerCollisionRadius + projectileCollisionRadius)
                {
                    _context.CreateEntity().AddPlayerCollision(e);
                }
            }
        }
    }
}