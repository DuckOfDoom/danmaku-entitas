using System.Collections.Generic;
using Entitas;

namespace DuckOfDoom.Danmaku
{
    public class LoggingSystem : ReactiveSystem<Entity>
    {
        public LoggingSystem(IContext<Entity> context) : base(context)
        {
            
        }

        public LoggingSystem(ICollector<Entity> collector) : base(collector)
        {
            
        }

        protected override ICollector<Entity> GetTrigger(IContext<Entity> context)
        {
            return null;
            //            return context.CreateCollector(
            //                Matcher<Entity>.AnyOf(Matcher<Entity>
            //                    )
            //            );
        }

        protected override bool Filter(Entity entity)
        {
            return true;
        }

        protected override void Execute(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                
            }
        }
    }
}
