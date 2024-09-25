using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    class LocalPlayer : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        private const int COOLDOWN_TIME = 60;           // Counted in frames

        ////////////////////////////////// [ VARS ] //////////////////////////////////
        
        // Singleton instance 
        private static LocalPlayer _instance;
        public static LocalPlayer Instance => _instance ??= new LocalPlayer();

        // Stats
        private readonly float Speed = 8f;
        private float RemainingCooldown;

        // Constructor
        private LocalPlayer() : base(position: GameRoot.ScreenSize / 2, velocity: Vector2.Zero)
        {
            Texture = Visuals.Player;
            CollisionRadius = 10;
        }

        public override void Update(GameTime gameTime)
        {
            // Move the player and limit its movement to the screen (so it cannot go out of bounds)
            Velocity += Speed * GetMovementDirection();
            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);
            Console.WriteLine(Position.ToString());

            // Rotate towards the mouse cursor
            Vector2 aimDirection = GetAimDirection();
            Rotation = aimDirection.ToAngle();

            // Attack cooldown
            if (RemainingCooldown > 0)
                RemainingCooldown--;

            Velocity = Vector2.Zero;
        }

        private static Vector2 GetMovementDirection()
        {
            Vector2 direction = Vector2.Zero;

            if (InputManager.IsKeyDown(Keys.Left) || InputManager.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                direction.X += 1;
            if (InputManager.IsKeyDown(Keys.Up) || InputManager.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (InputManager.IsKeyDown(Keys.Down) || InputManager.IsKeyDown(Keys.S))
                direction.Y += 1;

            Console.WriteLine("Current direction: " + direction.ToString());

            if (direction != Vector2.Zero)
                return Vector2.Normalize(direction);
            
            return Vector2.Zero;
        }

        private static Vector2 GetAimDirection()
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

            // Direction from the player to the mouse
            Vector2 direction = mousePosition - LocalPlayer.Instance.Position; // LocalPlayer is optional but makes the code clearer

            if (direction != Vector2.Zero)
                return Vector2.Normalize(direction);

            return Vector2.Zero;
        }
    }
}
