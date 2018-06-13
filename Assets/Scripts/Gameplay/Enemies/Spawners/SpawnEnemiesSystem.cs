using DuckOfDoom.Danmaku.Configuration;
using DuckOfDoom.Danmaku.Enemies.Factories;
using Entitas;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace DuckOfDoom.Danmaku
{
    public class SpawnEnemiesSystem : IExecuteSystem
    {
        [Inject] private IGameplayConfig Config { get; set; }
        [Inject] private ISpawnersFactory SpawnersFactory { get; set; }

        public void Execute()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SpawnersFactory.CreateSpawner("Test1", GetRandomPosition());
                }
            }
        }

        private Vector2 GetRandomPosition()
        {
            var gameplayArea = Config.GameplayArea;

            return new Vector2(
                Random.Range(gameplayArea.min.x, gameplayArea.max.x),
                Random.Range(gameplayArea.min.y, gameplayArea.max.y)
            );
        }
    }
}