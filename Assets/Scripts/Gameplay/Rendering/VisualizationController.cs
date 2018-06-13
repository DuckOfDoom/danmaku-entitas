using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku.Utility
{
	/// <summary>
	/// 	Controller for camera to visualize colliders via Visualize colliders system.
	/// </summary>
    public class VisualizationController : MonoBehaviour
    {
	    [Inject] private VisualizationSystem VisualizeSystem { get; set; }
	    
	    [UsedImplicitly]
	    public void OnPostRender()
	    {
		    VisualizeSystem.Execute();
	    }

	    [UsedImplicitly]
	    public void OnDestroy()
	    {
		    VisualizeSystem.TearDown();
	    }
    }
}
