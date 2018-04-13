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
		    Container.Bind<ICoroutineStarter>().FromMethod(_ =>
		    {
			    var go = new GameObject("CoroutineStarter");
			    return go.AddComponent<CoroutineStarter>();
		    }).AsSingle();
			    
		    Container.Bind<GameplayContext>().FromInstance(Contexts.sharedInstance.gameplay).AsSingle();
		    Container.Bind<ICommonGameplayConfig>().To<CommonGameplayConfig>().FromScriptableObjectResource("Config/CommonGameplayConfig").AsSingle();
		    Container.Bind<IPlayerSettings>().FromResolveGetter<ICommonGameplayConfig>(c => c.PlayerSettings);
		    
		    // Update systems
		    InstallCommonSystem<InitializePlayerSystem>();
		    InstallCommonSystem<CollisionProcessingSystem>();
		    
		    InstallUpdateSystem<GameTimeSystem>();
		    InstallUpdateSystem<AddViewSystem>();
		    InstallUpdateSystem<InputSystem>();
		    InstallUpdateSystem<PlayerMovementSystem>();
		    InstallUpdateSystem<ApplyVelocitySystem>();
		    InstallUpdateSystem<RenderTransformSystem>();
		    InstallUpdateSystem<RenderSpriteSystem>();
		    InstallUpdateSystem<InflictDamageSystem>();
		    InstallUpdateSystem<SpawnEnemiesSystem>();
		    InstallUpdateSystem<SpawnersSystem>();
		    InstallUpdateSystem<DestroyBeyondBoundsSystem>();

		    // Update systems
		    InstallFixedUpdateSystem<CollisionDetectionSystem>();

		    Container.Bind<VisualizationController>()
			    .FromNewComponentOn(context => _mainCamera.gameObject)
			    .AsSingle()
			    .NonLazy();
		    
		    Container.Bind<VisualizeCollidersSystem>().AsSingle();
		    
		    base.InstallBindings();
	    }
    }
}
