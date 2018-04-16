using System;
using System.Collections;
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
                if (_gameTime.Seconds - spawner.LastSpawnedAt >= spawner.Settings.SpawnPeriod)
                {
                    if (e.hasPosition)
                    {
                        Spawn(e, spawner.Settings);
                        spawner.LastSpawnedAt = _gameTime.Seconds;
                    }
                    else
                        Debug.LogWarningFormat("Found a spawner with no position: {0}", e);
                }
            });
        }

        private void Spawn(GameplayEntity e, ISpawnerSettings settings)
        {
            switch (settings.Pattern)
            {
                case SpawnerPattern.Undefined:
                    break;
                case SpawnerPattern.Circular:
                {
                    _coroutineStarter.StartCoroutine(
                        SpawnCircular(e, settings.BurstLength, settings.BurstDelay)
                    );
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator SpawnCircular(GameplayEntity e, float burstLength, float burstDelay)
        {
            var currentBurstLength = 0f;
            var currentBurstDelay = burstDelay;
            
            while (e.isEnabled && currentBurstLength < burstLength)
            {
                if (currentBurstDelay >= burstDelay)
                {
                    var angleDelta = Mathf.PI * 2 / 7f;
                    var angle = 0f;
                    var centerOffset = 0.1f;

                    while (angle < Mathf.PI * 2)
                    {
                        var vectorAway = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                        var pos = vectorAway * 2f * centerOffset + e.position.Value;

                        SpawnBullet(pos, vectorAway * 5f);

                        angle += angleDelta;
                    }

                    currentBurstDelay = 0;
                }
                else
                    currentBurstDelay += _gameTime.DeltaTime;

                currentBurstLength += _gameTime.DeltaTime;

                yield return null;
            }
        }

        private void SpawnBullet(Vector2 position, Vector2 linearVelocity)
        {
            var e = _contex.CreateEntity();
            e.isEnemy = true;
            e.AddPosition(position);
            e.AddCollidable(0.1f);
            e.AddDamageDealer(1f);
            e.AddVelocity(linearVelocity, 0);
        }
    }
}