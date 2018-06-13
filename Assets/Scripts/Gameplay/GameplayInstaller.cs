using DuckOfDoom.Danmaku.Configuration;
using DuckOfDoom.Danmaku.Enemies.Factories;
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
		    
		    // Configuration
		    Container.Bind<IGameplayConfig>().To<GameplayConfig>().FromScriptableObjectResource("Config/CommonGameplayConfig").AsSingle().NonLazy();
		    Container.Bind<IPlayerSettings>().FromResolveGetter<IGameplayConfig>(c => c.PlayerSettings);
		    
		    Container.Bind<ISpawnersConfig>().To<SpawnersConfig>().FromScriptableObjectResource("Config/SpawnersConfig").AsSingle().NonLazy();
		    Container.Bind<ICommonConfig>().To<CommonConfig>().FromScriptableObjectResource("Config/CommonConfig").AsSingle().NonLazy();
		    
		    Container.Bind<ISpawnersFactory>().To<SpawnersFactory>().AsSingle();
		    Container.Bind<IProjectilesFactory>().To<ProjectilesFactory>().AsSingle();
		    
		    // Update systems
		    InstallCommonSystem<InitializePlayerSystem>();
		    InstallCommonSystem<CollisionProcessingSystem>();
		    
		    InstallUpdateSystem<GameTimeSystem>();
		    InstallUpdateSystem<CreateGameObjectsSystem>();
		    InstallUpdateSystem<InputSystem>();
		    InstallUpdateSystem<WispMovementSystem>();
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
			    .FromNewComponentOn(_ => _mainCamera.gameObject)
			    .AsSingle()
			    .NonLazy();
		    
			Container.Bind<ICamera>()
			    .FromMethod(_ => new UnityCamera(_mainCamera))
			    .AsSingle()
			    .NonLazy();
		    
		    Container.Bind<VisualizationSystem>().AsSingle();
		    
		    base.InstallBindings();
	    }
    }
}
