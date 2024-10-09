using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 position) : base(position)
        {
            // TODO: Config files
            AddComponent(new MovementComponent(new EnemyMovementLogic(), 100f));    // Speed
            AddComponent(new RenderComponent(Visuals.BasicOni, 0.25f));             // Enemy texture
            AddComponent(new CollisionComponent(75f));                              // Collision radius

            // TODO: Health
            //       Health bar
            //       Debug infos
        }
    }
}
