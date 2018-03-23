using System;
using System.Collections.Generic;
using Entitas;

namespace DuckOfDoom.Danmaku.UI.Systems
{
   public class PlayerStatsUISystem : ReactiveSystem<GameplayEntity>, IInitializeSystem
   {
       private readonly Action<float> _setPlayerHealth;
       private IContext<GameplayEntity> _context;

       public PlayerStatsUISystem(
           IContext<GameplayEntity> context,
           Action<float> setPlayerHealth
           ) : base(context)
       {
           _context = context;
           _setPlayerHealth = setPlayerHealth;
       }
       
       public void Initialize()
       {
           Execute(new List<GameplayEntity> {_context.GetGroup(GameplayMatcher.Player).GetSingleEntity()});
       }

       protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
       {
           return context.CreateCollector(
                   GameplayMatcher.Health
//               GameplayMatcher.AllOf(
//               )
           );
       }

       protected override bool Filter(GameplayEntity entity)
       {
           return true;// entity.isPlayer;
       }

       protected override void Execute(List<GameplayEntity> entities)
       {
           _setPlayerHealth(entities.SingleEntity().health.Value);
       }

   }
}