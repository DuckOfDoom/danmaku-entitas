using System.Collections.Generic;
using DuckOfDoom.Danmaku.Configuration;
using UnityEditor;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Editor
{
    public class ConfigTools : UnityEditor.Editor
    {
        [MenuItem("Tools/Generate Sample Config")]
        public static void GenerateSampleConfig()
        {
            var events = new List<GameplayEvent>();

            for (var i = 0; i < 1000; i++)
            {
                if (i % 30 == 0)
                {
                    events.Add(new DebugEvent(i, string.Format("this is debug event on {0}", i)));
                }
                else if (i % 50 == 0)
                {
                    events.Add(new SpawnEvent(i, new Vector2(i, -i)));
                }
            }
                
                
            GameplayConfig.GenerateSample(events);
        }
        
    }
}