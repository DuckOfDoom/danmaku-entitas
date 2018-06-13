using System;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Enemies.Settings
{
    public enum PatternType
    {
        Undefined = 0,
        Circular = 1
    }
    
    public interface ISpawnerSettings
    {
        IBurstSettings Burst { get; }
        IPatternSettings Pattern { get; }
        
        int SpawnCount { get; }
        float SpawnDelay { get; }
    }
    
    public interface IBurstSettings
    {
        int Count { get; }
        float Delay { get; }
    }
    
    public interface IPatternSettings
    {
        PatternType Type { get; }
        float Size { get; }
    }

    
    [Serializable]
    public class SpawnerSettings : ISpawnerSettings
    {
        [SerializeField] private int _spawnCount;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private PatternSettings _pattern;
        [SerializeField] private BurstSettings _burst;

        public IPatternSettings Pattern { get { return _pattern; } }
        public IBurstSettings Burst { get { return _burst; } } 
        public int SpawnCount { get { return _spawnCount; } } 
        public float SpawnDelay { get { return _spawnDelay; } } 
    }
    
    [Serializable]
    public class PatternSettings : IPatternSettings
    {
        [SerializeField] private PatternType _type;
        [SerializeField] private float _size;

        public PatternType Type { get { return _type; } }
        public float Size { get { return _size; } }
    }


    [Serializable]
    public class BurstSettings : IBurstSettings
    {
        [SerializeField] private int _count;
        [SerializeField] private float _delay;

        public int Count { get { return _count; } }
        public float Delay { get { return _delay; } }
    }

}