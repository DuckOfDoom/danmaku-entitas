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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SpawnSpawner(
                        new SpawnerSettings
                        {
                            Type = SpawnerType.Continuous,
                            Pattern = SpawnerPattern.Circular,
                            SpawnPeriod = 5f,
                            BurstDelay = 0.1f,
                            BurstLength = 5f
                        }
                    );
                }
            }
        }

        private void SpawnSpawner(ISpawnerSettings settings)
        {
            var e = Context.CreateEntity();
            SetRandomPosition(e);
            
            e.AddVelocity(MathUtils.GetRandomDirection() * MathUtils.Random(1f, 5f) , 0f);
            e.AddCollidable(0.1f);
            e.AddSpawner(settings, 0);
        }
        
        private void SetRandomPosition(GameplayEntity e)
        {
            var gameplayArea = CommonConfig.GameplayArea;

            e.AddSprite("");
            e.AddPosition(new Vector2(
                    Random.Range(gameplayArea.min.x, gameplayArea.max.x),
                    Random.Range(gameplayArea.min.y, gameplayArea.max.y)
                )
            );
        }
    }
}