using DuckOfDoom.Danmaku.Configuration;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku.Enemies.Factories
{
    public interface ISpawnersFactory
    {
        GameplayEntity CreateSpawner(string settingsId, Vector2 position);
    }
    
    public class SpawnersFactory : ISpawnersFactory
    {
        [Inject] private GameplayContext _context { get; set; }
        [Inject] private ISpawnersConfig _spawnersConfig { get; set; }
        
        public GameplayEntity CreateSpawner(string settingsId, Vector2 position)
        {
            var settings = _spawnersConfig.Get(settingsId);
            var e = _context.CreateEntity();
            
            e.AddPosition(position);
            e.AddVelocity(MathUtils.GetRandomDirection() * MathUtils.Random(1f, 5f) , 0f);
            e.AddCollidable(0.1f);
            e.AddSpawner(settings, 0, 0);

            return e;
        }
    }

}