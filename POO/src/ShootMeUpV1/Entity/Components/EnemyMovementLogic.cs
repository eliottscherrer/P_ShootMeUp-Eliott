using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class EnemyMovementLogic : IMovementLogic
    {
        public Vector2 GetMovementDirection(Entity entity)
        {
            // If colliding with the player, stop moving
            if (entity.GetComponent<CollisionComponent>().IsCollidingWith(EntityManager.LocalPlayer))
                return Vector2.Zero;

            Vector2 playerPosition = EntityManager.LocalPlayer.Position;
            Vector2 directionToPlayer = playerPosition - entity.Position;

            directionToPlayer.Normalize();

            return directionToPlayer;
        }
    }
}
