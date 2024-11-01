using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class EnemyMovementLogic : IMovementLogic
    {
        public Vector2 GetMovementDirection(Entity entity)
        {
            CollisionComponent collisionComponent = entity.GetComponent<CollisionComponent>();
            if (collisionComponent != null)
            {
                // If colliding with the player, stop moving
                if (collisionComponent.IsCollidingWith(EntityManager.LocalPlayer))
                    return Vector2.Zero;

                // Check for collision with a protection object
                if (collisionComponent.IsCollidingWith(typeof(Protection)))
                {
                    // Calculate a direction perpendicular to the protection
                    Vector2 protectionAvoidanceDirection = Vector2.Zero;

                    foreach (Entity protection in EntityManager.GetEntitiesOfType<Protection>())
                    {
                        if (collisionComponent.IsCollidingWith(protection))
                        {
                            // Get direction away from the protection
                            Vector2 directionFromProtection = entity.Position - protection.Position;
                            directionFromProtection.Normalize();

                            // Accumulate directions to avoid all nearby protections
                            protectionAvoidanceDirection += directionFromProtection;
                        }
                    }

                    if (protectionAvoidanceDirection != Vector2.Zero)
                    {
                        protectionAvoidanceDirection.Normalize();
                        return protectionAvoidanceDirection; // Move away from protection
                    }
                }
            }

            // Move towards the player if no collision with protection
            Vector2 playerPosition = EntityManager.LocalPlayer.Position;
            Vector2 directionToPlayer = playerPosition - entity.Position;

            directionToPlayer.Normalize();

            return directionToPlayer;
        }
    }
}
