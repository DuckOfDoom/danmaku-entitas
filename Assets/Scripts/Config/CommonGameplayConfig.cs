using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    [CreateAssetMenu(fileName = "CommonGameplayConfig")]
    public class CommonGameplayConfig : ScriptableObject, ICommonGameplayConfig
    {
        [SerializeField] private float _playerSpeedMultiplier = 1;
        [SerializeField] private Bounds _gameplayArea;
        [Space(10f)]
        [SerializeField] private Bounds _projectileDestructionBounds;

        public float PlayerSpeedMultiplier { get { return _playerSpeedMultiplier; } }
        public Bounds GameplayArea { get { return _gameplayArea; } }
        public Bounds ProjectileDestructionBounds { get { return _projectileDestructionBounds; } }
    }

    public interface ICommonGameplayConfig
    {
        Bounds GameplayArea { get; }
        float PlayerSpeedMultiplier { get; }
        
        Bounds ProjectileDestructionBounds { get; }
        
    }
}