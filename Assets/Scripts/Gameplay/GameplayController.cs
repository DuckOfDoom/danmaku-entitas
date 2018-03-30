namespace DuckOfDoom.Danmaku
{
    public class GameplayController : CommonController
    {
	    protected override void SetUp()
	    {
			var gameplayContext = Contexts.sharedInstance.gameplay;

		    _updateSystems
			    .Add(new InitializePlayerSystem(gameplayContext))
			    .Add(new AddViewSystem(gameplayContext))
			    .Add(new InputSystem(gameplayContext))
			    .Add(new PlayerMovementSystem(gameplayContext))
			    .Add(new ApplyVelocitySystem(gameplayContext))
			    .Add(new RenderTransformSystem(gameplayContext))
			    .Add(new RenderSpriteSystem(gameplayContext))
			    .Add(new CollisionProcessingSystem(gameplayContext))
			    .Add(new InflictDamageSystem(gameplayContext));
			
			_fixedUpdateSystems 
				.Add(new GameTimeSystem(gameplayContext))
				.Add(new CollisionDetectionSystem(gameplayContext));
	    }
    }
}
