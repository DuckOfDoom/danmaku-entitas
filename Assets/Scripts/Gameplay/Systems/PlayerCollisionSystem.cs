using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class PlayerCollisionSystem : IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _playerGroup;
        private readonly IGroup<GameplayEntity> _projectilesGroup;

        public PlayerCollisionSystem(GameplayContext context) 
        {
            _playerGroup = context.GetGroup(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Player
                )
            );

            _projectilesGroup = context.GetGroup(
                GameplayMatcher.AllOf(
                    GameplayMatcher.EnemyProjectile
                )
            );
        }

        public void Execute()
        {
            var player = _playerGroup.GetSingleEntity();
            var playerPosition = player.position.Value;
            var playerCollisionRadius = player.collidable.collisionRadius;

            var projectiles = _projectilesGroup.GetEntities();
            for (int i = 0; i < projectiles.Length; i++)
            {
                var e = projectiles[i];
                var projectilePosition = e.position.Value;
                var projectileCollisionRadius = e.collidable.collisionRadius;

                var dist = Vector2.Distance(playerPosition, projectilePosition);
                if (dist < playerCollisionRadius + projectileCollisionRadius)
                    UnityEngine.Debug.LogFormat("Player collided with {0}!", e);
            }
        }
    }
}