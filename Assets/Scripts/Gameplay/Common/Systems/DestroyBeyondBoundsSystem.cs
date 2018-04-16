using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class DestroyBeyondBoundsSystem : ReactiveSystem<GameplayEntity>
    {
        [Inject] private ICommonGameplayConfig Config { get; set; }
        
        private const float DESTRUCTION_OFFSET = 0.5f;
        
        public DestroyBeyondBoundsSystem(GameplayContext context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Position
                )
            );
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return !entity.isPlayer;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            var destructionBounds = Config.ProjectileDestructionBounds;
            
            entities.ForEach(e =>
            {
                var boundsCenter = (Vector2) destructionBounds.center;
                var c = e.position.Value;
                var v = boundsCenter - c;

                Vector2 offsetPoint;
                
                if (e.hasCollidable)
                {
                    var r = e.collidable.CollisionRadius;
                    var closestPointToCenter = c + v / v.magnitude * r;
                    offsetPoint = closestPointToCenter + v.normalized * DESTRUCTION_OFFSET;
                }
                else
                {
                    offsetPoint = v.normalized * DESTRUCTION_OFFSET;
                }
                
                if (!destructionBounds.Contains(offsetPoint))
                    Destroy(e);
            });
        }

        // TODO: Pooling!
        private void Destroy(GameplayEntity entity)
        {
            if (entity.hasGameObject)
            {
                entity.gameObject.Instance.Unlink();
                Object.Destroy(entity.gameObject.Instance);
            }

            entity.Destroy();
        }
    }
}