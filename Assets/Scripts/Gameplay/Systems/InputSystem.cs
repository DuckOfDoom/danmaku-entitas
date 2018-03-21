using Entitas;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

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
            if (Input.GetKey(KeyCode.W))
                dir += Vector2.up;
            else if (Input.GetKey(KeyCode.S))
                dir += Vector2.down;

            if (Input.GetKey(KeyCode.A))
                dir += Vector2.left;
            else if (Input.GetKey(KeyCode.D))
                dir += Vector2.right;
            
            player.ReplacePlayerMovementDirection(dir);
        }
    }
}