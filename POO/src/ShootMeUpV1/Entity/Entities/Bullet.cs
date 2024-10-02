using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    class Bullet : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        public const int DEFAULT_SPEED = 5;

        //////////////////////////////////////////////////////////////////////////////
        public Bullet(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            Scale = 0.1f;
            Texture = Visuals.SwordSlash;
            Rotation = Velocity.ToAngle();
            CollisionRadius = 8;
        }
        public override void Update(GameTime gameTime)
        {
            // Move the player and limit its movement to the screen (so it cannot go out of bounds)
            Position += Velocity;

            // Delete when out of bounds
            if (this.IsOutOfBounds()) // this is optional but I wrote it for clarity
                IsDestroyed = true;
        }
    }
}
