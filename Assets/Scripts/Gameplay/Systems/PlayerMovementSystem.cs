using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class PlayerMovementSystem : ReactiveSystem<GameplayEntity>
    {
        public PlayerMovementSystem(IContext<GameplayEntity> context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Player,
                    GameplayMatcher.PlayerMovementDirection,
                    GameplayMatcher.Position
                )
            );
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            entities.ForEach(e =>
            {
                var direction = e.playerMovementDirection.Direction;
 
                // Add speed and configuration?
                e.ReplacePosition(
                    e.position.X += direction.x * Time.deltaTime,
                    e.position.Y += direction.y * Time.deltaTime
                );
            });
        }
    }
}