using JetBrains.Annotations;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Utility
{
    public class VisualizationController : MonoBehaviour
    {
        private VisualizeCollidersSystem _visualizeCollidersSystem;
	    
	    [UsedImplicitly]
        public void Awake()
        {
			var gameplayContext = Contexts.sharedInstance.gameplay;
			_visualizeCollidersSystem = new VisualizeCollidersSystem(gameplayContext);
        }
        
	    [UsedImplicitly]
	    public void OnPostRender()
	    {
		    _visualizeCollidersSystem.Execute();
	    }

	    [UsedImplicitly]
	    public void OnDestroy()
	    {
		    _visualizeCollidersSystem.TearDown();
	    }
    }
}
