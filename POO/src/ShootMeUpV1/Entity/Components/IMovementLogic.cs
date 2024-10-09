using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public interface IMovementLogic
    {
        Vector2 GetMovementDirection(Entity entity);
    }
}
