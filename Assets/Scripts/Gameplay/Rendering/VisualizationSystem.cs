using System;
using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using Entitas;
using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class VisualizationSystem : IExecuteSystem, ITearDownSystem
    {
	    [Inject] private IGameplayConfig Config { get; set; }
	    
	    private readonly IGroup<GameplayEntity> _visualizationGroup;
	    
        private const int CircleResolution = 100;
        private const float CircleAngleDelta = (float)(2 * Math.PI / CircleResolution);
	    
	    public VisualizationSystem(GameplayContext context)
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
		    if (_material == null)
		    {
			    _material = new Material(Shader.Find("Hidden/Internal-Colored"));
		    }
	        
	        _material.SetPass(0);
	        
	        var entities = _visualizationGroup.GetEntities();
	        for (var i = 0; i < entities.Length; i++)
	        {
		        var e = entities[i];
                DrawCircle(e.position.Value, e.collidable.CollisionRadius, Color.green);
		        
		        if (e.isPlayer)
			        DrawStar(e.position.Value, 0.2f, Color.cyan);
	        }

	        DrawBounds(Config.GameplayArea, Color.yellow);
	        DrawBounds(Config.ProjectileDestructionBounds, Color.red);
        }

	    private void DrawBounds(Bounds bounds, Color color)
	    {
		    DrawLine(new Vector2(bounds.min.x, bounds.min.y), new Vector2(bounds.max.x, bounds.min.y), color);
		    DrawLine(new Vector2(bounds.min.x, bounds.min.y), new Vector2(bounds.min.x, bounds.max.y), color);
		    DrawLine(new Vector2(bounds.min.x, bounds.max.y), new Vector2(bounds.max.x, bounds.max.y), color);
		    DrawLine(new Vector2(bounds.max.x, bounds.min.y), new Vector2(bounds.max.x, bounds.max.y), color);
	    }
	    
	    private void DrawStar(Vector2 center, float size, Color color)
	    {
		    var matrix = Matrix4x4.TRS(center, Quaternion.Euler(0, 0, 0), new Vector3(size, size, 0));
		    
		    var angle = 90 * Mathf.Deg2Rad;
		    var points = new List<Vector2>();
		    var delta = (float)Math.PI * 2 / 5;

		    for (var i = 0; i < 5; i++)
		    {
			    var point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
			    point = matrix.MultiplyPoint3x4(point);
			    points.Add(point);
			    angle += delta;
		    }

		    DrawLine(points[4], points[1], color);
		    DrawLine(points[1], points[3], color);
		    DrawLine(points[3], points[0], color);
		    DrawLine(points[0], points[2], color);
		    DrawLine(points[2], points[4], color);
	    }

	    private void DrawCircle(Vector2 center, float radius, Color color)
	    {
		    var point = center + new Vector2(radius, 0);
		    var angle = CircleAngleDelta;
		    
		    for (var i = 0; i < CircleResolution; ++i)
		    {
			    // TODO: Optimize sin and cos
			    var nextPoint = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
			    
			    DrawLine(point, nextPoint, color);
			    
			    point = nextPoint;
			    angle += CircleAngleDelta;
		    }
	    }

	    private void DrawLine(Vector2 start, Vector2 end, Color color)
	    {
		    GL.Begin(GL.LINES);
		    GL.Color(color);
		    GL.Vertex(new Vector2(start.x, start.y));
		    GL.Vertex(new Vector2(end.x, end.y));
		    GL.End();
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
