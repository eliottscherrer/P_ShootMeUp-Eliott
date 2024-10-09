using Microsoft.Xna.Framework;

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

                // Check for collision with the other entity
                CollisionComponent otherCollisionComponent = other.GetComponent<CollisionComponent>();
                if (otherCollisionComponent != null && IsCollidingWith(other))
                {
                    // Notify both entities of the collision
                    _entity.OnCollision(other);
                    other.OnCollision(_entity);
                }
            }
        }

        public bool IsCollidingWith(Entity other)
        {
            Vector2 thisCenter = _entity.Position + _entity.GetComponent<RenderComponent>().Size / 2;
            Vector2 otherCenter = other.Position + other.GetComponent<RenderComponent>().Size / 2;

            float distanceSquared = Vector2.DistanceSquared(thisCenter, otherCenter);
            float combinedRadii = this.CollisionRadius + other.GetComponent<CollisionComponent>().CollisionRadius;

            return distanceSquared <= combinedRadii * combinedRadii;
        }
    }
}
