using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class CreateGameObjectsSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly GameplayContext _context;

        public CreateGameObjectsSystem(GameplayContext context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.Sprite);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasSprite && (!entity.hasGameObject || !entity.hasSpriteRenderer);
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                var e = entities[i];
                GameObject go;
                if (!e.hasGameObject)
                {
                    go = new GameObject(e.isPlayer ? "Player" : "Not Player");
                    e.AddGameObject(go);
                }
                else
                {
                    go = e.gameObject.Instance;
                }

                if (!e.hasSpriteRenderer)
                {
                    var sr = go.AddComponent<SpriteRenderer>();
                    e.AddSpriteRenderer(sr);
                }

                if (go.GetEntityLink() == null || go.GetEntityLink().entity != e)
                    go.Link(e, _context);
            }
        }
    }
}