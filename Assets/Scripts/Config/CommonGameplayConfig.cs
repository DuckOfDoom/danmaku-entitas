using System;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    [CreateAssetMenu(fileName = "CommonGameplayConfig")]
    public class CommonGameplayConfig : ScriptableObject, ICommonGameplayConfig
    {
        [Space(20f)] [SerializeField] private PlayerSettings _playerSettings;
        [Space(20f)] [SerializeField] private Bounds _gameplayArea;
        [Space(20f)] [SerializeField] private Bounds _projectileDestructionBounds;

        public IPlayerSettings PlayerSettings { get { return _playerSettings; } }
        public Bounds GameplayArea { get { return _gameplayArea; } }
        public Bounds ProjectileDestructionBounds { get { return _projectileDestructionBounds; } }
    }

    [Serializable]
    public class PlayerSettings : IPlayerSettings
    {
        public float MaxHealth { get { return _maxHealth; } }
        public float CollisionRadius { get { return _collisionRadius; } }
        public float Speed { get { return _speed; } } 
        
        [SerializeField] private float _maxHealth = 0.5f;
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _collisionRadius = 0.5f;
    }

    public interface IPlayerSettings 
    {
        float MaxHealth { get; }
        float CollisionRadius { get; }
        float Speed { get; }
    }

    public interface ICommonGameplayConfig
    {
        IPlayerSettings PlayerSettings { get; }
        Bounds GameplayArea { get; }
        Bounds ProjectileDestructionBounds { get; }
    }
}