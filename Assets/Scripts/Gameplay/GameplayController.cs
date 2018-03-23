namespace DuckOfDoom.Danmaku
{
    public class GameplayController : CommonController
    {
	    protected override void SetUp()
	    {
			var gameplayContext = Contexts.sharedInstance.gameplay;

			_updateSystems 
				.Add(new InitializeGameplaySystem(gameplayContext))
				.Add(new AddViewSystem(gameplayContext))
				.Add(new InputSystem(gameplayContext))
				.Add(new PlayerMovementSystem(gameplayContext))
				.Add(new RenderPositionSystem(gameplayContext))
				.Add(new CollisionProcessingSystem(gameplayContext))
				.Add(new InflictDamageSystem(gameplayContext))
				.Add(new RenderSpriteSystem(gameplayContext));
			
			_fixedUpdateSystems 
				.Add(new GameTimeSystem(gameplayContext))
				.Add(new CollisionDetectionSystem(gameplayContext));
	    }
    }
}
