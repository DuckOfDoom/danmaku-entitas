using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class InputSystem : IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _playerGroup;

        public InputSystem(GameplayContext context)
        {
            _playerGroup = context.GetGroup(GameplayMatcher.PlayerMovementDirection);
        }
        
        public void Execute()
        {
            if (_playerGroup.count <= 0)
                return;
            
            var player = _playerGroup.GetSingleEntity();
            
            var dir = Vector2.zero;
            if (Input.GetAxis("Vertical") > 0)
                dir += Vector2.up;
            else if (Input.GetAxis("Vertical") < 0)
                dir -= Vector2.up;
            
            if (Input.GetAxis("Horizontal") > 0)
                dir -= Vector2.left;
            else if (Input.GetAxis("Horizontal") < 0)
                dir += Vector2.left;
            
            player.ReplacePlayerMovementDirection(dir);
        }
    }
}