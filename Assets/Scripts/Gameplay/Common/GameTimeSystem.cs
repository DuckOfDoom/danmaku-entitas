using Entitas;
using UnityEngine;

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
            _context.CreateEntity().AddGameTime(0, 0, Time.deltaTime);
        }

        public void Execute()
        {
            _context.gameTime.Seconds += Time.deltaTime;
            _context.gameTime.DeltaTime = Time.deltaTime;
            
            _context.gameTime.Frames++;
        }
    }
}