using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class BulletMovementLogic : IMovementLogic
    {
        // Bullets maintain their initial velocity; they do not change direction.
        public Vector2 GetMovementDirection(Entity entity) => entity.Velocity;
    }

}
