using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    public class LocalPlayer : Entity, IDamageable
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        private const float ATTACK_COOLDOWN_TIME = 1f;           // Counted in seconds
        private const float SCALE = 0.25f;
        private const float COLLISION_RADIUS = 75f;

        private const float DEFAULT_SPEED = 300f;
        private const int DEFAULT_MAX_HEALTH = 100;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        // Stats
        private readonly float _speed;
        private float _bulletSpeed;
        private float _remainingCooldown;
        private int _health;
        public int Health => _health;

        //////////////////////////////////////////////////////////////////////////////

        // Constructor
        private LocalPlayer() : base(position: GameRoot.ScreenSize / 2, velocity: Vector2.Zero)
        {
            CollisionRadius = COLLISION_RADIUS;
            Texture = Visuals.Player;
            Scale = SCALE;

            _speed = DEFAULT_SPEED;
            _bulletSpeed = Bullet.DEFAULT_SPEED;
            _health = DEFAULT_MAX_HEALTH;
        }

        public override void Update(GameTime gameTime)
        {
            // Calculate the elapsed time since the last frame in seconds
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move the player and limit its movement to the screen (so it cannot go out of bounds)
            Velocity = _speed * GetMovementDirection();
            Position += Velocity * elapsedSeconds;
            LimitPositionToBounds();

            // Update attack cooldown
            if (_remainingCooldown > 0)
                _remainingCooldown -= elapsedSeconds;

            // Check for player actions
            if (_remainingCooldown <= 0 && InputManager.WasLeftButtonJustPressed())
                Attack();
        }

        // User actions
        public void Attack()
        {
            Vector2 aimDirection = GetAimDirection();

            // Create a bullet moving in the direction of the aim
            EntityManager.Add(new Bullet(Position - new Vector2(50, 50), aimDirection * _bulletSpeed, BulletType.Player));

            // Set the cooldown for the next attack
            _remainingCooldown = ATTACK_COOLDOWN_TIME;
        }

        // Events
        public override void OnCollision(Entity other)
        {
            // TODO: Collision logic
        }

        public void TakeDamage(int damage)
        {
            // TODO: Decrease player's health and check if they're dead after the hit
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
