using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{

    public class Bullet : Entity
    {
        public enum Type
        {
            LocalPlayer,
            Enemy,
            SIZE
        }

        public Bullet(Vector2 position, Vector2 velocity) : base(position)
        {
            Velocity = velocity;
            Rotation = velocity.ToAngle() + MathHelper.PiOver2;             // Adjust with Pi/2 because the texture is pointed up

            AddComponent(new RenderComponent(Visuals.SwordSlash, 0.065f));  // Texture
            AddComponent(new CollisionComponent(6f));                       // Collision radius

            // TODO: Debug infos
        }

        public override void Update(GameTime gameTime)
        {
            // Move
            Position += Velocity;

            // TODO: Destroy if it goes out of bounds
        }

        public override void OnCollision(Entity other)
        {
            throw new NotImplementedException();
        }
    }
}
