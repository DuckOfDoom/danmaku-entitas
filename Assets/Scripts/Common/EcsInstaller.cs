using System;
using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    /// <summary>
    /// 	Generic installer to install ECS-related stuff like systems and system groups to help use Zenject's ITickable interfaces with Entitas' systems.
    ///     Basically auto installs "Systems" or "DebugSystems" objects that aggregate ECS systems and run their Execute methods through ITickable interfaces.
    /// 
    ///     For all systems Initialize() is called on Zenject Initialize() and TearDown() is called on Zenject Dispose()
    /// </summary>
    public abstract class EcsInstaller : MonoInstaller
    {
        private string CommonSystemsId { get { return string.Format("{0}_common_systems", InstanceId); } }
        private string UpdateSystemsId { get { return string.Format("{0}_update_systems", InstanceId); } }
        private string FixedUpdateSystemsId { get { return string.Format("{0}_fixed_update_systems", InstanceId); } }

        private string InstanceId { get { return string.Format("{0}_{1}", GetType().Name, GetInstanceID()); } }

        /// <summary>
        /// 	Call this at the end of Install Bindings override so that we can bind our Systems classes. 
        /// 
        ///     This will create "systems" objects to 
        /// </summary>
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CommonSystems>()
                .FromMethod(context => new CommonSystems(CommonSystemsId, context.Container.ResolveIdAll<ISystem>(CommonSystemsId)))
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<UpdateSystems>()
                .FromMethod(context => new UpdateSystems(UpdateSystemsId, context.Container.ResolveIdAll<ISystem>(UpdateSystemsId)))
                .AsSingle();
		    
            Container.BindInterfacesAndSelfTo<FixedUpdateSystems>()
                .FromMethod(context => new FixedUpdateSystems(FixedUpdateSystemsId, context.Container.ResolveIdAll<ISystem>(FixedUpdateSystemsId)))
                .AsSingle();
        }
        
        /// <summary>
        ///     Installs a common system, without per-frame routines
        /// </summary>
        protected void InstallCommonSystem<T>() where T : ISystem
        {
		    Container.Bind<ISystem>().WithId(CommonSystemsId).To<T>().AsSingle();
        }
        
        /// <summary>
        ///     Install an Update system binding into container
        /// </summary>
        protected void InstallUpdateSystem<T>() where T : ISystem, IExecuteSystem
        {
		    Container.Bind<ISystem>().WithId(UpdateSystemsId).To<T>().AsSingle();
        }

        /// <summary>
        ///     Install a FixedUpdate system binding into container
        /// </summary>
        protected void InstallFixedUpdateSystem<T>() where T : ISystem, IExecuteSystem
        {
		    Container.Bind<ISystem>().WithId(FixedUpdateSystemsId).To<T>().AsSingle();
        }
        
        private class CommonSystems : DebugSystems, IInitializable, IDisposable
        {
            public CommonSystems(string id, IEnumerable<ISystem> systems) : base(id)
            {
                foreach (var s in systems) { Add(s); }
            }

            public sealed override Systems Add(ISystem system)
            {
                return base.Add(system);
            }

            // Initialize is handled via Systems.Initialize
            public void Dispose() { this.TearDown(); }
        }
		
        private sealed class UpdateSystems : CommonSystems, ITickable
        {
            public UpdateSystems(string id, IEnumerable<ISystem> systems) : base(id, systems) { }
            public void Tick() { Execute(); Cleanup(); }
        }
	    
        private sealed class FixedUpdateSystems : CommonSystems, IFixedTickable
        {
            public FixedUpdateSystems(string id, IEnumerable<ISystem> systems) : base(id, systems) { }
            public void FixedTick() { Execute(); Cleanup(); }
        }
    }
}