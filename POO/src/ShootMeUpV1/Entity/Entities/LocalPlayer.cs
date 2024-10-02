using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    class LocalPlayer : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        private const int ATTACK_COOLDOWN_TIME = 60;           // Counted in frames
        private const float SCALE = 0.25f;
        private const float COLLISION_RADIUS = 75f;

        ////////////////////////////////// [ VARS ] //////////////////////////////////
        
        // Singleton instance 
        private static LocalPlayer _instance;
        public static LocalPlayer Instance => _instance ??= new LocalPlayer();

        // Stats
        private readonly float Speed = 8f;
        private int BulletSpeed = Bullet.DEFAULT_SPEED;
        private float RemainingCooldown;

        // Constructor
        private LocalPlayer() : base(position: GameRoot.ScreenSize / 2, velocity: Vector2.Zero)
        {
            CollisionRadius = COLLISION_RADIUS;
            Texture = Visuals.Player;
            Scale = SCALE;
        }

        public override void Update(GameTime gameTime)
        {
            // Move the player and limit its movement to the screen (so it cannot go out of bounds)
            Velocity = Vector2.Zero;
            Velocity += Speed * GetMovementDirection();
            Position += Velocity;
            LimitPositionToBounds();

            // Check for player actions
            if(InputManager.WasLeftButtonJustPressed())
                Attack();

            // Attack cooldown
            if (RemainingCooldown > 0)
                RemainingCooldown--;
        }

        // Player actions
        private void Attack()
        {
            Vector2 aimDirection = GetAimDirection();

            // Create a bullet moving in the direction of the aim
            EntityManager.Add(new Bullet(Position, aimDirection * BulletSpeed));

            // Set the cooldown for the next attack
            RemainingCooldown = ATTACK_COOLDOWN_TIME;
        }

        // Input infos
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

            if (direction != Vector2.Zero)
                return Vector2.Normalize(direction);
            
            return Vector2.Zero;
        }

        private static Vector2 GetAimDirection()
        {
            // Direction from the player to the mouse
            Vector2 direction = InputManager.MousePosition - LocalPlayer.Instance.Position; // LocalPlayer is optional but makes the code clearer

            if (direction != Vector2.Zero)
                return Vector2.Normalize(direction);

            return Vector2.Zero;
        }
    }
}
