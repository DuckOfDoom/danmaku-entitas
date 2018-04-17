using DuckOfDoom.Danmaku.Enemies.Settings;
using Entitas;

namespace DuckOfDoom.Danmaku
{
    public class Spawner : IComponent
    {
        public ISpawnerSettings Settings { get; set; }
        
        public float LastSpawnedAt { get; set; }
        public int TimesSpawned { get; set; }
    }

}