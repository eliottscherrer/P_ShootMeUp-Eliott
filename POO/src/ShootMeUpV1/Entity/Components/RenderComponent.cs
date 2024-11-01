using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootMeUpV1
{
    public class RenderComponent : IDrawableComponent
    {
        private Entity _entity;
        private Texture2D _texture;
        private float _scale;
        public Color Color;
        public Vector2 Size => (_texture?.Bounds.Size.ToVector2() ?? Vector2.Zero) * _scale;

        public RenderComponent(Texture2D texture, float scale = 1f, Color? color = null)
        {
            _texture = texture;
            _scale = scale;
            Color = color ?? Color.White;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Draw()
        {
            if (_texture != null)
            {
                GameRoot.SpriteBatch.Draw(_texture, _entity.Position, null, Color, _entity.Rotation, Vector2.Zero, _scale, SpriteEffects.None, 0f);
            }
        }
    }
}
