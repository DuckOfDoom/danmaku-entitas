using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    /// <summary>
    ///     Apply damage to health
    /// </summary>
    public class InflictDamageSystem : ReactiveSystem<GameplayEntity>
    {
        public InflictDamageSystem(GameplayContext context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.Damage
            );
        }

        protected override bool Filter(GameplayEntity entity)
        {
            if (!entity.hasHealth)
                Debug.LogErrorFormat("Ignoring damage for entity {0} (no health component)", entity);
            
            return entity.hasHealth;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            entities.ForEach(e =>
            {
                e.health.Value -= e.damage.Amount;
                e.RemoveDamage();
            });
        }
    }
}