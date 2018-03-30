﻿using Entitas;

namespace DuckOfDoom.Danmaku
{
    public class CollisionProcessingSystem : ITearDownSystem
    {
        private readonly IGroup<GameplayEntity> _group;
        private readonly IGroup<GameplayEntity> _playerGroup;
            
        public CollisionProcessingSystem(IContext<GameplayEntity> context) 
        {
            _group = context.GetGroup(GameplayMatcher.PlayerCollision);
            _group.OnEntityAdded += OnPlayerCollision;

            _playerGroup = context.GetGroup(GameplayMatcher.Player);
        }

        private void OnPlayerCollision(IGroup<GameplayEntity> group, GameplayEntity entity, int index, IComponent component)
        {
            ProcessCollision(entity.playerCollision);
        }

        private void ProcessCollision(PlayerCollision playerCollision)
        {
            if (playerCollision.CollidedWith.hasDamageDealer)
            {
                AddDamage(_playerGroup.GetSingleEntity(), playerCollision.CollidedWith.damageDealer.Damage);
                playerCollision.CollidedWith.Destroy();
            }
        }

        private static void AddDamage(GameplayEntity entity, float amount)
        {
            if (entity.hasDamage)
                entity.damage.Amount += amount;
            else
                entity.AddDamage(amount);
        }

        public void TearDown()
        {
            _group.OnEntityAdded -= OnPlayerCollision;
        }
    }
}