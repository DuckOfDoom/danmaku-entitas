using DuckOfDoom.Danmaku.Configuration;
using DuckOfDoom.Danmaku.Utility;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class GameplayInstaller : EcsInstaller
    {
	    [SerializeField] private Camera _mainCamera;
	    
	    public override void InstallBindings()
	    {
		    Container.Bind<GameplayContext>().FromInstance(Contexts.sharedInstance.gameplay).AsSingle();
		    Container.Bind<ICommonGameplayConfig>().To<CommonGameplayConfig>().FromScriptableObjectResource("Config/CommonGameplayConfig").AsSingle();
		    Container.Bind<IPlayerSettings>().FromResolveGetter<ICommonGameplayConfig>(c => c.PlayerSettings);
		    
		    // Update systems
		    InstallCommonSystem<InitializePlayerSystem>();
		    InstallCommonSystem<CollisionProcessingSystem>();
		    
		    InstallUpdateSystem<AddViewSystem>();
		    InstallUpdateSystem<InputSystem>();
		    InstallUpdateSystem<PlayerMovementSystem>();
		    InstallUpdateSystem<ApplyVelocitySystem>();
		    InstallUpdateSystem<RenderTransformSystem>();
		    InstallUpdateSystem<RenderSpriteSystem>();
		    InstallUpdateSystem<InflictDamageSystem>();
		    InstallUpdateSystem<SpawnEnemiesSystem>();
		    InstallUpdateSystem<DestroyBeyondBoundsSystem>();

		    // Update systems
		    InstallFixedUpdateSystem<GameTimeSystem>();
		    InstallFixedUpdateSystem<CollisionDetectionSystem>();

		    Container.Bind<VisualizeCollidersSystem>().AsSingle();
		    Container.Bind<VisualizationController>()
			    .FromNewComponentOn(context => _mainCamera.gameObject)
			    .AsSingle()
			    .NonLazy();
		    
		    base.InstallBindings();
	    }
    }
}
