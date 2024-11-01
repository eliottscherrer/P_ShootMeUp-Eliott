using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace ShootMeUpV1
{
    public static class EntityManager
    {
        public static LocalPlayer LocalPlayer { get; private set; }

        private static readonly List<Entity> _entities = new();
        private static readonly List<Entity> _entitiesToRemove = new(); // Temporary list for removals
        private static readonly List<Entity> _entitiesToAdd = new();    // Temporary list for additions

        public static List<Entity> GetEntities() => _entities;

        public static List<T> GetEntitiesOfType<T>() where T : Entity => _entities.OfType<T>().ToList();

        public static void Initialize()
        {
            if (LocalPlayer == null)
            {
                LocalPlayer = new LocalPlayer(GameRoot.ScreenSize / 2);
                Add(LocalPlayer);
            }
        }

        public static void Add(Entity entity)
        {
            // Queue entity to be added during update cycle
            _entitiesToAdd.Add(entity);
        }

        public static void Update(GameTime gameTime)
        {
            // Add entities that were queued
            if (_entitiesToAdd.Count > 0)
            {
                _entities.AddRange(_entitiesToAdd);
                _entitiesToAdd.Clear();
            }

            foreach (Entity entity in _entities)
            {
                entity.Update(gameTime);
                foreach (IUpdatableComponent updatableComponent in entity.GetComponents<IUpdatableComponent>())
                {
                    updatableComponent.Update(gameTime);
                }

                if (entity.IsDestroyed)
                    _entitiesToRemove.Add(entity);
            }

            // Remove destroyed entities
            if (_entitiesToRemove.Count > 0)
            {
                foreach (Entity entity in _entitiesToRemove)
                    _entities.Remove(entity);

                _entitiesToRemove.Clear();
            }
        }

        // Draw all entities
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in _entities)
            {
                foreach (IDrawableComponent drawableComponent in entity.GetComponents<IDrawableComponent>())
                {
                    drawableComponent.Draw();
                }
            }
        }
    }
}
