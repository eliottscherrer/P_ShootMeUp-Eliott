using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    class Enemy : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        private const int ATTACK_COOLDOWN_TIME = 60;           // Counted in frames
        private const float SCALE = 0.25f;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        // Stats
        private readonly float Speed = 3f;
        private float RemainingCooldown; // Cooldown timer for attack

        // Constructor
        public Enemy(Vector2 position, float collisionRadius) : base(position, velocity: Vector2.Zero)
        {
            Texture = Visuals.BasicOni;
            CollisionRadius = collisionRadius;
            Scale = SCALE;
            RemainingCooldown = 0;
        }

        public override void Update(GameTime gameTime)
        {
            // Update cooldown
            if (RemainingCooldown > 0)
                RemainingCooldown--;

            // Get the player position and calculate the direction to the player
            Vector2 playerPosition = LocalPlayer.Instance.Position;
            Vector2 directionToPlayer = playerPosition - Position;

            // Only move towards the player we're not colliding with it
            if (directionToPlayer.LengthSquared() > LocalPlayer.Instance.CollisionRadius * LocalPlayer.Instance.CollisionRadius)
            {
                // Normalize the direction and scale it by speed
                directionToPlayer.Normalize();
                Velocity = directionToPlayer * Speed;

                // Move the enemy
                Position += Velocity;
                LimitPositionToBounds();
            }
            else
            {
                // Stop moving if close to the player
                Velocity = Vector2.Zero;
            }

            // Attack
            if (RemainingCooldown <= 0 && Vector2.Distance(Position, playerPosition) < CollisionRadius)
            {
                Attack();
                // Reset the cooldown after the attack
                RemainingCooldown = ATTACK_COOLDOWN_TIME;
            }
        }


        private void Attack()
        {
            // TODO: Implement attack logic here
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            // TODO: Add healthbar
        }
    }
}
