using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class AddViewSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly GameplayContext _context;

        public AddViewSystem(GameplayContext context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.Sprite);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasSprite && !entity.hasView;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                var e = entities[i];
                var go = new GameObject(e.isPlayer ? "Player" : "Not Player");
                var sr = go.AddComponent<SpriteRenderer>();
                
                e.AddView(go);
                e.AddSpriteRenderer(sr);
                
                go.Link(e, _context);
            }
        }
    }
}