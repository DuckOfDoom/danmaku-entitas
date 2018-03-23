using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public abstract class CommonController : MonoBehaviour
    {
        protected Systems _updateSystems;
        protected Systems _fixedUpdateSystems;

        protected abstract void SetUp();
        
        private void Awake()
        {
            _updateSystems = new DebugSystems("Update" + GetType().Name);
            _fixedUpdateSystems = new DebugSystems("FixedUpdate" + GetType().Name);
            SetUp();
            
            _updateSystems.Initialize();
            _fixedUpdateSystems.Initialize();
        }

        private void Update()
        {
            _updateSystems.Execute();
            _updateSystems.Cleanup();
        }
        
        private void FixedUpdate()
        {
            _fixedUpdateSystems.Execute();
            _fixedUpdateSystems.Cleanup();
        }

        private void OnDestroy()
        {
            _updateSystems.TearDown();
            _fixedUpdateSystems.TearDown();
        }
    }
}