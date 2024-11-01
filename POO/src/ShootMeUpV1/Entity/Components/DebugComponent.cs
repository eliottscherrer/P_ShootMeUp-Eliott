using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace ShootMeUpV1
{
    public class DebugComponent : IDrawableComponent
    {
        private Entity _entity;
        private bool isDebugModeEnabled = true;

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void ToggleDebugMode()
        {
            isDebugModeEnabled = !isDebugModeEnabled;
        }

        public void Draw()
        {
            if (!isDebugModeEnabled) return;

            CollisionComponent collisionComponent = _entity.GetComponent<CollisionComponent>();
            if (collisionComponent != null)
            {
                float radius = collisionComponent.CollisionRadius;
                Vector2 position = _entity.Position + _entity.GetComponent<RenderComponent>().Size / 2;

                int segments = 50; // Nombre de segments pour approximer le cercle
                float increment = MathF.PI * 2.0f / segments;

                for (int i = 0; i < segments; i++)
                {
                    float angle1 = i * increment;
                    float angle2 = (i + 1) * increment;

                    Vector2 point1 = position + new Vector2(MathF.Cos(angle1), MathF.Sin(angle1)) * radius;
                    Vector2 point2 = position + new Vector2(MathF.Cos(angle2), MathF.Sin(angle2)) * radius;

                    // Dessine une ligne entre point1 et point2
                    Visuals.DrawLine(point1, point2, Color.Red * 0.5f);
                }
            }
        }
    }
}
