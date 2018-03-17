using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class GameplayController : MonoBehaviour
    {
	    private Systems _updateSystems;
	    private Systems _fixedUpdateSystems;
		    
		[UsedImplicitly] 
		public void Awake()
		{
			_updateSystems = new Systems()
				.Add(new InitializeGameplaySystem());
			
			_updateSystems.Initialize();
		    
		    _fixedUpdateSystems = new Systems()
			    .Add(new GameTimeSystem(Contexts.sharedInstance.gameplay));
			
			_fixedUpdateSystems.Initialize();
		}
	    
		[UsedImplicitly] 
		public void Update()
		{
			_updateSystems.Execute();
			_updateSystems.Cleanup();
		}
	    
        [UsedImplicitly]
	    private void OnDestroy()
	    {
			_updateSystems.TearDown();
	    }
    }

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
