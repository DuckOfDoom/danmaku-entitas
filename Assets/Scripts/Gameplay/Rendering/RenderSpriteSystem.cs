using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class RenderSpriteSystem : ReactiveSystem<GameplayEntity>
    {
        public RenderSpriteSystem(GameplayContext context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.SpriteRenderer,
                    GameplayMatcher.Sprite
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
                e.spriteRenderer.SpriteRenderer.sprite = Resources.Load<Sprite>(e.sprite.SpriteName);
            });
        }
    }
}