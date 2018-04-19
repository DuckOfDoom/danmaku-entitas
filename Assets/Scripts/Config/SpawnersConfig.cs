using System;
using System.Collections.Generic;
using DuckOfDoom.Danmaku.Enemies.Settings;
using JetBrains.Annotations;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    public interface ISpawnersConfig
    {
        ISpawnerSettings Get(string id);
    }
    
    [CreateAssetMenu(fileName = "SpawnersConfig")]
    public class SpawnersConfig : ScriptableObject, ISpawnersConfig
    {
        [SerializeField] private List<Entry> _entries = new List<Entry>();
        private readonly Dictionary<string, ISpawnerSettings> _cache = new Dictionary<string, ISpawnerSettings>();
        
        [Serializable]
        private class Entry
        {
            [SerializeField] private string _id;
            [SerializeField] private SpawnerSettings _settings;
            
            public string Id { get { return _id; } }
            public ISpawnerSettings Settings { get { return _settings; } }
        }
        

        [UsedImplicitly]
        private void OnEnable()
        {
            foreach (var e in _entries)
                _cache.Add(e.Id, e.Settings);
        }
        
        public ISpawnerSettings Get(string id)
        {
            return _cache[id];
        }
    }
}