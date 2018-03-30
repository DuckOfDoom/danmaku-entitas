using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class GameTimeSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly GameplayContext _context;

        public GameTimeSystem(GameplayContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.CreateEntity().AddGameTime(0);
        }

        public void Execute()
        {
            _context.gameTime.Tick++;
        }
    }
}