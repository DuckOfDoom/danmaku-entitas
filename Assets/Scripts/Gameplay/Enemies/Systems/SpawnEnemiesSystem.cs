using DuckOfDoom.Danmaku.Configuration;
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

        public void Execute()
        {
            if (_gameTime.GetSingleEntity().gameTime.Tick % 10 == 0)
            {
                SpawnBullet();
            }
        }

        private void SpawnBullet()
        {
            var e = Context.CreateEntity();
            var gameplayArea = CommonConfig.GameplayArea;

            e.AddPosition(new Vector2(
                    Random.Range(gameplayArea.min.x, gameplayArea.max.x),
                    Random.Range(gameplayArea.min.y, gameplayArea.max.y)
                )
            );

            // TODO: Configure enemy parameters!
            e.AddVelocity(Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * Vector3.up * 10 * Random.value, 0);
            
            e.AddCollidable(0.5f);
//            e.AddDamageDealer(5);
        }
    }
}