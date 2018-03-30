using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    // TODO: We need Zenject
    public class GameplayConfig
    {
        private List<GameplayEvent> _events;
        public const string ConfigDir = "Config";
        public const string EventsConfigFilename = "EventsConfig.json";

        public static GameplayConfig Load()
        {
            var path = string.Join("\\", new[] {ConfigDir, EventsConfigFilename});
            var eventsJson = Resources.Load<TextAsset>(path).text;
            return new GameplayConfig
            {
                _events = JsonUtility.FromJson<List<GameplayEvent>>(eventsJson)
            };
        }

        public static void GenerateSample(IEnumerable<GameplayEvent> events)
        {
            var path = string.Join("\\", new[]
            {
                Application.dataPath,
                "Resources",
                ConfigDir,
                EventsConfigFilename
            });
            
            File.WriteAllText(path, JsonUtility.ToJson(events, true));
        }
    }
}