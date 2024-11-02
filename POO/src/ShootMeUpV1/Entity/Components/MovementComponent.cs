using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class MovementComponent : IUpdatableComponent
    {
        private Entity _entity;
        private readonly IMovementLogic _movementLogic;
        private float _speed;
        public bool CanMove;

        public MovementComponent(IMovementLogic movementLogic, float speed)
        {
            _movementLogic = movementLogic;
            _speed = speed;

            CanMove = true;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Update(GameTime gameTime)
        {
            if (!CanMove)
                return;

            // Move
            Vector2 velocity = _movementLogic.GetMovementDirection(_entity) * _speed;
            _entity.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

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
