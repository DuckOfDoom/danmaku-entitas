using System;
using Entitas;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class VisualizeCollidersSystem : IExecuteSystem, ITearDownSystem
    {
	    private readonly IGroup<GameplayEntity> _visualizationGroup;
	    
        private const int CircleResolution = 100;
        private const float CircleAngleDelta = (float)(2 * Math.PI / CircleResolution);
	    
	    public VisualizeCollidersSystem(GameplayContext context)
	    {
		    _visualizationGroup = context.GetGroup(
			    GameplayMatcher.AllOf(
				    GameplayMatcher.Collidable,
				    GameplayMatcher.Position
			    )
		    );
	    }

        private Material _material;
	    
        public void Execute()
        {
	        var entities = _visualizationGroup.GetEntities();
	        for (var i = 0; i < entities.Length; i++)
	        {
		        var e = entities[i];
                DrawCircle(e.position.Value, e.collidable.CollisionRadius, Color.green);
	        }
        }

	    private void DrawCircle(Vector2 center, float radius, Color color)
	    {
	        if (_material == null)
		        _material = new Material(Shader.Find("Hidden/Internal-Colored"));
		    
		    _material.SetPass(0);

		    var point = center + new Vector2(radius, 0);
		    var angle = CircleAngleDelta;
		    
		    for (var i = 0; i < CircleResolution; ++i)
		    {
			    var nextPoint = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
			    
                GL.Begin(GL.LINES);
			    GL.Color(color);
			    GL.Vertex3(point.x, point.y, 0);
			    GL.Vertex3(nextPoint.x, nextPoint.y, 0);
                GL.End();
			    
			    point = nextPoint;
			    angle += CircleAngleDelta;
		    }
	    }

	    public void TearDown()
	    {
		    if (_material != null)
		    {
			    UnityEngine.Object.Destroy(_material);
			    _material = null;
		    }
	    }
    }
}
