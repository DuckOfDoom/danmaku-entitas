using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class InitializePlayerSystem : IInitializeSystem
    {
        [Inject] private GameplayContext Context { get; set; }
        [Inject] private IPlayerSettings PlayerSettings { get; set; }

        public void Initialize()
        {
            var playerEntity = Context.CreateEntity();
            
            playerEntity.isWisp = true;
//            playerEntity.AddSprite("circle");
            playerEntity.AddWispMovementDelta(new Vector2(0, 0));

            playerEntity.AddHealth(PlayerSettings.MaxHealth);
            playerEntity.AddCollidable(PlayerSettings.CollisionRadius);

            playerEntity.AddPosition(new Vector2(0, 0));
        }
    }
}
