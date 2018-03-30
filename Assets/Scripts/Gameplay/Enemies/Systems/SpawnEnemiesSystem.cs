using Entitas;

namespace DuckOfDoom.Danmaku
{
    public class SpawnEnemiesSystem : IExecuteSystem
    {
        private readonly IContext<GameplayEntity> _context;
        private readonly IGroup<GameplayEntity> _gameTime;
        
        public SpawnEnemiesSystem(IContext<GameplayEntity> context)
        {
            _context = context;
            _gameTime = context.GetGroup(GameplayMatcher.GameTimeSystem);
        }

        public void Execute()
        {
            if (_gameTime.GetSingleEntity().gameTime.Tick % 1000 == 0)
            {
                AddSimpleSpawner(_context.CreateEntity());
            }
        }

        private void AddSimpleSpawner(GameplayEntity entity)
        {
            
        }
    }
}