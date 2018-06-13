using System.Collections.Generic;
using Entitas;
using Zenject;

namespace DuckOfDoom.Danmaku.UI
{
   public delegate void SetPlayerHealth(float health);
    
   public class PlayerStatsUISystem : ReactiveSystem<GameplayEntity>
   {
       [Inject]
       private SetPlayerHealth SetPlayerHealth { get; set; }
      
       public PlayerStatsUISystem(GameplayContext context) : base(context) { } 
       
       protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
       {
           return context.CreateCollector(GameplayMatcher.Health);
       }

       protected override bool Filter(GameplayEntity entity)
       {
           return true;
       }

       protected override void Execute(List<GameplayEntity> entities)
       {
           var player = entities.SingleEntity();
           var health = player.health;
           var value = health.Value;
           
           SetPlayerHealth(value);
       }
   }
}