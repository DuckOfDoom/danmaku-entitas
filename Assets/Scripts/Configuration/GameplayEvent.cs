using System;
using UnityEngine;

namespace DuckOfDoom.Danmaku.Configuration
{
    public enum GameplayEventType
    {
        Undefined = 0,
        Spawn = 1,
        Debug = 99
    }


    [Serializable]
    public abstract class GameplayEvent
    {
        public long Tick; //{ get; private set; }
        public abstract GameplayEventType Type { get; }

        public GameplayEvent()
        {
            
        }

        protected GameplayEvent(long tick)
        {
            Tick = tick;
        }
    }

    [Serializable]
    public class DebugEvent : GameplayEvent
    {
        public string DebugValue; //{ get; private set; }

        public override GameplayEventType Type
        {
            get { return GameplayEventType.Debug; }
        }

        public DebugEvent(long tick, string debugValue) : base(tick)
        {
            DebugValue = debugValue;
        }
    }
    
    [Serializable]
    public class SpawnEvent : GameplayEvent
    {
        public Vector2 Position;// { get; private set; }

        public override GameplayEventType Type
        {
            get { return GameplayEventType.Spawn; }
        }

        public SpawnEvent(long tick, Vector2 position) : base(tick)
        {
            Position = position;
        }
    }

}