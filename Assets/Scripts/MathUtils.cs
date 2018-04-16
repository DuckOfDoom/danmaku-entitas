using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public class MathUtils
    {
        public static Quaternion GetRandomRotation()
        {
            return Quaternion.AngleAxis(Random(0f, 360f), Vector3.forward);
        }

        public static Vector2 GetRandomDirection()
        {
            var randomAngle = Random(0f, Mathf.PI * 2);
            return new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        }

        public static float Random(float a, float b)
        {
            return UnityEngine.Random.Range(a, b);
        }
        
        public static int Random(int a, int b)
        {
            return UnityEngine.Random.Range(a, b);
        }
    }
}