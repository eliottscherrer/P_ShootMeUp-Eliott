using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShootMeUpV1
{
    abstract class Entity
    {
        // Visuals
        protected Texture2D Texture;
        protected float Scale = 1f;
        protected Color TintColor = Color.White;
        protected bool ShowDebugBounds = true;

        // State and properties
        public Vector2 Position;
        public Vector2 Velocity;
        public float Rotation;                              // Rotation in radians
        public float CollisionRadius = 20f;                 // Circular collision shape radius
        public bool IsDestroyed = false;                    // Marks entity for destruction

        // Calculates entity size based on their texture and scale
        public Vector2 Size => (Texture?.Bounds.Size.ToVector2() ?? Vector2.Zero) * Scale;

        // Default constructor
        public Entity(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        // Update method to be implemented by child classes
        public abstract void Update(GameTime gameTime);

        // Draw the entity on screen using SpriteBatch
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(
                    Texture,
                    Position,
                    null,                   // No source rectangle
                    TintColor,
                    Rotation,
                    Size / 2f,              // Centered origin (half of the scaled size)
                    Scale,
                    SpriteEffects.None,
                    0f                      // Depth
                );
            }

            if (ShowDebugBounds)
            {
                // Calculate the rectangle representing the entity's bounds (centered on Position)
                Rectangle debugRect = new Rectangle(
                    (int)(Position.X - (Size.X / 2)),
                    (int)(Position.Y - (Size.Y / 2)),
                    (int)Size.X,
                    (int)Size.Y
                );

                Visuals.DrawRectangle(spriteBatch, debugRect, Color.Red);
            }
        }

        public bool IsOutOfBounds() => GameRoot.Viewport.Bounds.Contains(Position.ToPoint());
    }
}
