using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class MovementComponent : IUpdatableComponent
    {
        private Entity _entity;
        private readonly IMovementLogic _movementLogic;
        private float _speed;

        public MovementComponent(IMovementLogic movementLogic, float speed)
        {
            _movementLogic = movementLogic;
            _speed = speed;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 movementDirection = _movementLogic.GetMovementDirection(_entity);
            _entity.Velocity = movementDirection * _speed;
            _entity.Position += _entity.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Only bullets can go out of bounds
            if (_entity is not Bullet)
                LimitPositionToBounds();
        }

        private void LimitPositionToBounds()
        {
            Vector2 entitySize = _entity.GetComponent<RenderComponent>()?.Size ?? Vector2.Zero;

            _entity.Position = Vector2.Clamp(_entity.Position, Vector2.Zero, GameRoot.ScreenSize - entitySize);
        }
    }

}
