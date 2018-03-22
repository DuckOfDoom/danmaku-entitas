using Entitas;

namespace DuckOfDoom.Danmaku
{
    public class CollisionProcessingSystem : ITearDownSystem
    {
        private IGroup<GameplayEntity> _group;
        private IGroup<GameplayEntity> _playerGroup;
            
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
            AddDamage(_playerGroup.GetSingleEntity());
            playerCollision.CollidedWith.Destroy();
        }

        private void AddDamage(GameplayEntity entity)
        {
            if (entity.hasDamage)
                entity.damage.Amount++;
            else
                entity.AddDamage(1);
        }

        public void TearDown()
        {
            _group.OnEntityAdded -= OnPlayerCollision;
            _group = null;
        }
    }
}