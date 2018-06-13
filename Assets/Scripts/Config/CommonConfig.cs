using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    public interface ICommonConfig
    {
        float MouseMovementSensitivity { get; }
        float KeyboardMovementSensitivity { get; }
    }
    
    [CreateAssetMenu(fileName = "CommonConfig")]
    public class CommonConfig : ScriptableObject, ICommonConfig
    {
        [SerializeField] private float _mouseMovementSensitivity = 1f;
        [SerializeField] private float _keyboardMovementSensitivity = 1f;

        public float MouseMovementSensitivity { get { return _mouseMovementSensitivity; } }
        public float KeyboardMovementSensitivity { get { return _keyboardMovementSensitivity; } }
    }

}