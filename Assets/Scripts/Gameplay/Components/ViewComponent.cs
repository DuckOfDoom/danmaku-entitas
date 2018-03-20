using Entitas;
using UnityEngine; 

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class ViewComponent : IComponent
    {
        public GameObject GameObject { get; set; }
    }
}