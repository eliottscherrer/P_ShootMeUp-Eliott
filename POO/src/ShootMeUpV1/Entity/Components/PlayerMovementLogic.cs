using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ShootMeUpV1
{
    public class PlayerMovementLogic : IMovementLogic
    {
        public Vector2 GetMovementDirection(Entity entity)
        {
            Vector2 direction = Vector2.Zero;
            if (InputManager.IsKeyDown(Keys.Left) || InputManager.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                direction.X += 1;
            if (InputManager.IsKeyDown(Keys.Up) || InputManager.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (InputManager.IsKeyDown(Keys.Down) || InputManager.IsKeyDown(Keys.S))
                direction.Y += 1;

            return direction.Length() > 0 ? Vector2.Normalize(direction) : Vector2.Zero;
        }
    }
}
