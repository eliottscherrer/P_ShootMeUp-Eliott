using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 position) : base(position)
        {
            // TODO: Config files
            AddComponent(new MovementComponent(new EnemyMovementLogic(), Configs.Enemy.Speed));
            AddComponent(new RenderComponent(Visuals.BasicOni, Configs.Enemy.Scale));
            AddComponent(new CollisionComponent(Configs.Enemy.CollisionRadius));

            // TODO: Health
            //       Health bar
            //       Debug infos
        }
    }
}
