using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 position) : base(position)
        {
            // TODO: Config files
            AddComponent(new MovementComponent(new EnemyMovementLogic(), Configs.Enemy.BaseSpeed));
            AddComponent(new RenderComponent(Visuals.BasicOni, Configs.Enemy.Scale));
            AddComponent(new CollisionComponent(Configs.Enemy.CollisionRadius));
            AddComponent(new HealthComponent(Configs.Enemy.BaseMaxHealth));

            // TODO: Health
            //       Health bar
            //       Debug infos
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                // Only take damage from the player's bullets
                case Bullet bullet when bullet.Type == Bullet.BulletType.LocalPlayer:
                    bullet.IsDestroyed = true;
                    GetComponent<HealthComponent>().TakeDamage(Configs.Player.BaseDamage); // TODO: Add variable damage amount depending on the weapon of the player etc.
                    break;

                default: break;
            }
        }
    }
}
