using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    public class Protection : Entity
    {
        public Protection(Vector2 position, float rotation) : base(position)
        {
            Rotation = rotation;

            AddComponent(new RenderComponent(Visuals.Protection, Configs.Protection.Scale));
            AddComponent(new CollisionComponent(Configs.Protection.CollisionRadius));
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                case Bullet:
                    other.IsDestroyed = true;
                    break;

                default:
                    // TODO: Stop other's movements
                    break;
            }
        }
    }
}