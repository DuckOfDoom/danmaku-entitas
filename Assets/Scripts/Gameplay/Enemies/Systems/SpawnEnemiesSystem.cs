using DuckOfDoom.Danmaku.Configuration;
using DuckOfDoom.Danmaku.Enemies.Settings;
using Entitas;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace DuckOfDoom.Danmaku
{
    public class SpawnEnemiesSystem : IExecuteSystem
    {
        [Inject] private GameplayContext Context { get; set; }
        [Inject] private ICommonGameplayConfig CommonConfig { get; set; }
        
        private readonly IGroup<GameplayEntity> _gameTime;
        
        public SpawnEnemiesSystem(GameplayContext context)
        {
            _gameTime = context.GetGroup(GameplayMatcher.GameTime);
        }

        private bool _spawned;

        public void Execute()
        {
//            if (_gameTime.GetSingleEntity().gameTime.Frames % 10 == 0)
//            {
//                SpawnBullet();
            if (!_spawned)
                SpawnSpawner();
            _spawned = true;
//            }
        }

        private void SpawnSpawner()
        {
            var e = Context.CreateEntity();
            SetPosition(e);
            
            e.AddSpawner(
                new SpawnerSettings
                {
                    Type = SpawnerType.Continuous,
                    Pattern = SpawnerPattern.Circular,
                    SpawnPeriod = 5f,
                    BurstDelay = 0.1f,
                    BurstLength = 1f
                },
                0);
        }
        
        private void SetPosition(GameplayEntity e)
        {
            var gameplayArea = CommonConfig.GameplayArea;

            e.AddSprite("");
                
            e.AddPosition(new Vector2(
                    Random.Range(gameplayArea.min.x, gameplayArea.max.x),
                    Random.Range(gameplayArea.min.y, gameplayArea.max.y)
                )
            );
        }

        private void SpawnBullet()
        {
            var e = Context.CreateEntity();
            SetPosition(e);

            // TODO: Configure enemy parameters!
            e.AddVelocity(Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * Vector3.up * 10 * Random.value, 0);
            
            e.AddCollidable(0.5f);
//            e.AddDamageDealer(5);
        }

    }
}