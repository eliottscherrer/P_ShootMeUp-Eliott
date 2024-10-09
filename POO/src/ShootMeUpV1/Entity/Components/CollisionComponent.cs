using Microsoft.Xna.Framework;
using System;

namespace ShootMeUpV1
{
    public class CollisionComponent : IUpdatableComponent
    {
        private Entity _entity;
        public float CollisionRadius { get; private set; }

        public CollisionComponent(float collisionRadius)
        {
            CollisionRadius = collisionRadius;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Entity other in EntityManager.GetEntities())
            {
                // Don't collide with itself or destroyed entities
                if (other == _entity || other.IsDestroyed)
                    continue;

                // TODO: Check for collision with the other entity
            }
        }

        public bool IsCollidingWith(Entity other)
        {
            throw new NotImplementedException();
        }
    }
}
