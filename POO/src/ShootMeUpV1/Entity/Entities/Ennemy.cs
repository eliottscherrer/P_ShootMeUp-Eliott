using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    class Ennemy : Entity
    {
        ///////////////////////////////// [ CONSTS ] /////////////////////////////////

        private const int ATTACK_COOLDOWN_TIME = 60;           // Counted in frames
        private const float SCALE = 0.25f;

        ////////////////////////////////// [ VARS ] //////////////////////////////////

        // Stats
        private readonly float Speed = 3f;
        private float RemainingCooldown; // Cooldown timer for attack

        // Constructor
        public Ennemy(Vector2 position, float collisionRadius) : base(position, velocity: Vector2.Zero)
        {
            Texture = Visuals.BasicOni;
            CollisionRadius = collisionRadius;
            Scale = SCALE;
            RemainingCooldown = 0;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
