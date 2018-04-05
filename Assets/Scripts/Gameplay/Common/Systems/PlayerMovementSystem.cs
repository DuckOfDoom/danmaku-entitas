using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class PlayerMovementSystem : ReactiveSystem<GameplayEntity>
    {
        [Inject] private ICommonGameplayConfig CommonConfig { get; set; }
        
        public PlayerMovementSystem(GameplayContext context) : base(context) { }

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
                var newPosition = e.position.Value + direction * CommonConfig.PlayerSpeedMultiplier * Time.deltaTime;
                
                if (!CommonConfig.PlayerMovementBounds.Contains(newPosition))
                    newPosition = CommonConfig.PlayerMovementBounds.ClosestPoint(newPosition);
                
                e.ReplacePosition(newPosition);
            });
        }
    }
}