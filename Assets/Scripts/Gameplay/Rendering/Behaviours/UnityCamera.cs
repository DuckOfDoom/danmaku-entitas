using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public interface ICamera
    {
        Vector3 ScreenToWorldPoint(Vector3 point);
    }
    
    public class UnityCamera : ICamera
    {
        private readonly Camera _camera;
        
        public UnityCamera(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector3 ScreenToWorldPoint(Vector3 point)
        {
            return _camera.ScreenToWorldPoint(point);
        }
    }
}