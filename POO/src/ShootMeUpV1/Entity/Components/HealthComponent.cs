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
    }
}
