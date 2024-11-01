using Configs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    public class Protection : Entity
    {
        public Protection(Vector2 position) : base(position)
        {
            AddComponent(new RenderComponent(Visuals.Protection, Configs.Protection.Scale));
            AddComponent(new CollisionComponent(Configs.Protection.CollisionRadius));
            AddComponent(new HealthComponent(Configs.Protection.BaseMaxHealth));
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                case Bullet bullet when bullet.Type == Bullet.BulletType.Enemy:
                    // Damage protection and destroy bullet on collision
                    GetComponent<HealthComponent>().TakeDamage(Configs.Enemy.BaseDamage);
                    bullet.IsDestroyed = true;
                    break;

                case Bullet bullet when bullet.Type == Bullet.BulletType.LocalPlayer:
                    // Go through the protection if the bullet is from LocalPlayer
                    break;

                case Bullet:
                    // Any other type of bullet just get destroyed
                    other.IsDestroyed = true;
                    break;

                default:
                    // TODO: Anything other than enemy's bullets stop moving
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Make protections red when damaged
            if (GetComponent<HealthComponent>().CurrentHealth < Configs.Protection.BaseMaxHealth / 2)
            {
                GetComponent<RenderComponent>().Color = Color.Red;
            }
        }
    }
}