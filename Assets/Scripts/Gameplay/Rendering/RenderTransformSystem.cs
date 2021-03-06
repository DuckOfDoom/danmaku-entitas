﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class RenderTransformSystem : ReactiveSystem<GameplayEntity>
    {
        public RenderTransformSystem(GameplayContext context) : base(context) { } 
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.Position,
                    GameplayMatcher.GameObject
                )
            );
        }

        protected override bool Filter(GameplayEntity entity) { return true; }

        protected override void Execute(List<GameplayEntity> entities)
        {
            entities.ForEach(e =>
            {
                var tr = e.gameObject.Instance.transform;
                if (e.hasPosition)
                    tr.position = new Vector3(e.position.Value.x, e.position.Value.y, tr.position.z);
                
                if (e.hasRotation)
                    tr.rotation = Quaternion.AngleAxis(e.rotation.Angle, Vector3.forward);
            });
        }
    }
}