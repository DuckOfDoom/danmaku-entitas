using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class WispMovementSystem : ReactiveSystem<GameplayEntity>
    {
        [Inject] private IGameplayConfig Config { get; set; }
        
        public WispMovementSystem(GameplayContext context) : base(context) { }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Wisp,
                    GameplayMatcher.WispMovementDelta,
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
                var direction = e.wispMovementDelta.Delta;
                var newPosition = e.position.Value + direction; 
                
                if (!Config.GameplayArea.Contains(newPosition))
                    newPosition = Config.GameplayArea.ClosestPoint(newPosition);
                
                e.ReplacePosition(newPosition);
            });
        }
    }
}