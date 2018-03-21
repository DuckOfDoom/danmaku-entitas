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
			var gameplayContext = Contexts.sharedInstance.gameplay;

			_updateSystems = new Systems()
				.Add(new InitializeGameplaySystem(gameplayContext))
				.Add(new AddViewSystem(gameplayContext))
				.Add(new InputSystem(gameplayContext))
				.Add(new PlayerMovementSystem(gameplayContext))
				.Add(new RenderPositionSystem(gameplayContext))
				.Add(new RenderSpriteSystem(gameplayContext));
			
			_updateSystems.Initialize();

			_fixedUpdateSystems = new Systems()
				.Add(new GameTimeSystem(gameplayContext))
				.Add(new PlayerCollisionSystem(gameplayContext));
			
			_fixedUpdateSystems.Initialize();

		}
	    
		[UsedImplicitly] 
		public void Update()
		{
			_updateSystems.Execute();
			_updateSystems.Cleanup();
		}

	    [UsedImplicitly]
	    public void FixedUpdate()
	    {
		    _fixedUpdateSystems.Execute();
		    _fixedUpdateSystems.Cleanup();
	    }
	    
        [UsedImplicitly]
	    private void OnDestroy()
	    {
			_updateSystems.TearDown();
		    _fixedUpdateSystems.TearDown();
	    }
    }
}
