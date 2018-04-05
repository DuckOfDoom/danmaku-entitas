using System;
using System.Collections.Generic;
using Entitas;

namespace DuckOfDoom.Danmaku.UI.Systems
{
   public class PlayerStatsUISystem : ReactiveSystem<GameplayEntity>
   {
       private readonly Action<float> _setPlayerHealth;
       private readonly IContext<GameplayEntity> _context;

       public PlayerStatsUISystem(
           GameplayContext context,
           Action<float> setPlayerHealth
           ) : base(context)
       {
           _context = context;
           _setPlayerHealth = setPlayerHealth;
       }

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
           _setPlayerHealth(value);
       }

   }
}