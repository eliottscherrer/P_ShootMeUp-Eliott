using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public interface IUpdatableComponent : IComponent
    {
        void Update(GameTime gameTime);
    }
}