using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    [CreateAssetMenu(fileName = "CommonGameplayConfig")]
    public class CommonGameplayConfig : ScriptableObject, ICommonGameplayConfig
    {
        [SerializeField] private float _playerSpeedMultiplier = 1;
        [SerializeField] private Bounds _playerMovementBounds;
        [Space(10f)]
        [SerializeField] private Bounds _projectileDestructionBounds;

        public Bounds PlayerMovementBounds { get { return _playerMovementBounds; } }
        public float PlayerSpeedMultiplier { get { return _playerSpeedMultiplier; } }
        
        public Bounds ProjectileDestructionBounds { get { return _projectileDestructionBounds; } }
    }

    public interface ICommonGameplayConfig
    {
        Bounds PlayerMovementBounds { get; }
        float PlayerSpeedMultiplier { get; }
        
        Bounds ProjectileDestructionBounds { get; }
        
    }
}