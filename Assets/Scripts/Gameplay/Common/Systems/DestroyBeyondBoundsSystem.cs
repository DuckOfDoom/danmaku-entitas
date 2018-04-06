using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class DestroyBeyondBoundsSystem : ReactiveSystem<GameplayEntity>
    {
        [Inject] private ICommonGameplayConfig Config { get; set; }
        
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
                if (e.hasCollidable)
                {
                    var vectorToCenter = (Vector2)destructionBounds.center - e.position.Value;
                    var distanceToCenter = vectorToCenter.magnitude;
                    var closestPointToCenter = e.collidable.CollisionRadius * (vectorToCenter / distanceToCenter);
                    
//                    if (!destructionBounds.Contains(closestPointToCenter))
//                    {
//                        e.Destroy();
//                    }
                    
                    if (!destructionBounds.Contains(e.position.Value))
                    {
                        e.Destroy();
                    }
                }
            });
        }
    }
}