using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    enum BulletType
    {
        Player,
        Enemy,
        SIZE
    }

    class Bullet : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        public const int DEFAULT_SPEED = 5;
        private const float SCALE = 0.065f;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        public readonly BulletType Type;

        //////////////////////////////////////////////////////////////////////////////

        public Bullet(Vector2 position, Vector2 velocity, BulletType type) : base(position, velocity)
        {
            Scale = SCALE;
            Texture = Visuals.SwordSlash;
            Rotation = Velocity.ToAngle();
            Rotation += MathHelper.PiOver2; // Add 90 degrees because the texture is not properly oriented
            CollisionRadius = 8;
            Type = type;
        }

        public override void Update(GameTime gameTime)
        {
            // Move the player and limit its movement to the screen (so it cannot go out of bounds)
            Position += Velocity;

            // Delete when out of bounds
            if (this.IsOutOfBounds()) // this is optional but I wrote it for clarity
                IsDestroyed = true;
        }

        // Events
        public override void OnCollision(Entity other)
        {
            throw new NotImplementedException();
        }
    }
}
