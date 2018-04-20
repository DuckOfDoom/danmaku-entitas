using System.Collections;
using DuckOfDoom.Danmaku.Enemies.Factories;
using DuckOfDoom.Danmaku.Enemies.Settings;
using Entitas;
using ModestTree;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class SpawnersSystem : IExecuteSystem
    {
        [Inject] private GameplayContext _contex;
        [Inject] private ICoroutineStarter _coroutineStarter;
        [Inject] private IProjectilesFactory _projectilesFactory;
        
        private readonly IGroup<GameplayEntity> _spawnersGroup;
        private GameTimeComponent _gameTime;
        
        public SpawnersSystem(GameplayContext context)
        {
            _spawnersGroup = context.GetGroup(GameplayMatcher.Spawner);
        }

        public void Execute()
        {
            if (_gameTime == null)
            {
                _gameTime = _contex.GetGroup(GameplayMatcher.GameTime).GetSingleEntity().gameTime;
            }

            _spawnersGroup.GetEntities().ForEach(e =>
            {
                var spawner = e.spawner;
                var spawnedEnough = spawner.Settings.SpawnCount > 0 && spawner.TimesSpawned < spawner.Settings.SpawnCount;
                var canSpawn = spawner.LastSpawnedAt <= 0 || _gameTime.Seconds - spawner.LastSpawnedAt >= spawner.Settings.SpawnDelay;
                
                if (!spawnedEnough && canSpawn)
                {
                    if (e.hasPosition)
                    {
                        _coroutineStarter.StartCoroutine(Spawn(e, spawner.Settings));
                        
                        spawner.LastSpawnedAt = _gameTime.Seconds;
                        spawner.TimesSpawned++;
                    }
                    else
                        Debug.LogWarningFormat("Found a spawner with no position: {0}", e);
                }
            });
        }

        private IEnumerator Spawn(GameplayEntity e, ISpawnerSettings settings)
        {
            var currentBurstCount = 0f;
            var currentBurstDelay = settings.Burst.Delay;
            
            while (e.isEnabled && currentBurstCount < settings.Burst.Count)
            {
                if (currentBurstDelay >= settings.Burst.Delay)
                {
                    var angleDelta = Mathf.PI * 2 / settings.Pattern.Size;
                    var angle = 0f;
                    var centerOffset = 0.1f;

                    while (angle < Mathf.PI * 2)
                    {
                        var vectorAway = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                        var pos = vectorAway * 2f * centerOffset + e.position.Value;

                        _projectilesFactory.SpawnProjectile(
                            pos,
                            vectorAway * 5f + (e.hasVelocity ? e.velocity.Linear : Vector2.zero)
                        );

                        angle += angleDelta;
                    }

                    currentBurstDelay = 0;
                    currentBurstCount++;
                }
                else
                {
                    currentBurstDelay += _gameTime.DeltaTime;
                }

                yield return null;
            }
        }
    }
}