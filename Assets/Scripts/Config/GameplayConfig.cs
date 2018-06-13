using System;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    public interface IGameplayConfig
    {
        IPlayerSettings PlayerSettings { get; }
        Bounds GameplayArea { get; }
        Bounds ProjectileDestructionBounds { get; }
    }
    
    [CreateAssetMenu(fileName = "GameplayConfig")]
    public class GameplayConfig : ScriptableObject, IGameplayConfig
    {
        [Space(20f)] [SerializeField] private PlayerSettings _playerSettings;
        [Space(20f)] [SerializeField] private Bounds _gameplayArea;
        [Space(20f)] [SerializeField] private Bounds _projectileDestructionBounds;

        public IPlayerSettings PlayerSettings { get { return _playerSettings; } }
        public Bounds GameplayArea { get { return _gameplayArea; } }
        public Bounds ProjectileDestructionBounds { get { return _projectileDestructionBounds; } }
    }

    public interface IPlayerSettings 
    {
        float MaxHealth { get; }
        float CollisionRadius { get; }
    }

    [Serializable]
    public class PlayerSettings : IPlayerSettings
    {
        public float MaxHealth { get { return _maxHealth; } }
        public float CollisionRadius { get { return _collisionRadius; } }
        
        [SerializeField] private float _maxHealth = 0.5f;
        [SerializeField] private float _collisionRadius = 0.5f;
    }
}