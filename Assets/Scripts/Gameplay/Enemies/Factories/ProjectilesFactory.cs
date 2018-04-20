using UnityEngine;
using Zenject;

namespace DuckOfDoom.Danmaku.Enemies.Factories
{
    public interface IProjectilesFactory
    {
        GameplayEntity SpawnProjectile(Vector2 position, Vector2 linearVelocity);
    }
    
    public class ProjectilesFactory : IProjectilesFactory
    {
        [Inject] private GameplayContext _context;
        
        public GameplayEntity SpawnProjectile(Vector2 position, Vector2 linearVelocity)
        {
            var e = _context.CreateEntity();
            e.isEnemy = true;
            e.AddPosition(position);
            e.AddCollidable(0.1f);
            e.AddDamageDealer(1f);
            e.AddVelocity(linearVelocity, 0);

            return e;
        }
    }
}