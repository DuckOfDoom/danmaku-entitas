using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class RenderPositionSystem : ReactiveSystem<GameplayEntity>
    {
        public RenderPositionSystem(IContext<GameplayEntity> context) : base(context) { } 
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Position,
                    GameplayMatcher.View
                )
            );
        }

        protected override bool Filter(GameplayEntity entity) { return true; }

        protected override void Execute(List<GameplayEntity> entities)
        {
            entities.ForEach(e => e.view.GameObject.transform.position = new Vector2(e.position.X, e.position.Y));
        }
    }
}