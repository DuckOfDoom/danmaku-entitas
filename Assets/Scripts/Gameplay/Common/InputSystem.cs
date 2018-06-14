using System;
using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class InputSystem : IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _wispGroup;
        private readonly List<IInputDeltaProvider> _deltaProvider;

        public InputSystem(GameplayContext context, ICamera camera, ICommonConfig commonConfig)
        {
            _deltaProvider = new List<IInputDeltaProvider>
            {
                new MouseInputDeltaProvider(camera, () => commonConfig.MouseMovementSensitivity),
                new KeyboardInputDeltaProvider(() => commonConfig.KeyboardMovementSensitivity)
            };
            _wispGroup = context.GetGroup(GameplayMatcher.WispMovementDelta);
        }
        
        public void Execute()
        {
            if (_wispGroup.count <= 0)
                return;

            var delta = Vector2.zero;

            for (var i = 0; i < _deltaProvider.Count; i++)
                delta = _deltaProvider[i].Update(delta);

            var wisp = _wispGroup.GetSingleEntity();
            wisp.ReplaceWispMovementDelta(delta);
        }

        private interface IInputDeltaProvider
        {
            Vector2 Update(Vector2 currentDelta);
        }
        
        private class MouseInputDeltaProvider : IInputDeltaProvider
        {
            private readonly ICamera _camera;
            private readonly Func<float> _sensitivityFunc;
            
            private Vector2 _prevUpdatePosition;
            private bool _skipFrame = false;
            
            public MouseInputDeltaProvider(ICamera camera, Func<float> sensitivityFunc)
            {
                _camera = camera;
                _sensitivityFunc = sensitivityFunc;
                
                _prevUpdatePosition = GetMousePos();
            }
            
            public Vector2 Update(Vector2 currentDelta)
            {
                if (!Input.GetMouseButton(0))
                {
                    return currentDelta;
                }
                
                if (Input.GetMouseButtonDown(0))
                {
                    _prevUpdatePosition = GetMousePos();
                    return Vector2.zero;
                }

                var mousePosition = GetMousePos();
                var delta = (mousePosition - _prevUpdatePosition) * _sensitivityFunc();
                
                _prevUpdatePosition = mousePosition;

                return currentDelta + delta;
            }

            private Vector2 GetMousePos()
            {
                return _camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        
        private class KeyboardInputDeltaProvider : IInputDeltaProvider
        {
            private readonly Func<float> _sensitivityFunc;
            private bool _skipFrame = false;

            public KeyboardInputDeltaProvider(Func<float> sensitivityFunc)
            {
                _sensitivityFunc = sensitivityFunc;
            }
            
            public Vector2 Update(Vector2 currentDelta)
            {
                var delta = Vector2.zero;
                
                if (Input.GetKey(KeyCode.A))
                    delta += Vector2.left;
                
                if (Input.GetKey(KeyCode.D))
                    delta += Vector2.right;
                
                if (Input.GetKey(KeyCode.W))
                    delta += Vector2.up;
                
                if (Input.GetKey(KeyCode.S))
                    delta += Vector2.down;

                return currentDelta + delta * _sensitivityFunc();
            }
        }
    }

}