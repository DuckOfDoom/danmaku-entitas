using Entitas;
using UnityEngine; 

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class GameObjectComponent : IComponent
    {
        public GameObject Instance { get; set; }
    }
}