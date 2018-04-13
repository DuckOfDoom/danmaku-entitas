using System;

namespace DuckOfDoom.Danmaku.Enemies.Settings
{
    [Serializable]
    public class SpawnerSettings : ISpawnerSettings
    {
        public SpawnerType Type { get; set; }
        public SpawnerPattern Pattern { get; set; }
        public float SpawnPeriod { get; set; }

        public float BurstLength { get; set; }
        public float BurstDelay { get; set; }
    }
    
    public interface ISpawnerSettings
    {
        SpawnerType Type { get; set; }
        SpawnerPattern Pattern { get; set; }
        
        float SpawnPeriod { get; set; }
        float BurstLength { get; set; }
        float BurstDelay { get; set; }
    }

    public enum SpawnerType
    {
        Undefined = 0,
        Continuous = 1,
        Burst = 2
    }

    public enum SpawnerPattern
    {
        Undefined = 0,
        Circular = 1
    }
}