using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    public enum BulletType
    {
        Player,
        Enemy,
        SIZE
    }

    public class Bullet : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        public const float DEFAULT_SPEED = 5f;
        public const int DEFAULT_DAMAGE = 10;
        private const float SCALE = 0.065f;
        private const float COLLISION_RADIUS = 3f;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        public readonly BulletType Type;
        public readonly int Damage;

        //////////////////////////////////////////////////////////////////////////////

        public Bullet(Vector2 position, Vector2 velocity, BulletType type, int damage = DEFAULT_DAMAGE) : base(position, velocity)
        {
            Scale = SCALE;
            CollisionRadius = COLLISION_RADIUS;
            Texture = Visuals.SwordSlash;
            Rotation = Velocity.ToAngle();
            Rotation += MathHelper.PiOver2; // Add 90 degrees because the texture is not properly oriented
            Type = type;
            Damage = damage;
        }

        public override void Update(GameTime gameTime)
        {
            // Move
            Position += Velocity;

            // Delete when out of bounds
            if (this.IsOutOfBounds()) // "this" is optional but I wrote it for clarity
                IsDestroyed = true;
        }

        // Events
        public override void OnCollision(Entity other)
        {
            // Handle the collision based on the type of the other entity
            // Only considers bullets that aren't from allies
            switch (other)
            {
                case LocalPlayer player when this.Type == BulletType.Enemy:
                    this.IsDestroyed = true;
                    player.TakeDamage(Damage);
                    break;

                case Enemy enemy when this.Type == BulletType.Player:
                    this.IsDestroyed = true;
                    enemy.TakeDamage(Damage);
                    break;

                case Bullet bullet:
                    this.IsDestroyed = true;
                    bullet.IsDestroyed = true;
                    break;
            }
        }
    }
}
