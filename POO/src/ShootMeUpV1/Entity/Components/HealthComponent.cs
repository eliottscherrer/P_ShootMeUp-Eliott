using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootMeUpV1
{
    public class HealthComponent : IUpdatableComponent, IDrawableComponent
    {
        private Entity _entity;
        private float _maxHealth;

        // Healthbar
        private Texture2D _backgroundTexture;
        private Texture2D _foregroundTexture;

        public float CurrentHealth { get; private set; }
        // TODO: Add invulnerability
        //       Add regeneration
        //       Add death events

        public HealthComponent(float maxHealth)
        {
            _maxHealth = maxHealth;
            CurrentHealth = maxHealth;

            // Create simple textures for the health bar (background and foreground)
            _backgroundTexture = new Texture2D(GameRoot.Instance.GraphicsDevice, 1, 1);
            _backgroundTexture.SetData(new[] { Color.Gray });

            _foregroundTexture = new Texture2D(GameRoot.Instance.GraphicsDevice, 1, 1);
            _foregroundTexture.SetData(new[] { Color.Red });
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                // TODO: Trigger death event
                _entity.IsDestroyed = true;
            }

            // TODO: Check if health is below a certain threshold and trigger an event
            //       (for abilities that boosts damage when health is low etc)
        }

        public void Heal(float amount)
        {
            if (amount <= 0) return;

            // Cannot go over max health
            CurrentHealth = Math.Min(CurrentHealth + amount, _maxHealth);
        }

        public void Update(GameTime gameTime)
        {
            // TODO: Invulnerability
            //       Regeneration
        }

        public void Draw()
        {
            // Design constant
            const float height = 10f;

            // Position the health bar above the entity
            float entityWidth = _entity.GetComponent<RenderComponent>().Size.X;
            Vector2 offset = new Vector2(0f, -20f);
            Vector2 position = _entity.Position + offset;

            // Draw background (full bar)
            GameRoot.SpriteBatch.Draw(_backgroundTexture, new Rectangle((int)position.X, (int)position.Y, (int)entityWidth, (int)height), Color.Gray);

            // Draw foreground (health proportion)
            float healthPercentage = CurrentHealth / _maxHealth;
            int healthBarWidth = (int)(entityWidth * healthPercentage);
            GameRoot.SpriteBatch.Draw(_foregroundTexture, new Rectangle((int)position.X, (int)position.Y, healthBarWidth, (int)height), Color.Red);
        }
    }
}
