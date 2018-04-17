using System;

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
    
    [Serializable]
    public class SpawnerSettings : ISpawnerSettings
    {
        public IPatternSettings Pattern { get; set; }
        public IBurstSettings Burst { get; set; }
        
        public int SpawnCount { get; set; }
        public float SpawnDelay { get; set; }
    }
    
    public interface IPatternSettings
    {
        PatternType Type { get; }
        float Size { get; }
    }

    [Serializable]
    public class PatternSettings : IPatternSettings
    {
        public PatternType Type { get; set; }
        public float Size { get; set; }
    }

    public interface IBurstSettings
    {
        int Count { get; }
        float Delay { get; }
    }

    [Serializable]
    public class BurstSettings : IBurstSettings
    {
        public int Count { get; set; }
        public float Delay { get; set; }
    }

}