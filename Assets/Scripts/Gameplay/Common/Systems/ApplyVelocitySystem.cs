using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class ApplyVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _movables;
        
        public ApplyVelocitySystem(GameplayContext context)
        {
            // TODO: Maybe unite rotation and position as "Transform"?
            _movables = context.GetGroup(GameplayMatcher.Velocity);
        }

        public void Execute()
        {
            foreach (var e in _movables.GetEntities())
            {
                if (e.hasPosition)
                {
                    var pos = e.position.Value;
                    e.ReplacePosition(pos + e.velocity.Linear * Time.deltaTime);
                }

                if (e.hasRotation)
                {
                    var angle = e.rotation.Angle;
                    e.ReplaceRotation(angle + e.velocity.Angular * Time.deltaTime);
                }
            }
        }
    }
}