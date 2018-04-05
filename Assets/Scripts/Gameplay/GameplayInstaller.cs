using System;
using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class GameplayInstaller : MonoInstaller
    {
	    private const string UPDATE_BINDINGS_ID = "gameplay_update_bindings";
	    private const string FIXED_UPDATE_BINDINGS_ID = "gameplay_fixed_update_bindings";
	    
	    public override void InstallBindings()
	    {
		    Container.Bind<GameplayContext>().FromInstance(Contexts.sharedInstance.gameplay).AsSingle();
		    
		    // Update systems
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<InitializePlayerSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<AddViewSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<InputSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<PlayerMovementSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<ApplyVelocitySystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<RenderTransformSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<RenderSpriteSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<CollisionProcessingSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(UPDATE_BINDINGS_ID).To<InflictDamageSystem>().AsSingle();

		    // Update systems
		    Container.Bind<ISystem>().WithId(FIXED_UPDATE_BINDINGS_ID).To<GameTimeSystem>().AsSingle();
		    Container.Bind<ISystem>().WithId(FIXED_UPDATE_BINDINGS_ID).To<CollisionDetectionSystem>().AsSingle();

		    Container.BindInterfacesAndSelfTo<GameplayUpdateSystems>()
			    .FromMethod(context => new GameplayUpdateSystems(context.Container.ResolveIdAll<ISystem>(UPDATE_BINDINGS_ID)))
			    .AsSingle();
		    
		    Container.BindInterfacesAndSelfTo<GameplayFixedUpdateSystems>()
			    .FromMethod(context => new GameplayFixedUpdateSystems(context.Container.ResolveIdAll<ISystem>(FIXED_UPDATE_BINDINGS_ID)))
			    .AsSingle();
	    }
	    
	    private sealed class GameplayUpdateSystems : DebugSystems, IInitializable, ITickable, IDisposable
	    {
		    public GameplayUpdateSystems(IEnumerable<ISystem> systems) : base("GameplayUpdate")
		    {
			    foreach (var s in systems) { Add(s); }
		    }
		    
		    public void Tick() { this.Execute(); this.Cleanup(); }
		    public void Dispose() { this.TearDown(); }
	    }
	    
	    private sealed class GameplayFixedUpdateSystems : DebugSystems, IInitializable, IFixedTickable, IDisposable
	    {
		    public GameplayFixedUpdateSystems(IEnumerable<ISystem> systems) : base("GameplayFixedUpdate")
		    {
			    foreach (var s in systems)
			    {
				    Add(s);
			    }
		    }
		    
		    public void FixedTick() { this.Execute(); this.Cleanup(); }
		    public void Dispose() { this.TearDown(); }
	    }
    }

	public class EcsInstaller : MonoInstaller
	{
		private void InstallUpdateSystem<T>() where T : ISystem, IExecuteSystem
		{
			
		}
		
		private void InstallFixedUpdateSystem<T>()
		{
			
		}
	}
}
