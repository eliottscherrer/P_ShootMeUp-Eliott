using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShootMeUpV1
{
    abstract class Entity
    {
        // Visuals
        protected Texture2D Texture;
        protected Color TintColor = Color.White;

        // State and properties
        public Vector2 Position;
        public Vector2 Velocity;
        public float Rotation;                              // Rotation in radians
        public float CollisionRadius = 20f;                 // Circular collision shape radius
        public bool IsDestroyed = false;                    // Marks entity for destruction

        // Calculates entity size based on their texture
        public Vector2 Size => Texture?.Bounds.Size.ToVector2() ?? Vector2.Zero;

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
                    Size / 2f,              // Centered origin
                    1f,                     // No scaling
                    SpriteEffects.None,
                    0f                      // Depth
                );
            }
        }

        public bool IsOutOfBounds() => GameRoot.Viewport.Bounds.Contains(Position.ToPoint());
    }
}
