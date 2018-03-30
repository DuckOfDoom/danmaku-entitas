using Entitas;

namespace DuckOfDoom.Danmaku
{
    [Gameplay]
    public class DamageDealer : IComponent
    {
        public float Damage { get; set; }
    }
    
    [Gameplay]
    public class Damage : IComponent
    {
        public float Amount { get; set; }
    }
}