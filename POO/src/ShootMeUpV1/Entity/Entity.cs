using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShootMeUpV1
{
    abstract class Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////
        
        protected const float DEFAULT_COLLISION_RADIUS = 20f;
        protected const float DEFAULT_SCALE = 1f;
        private const bool SHOW_DEBUG_BOUNDS = true;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        // Visuals
        protected Texture2D Texture { get; set; }
        protected float Scale { get; set; }
        protected Color TintColor { get; set; } = Color.White; // We set it here since Colors can't be consts
        protected bool ShowDebugBounds { get; private set; }

        // State and properties
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public float Rotation { get; protected set; }         // Rotation in radians
        public float CollisionRadius { get; protected set; }  // Circular collision shape radius
        public bool IsDestroyed { get; protected set; }       // Marks entity for destruction

        // Calculates entity size based on their texture and scale
        public Vector2 Size => (Texture?.Bounds.Size.ToVector2() ?? Vector2.Zero) * Scale;

        // Default constructor
        public Entity(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;

            CollisionRadius = DEFAULT_COLLISION_RADIUS;
            ShowDebugBounds = SHOW_DEBUG_BOUNDS;
            Scale = DEFAULT_SCALE;
            IsDestroyed = false;
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
                    Vector2.Zero,           // Centered origin (half of the scaled size)
                    Scale,
                    SpriteEffects.None,
                    0f                      // Depth
                );
            }

            if (ShowDebugBounds)
            {
                Visuals.DrawRectangle(spriteBatch, Position, Size, Rotation, Color.Red);
            }
        }

        // Position limitations
        public bool IsOutOfBounds() => !GameRoot.Viewport.Bounds.Contains(Position.ToPoint());

        protected void LimitPositionToBounds()
        {
            Position = Vector2.Clamp(Position, Vector2.Zero, GameRoot.ScreenSize - Size);
        }

        // Collisions
        public bool IsCollidingWith(Entity other)
        {
            throw new NotImplementedException();
        }

        public abstract void OnCollision(Entity other);
    }
}