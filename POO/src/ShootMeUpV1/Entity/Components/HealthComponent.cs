using System;
using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class HealthComponent : IUpdatableComponent
    {
        private Entity _entity;
        private float _maxHealth;
        public float CurrentHealth { get; private set; }
        // TODO: Add invulnerability
        //       Add regeneration
        //       Add death events

        public HealthComponent(float maxHealth)
        {
            _maxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void TakeDamage(float amount)
        {
        }

        public void Heal(float amount)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
