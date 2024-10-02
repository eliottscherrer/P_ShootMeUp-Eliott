using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ShootMeUpV1
{
    static class EntityManager
    {
        private static readonly List<Entity> Entities = new();
        private static readonly List<Entity> EntitiesToRemove = new(); // Temporary list for removals
        private static readonly List<Entity> EntitiesToAdd = new();    // Temporary list for additions

        public static int Count => Entities.Count;

        public static void Add(Entity entity) => EntitiesToAdd.Add(entity);

        /// <summary>
        /// Update all Entities and manage removals
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            // Clear then populate the temporary lists
            EntitiesToRemove.Clear();
            Entities.AddRange(EntitiesToAdd);
            EntitiesToAdd.Clear();

            // Update entities
            foreach (Entity entity in Entities)
            {
                entity.Update(gameTime);

                if (entity.IsDestroyed)
                    EntitiesToRemove.Add(entity); // Mark entity for removal
            }

            // Now remove all entities that are marked for destruction
            foreach (Entity entity in EntitiesToRemove)
                Entities.Remove(entity);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in Entities)
                entity.Draw(spriteBatch);
        }
    }
}
