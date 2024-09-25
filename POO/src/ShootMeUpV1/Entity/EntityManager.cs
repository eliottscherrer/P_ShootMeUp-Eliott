using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ShootMeUpV1
{
    static class EntityManager
    {
        private static readonly List<Entity> Entities = new();

        public static int Count => Entities.Count;

        // Thread-safe method to add Entities.
        public static void Add(Entity entity)
        {
            lock (Entities)
            {
                Entities.Add(entity);
            }
        }

        // Update all Entities and manage removals.
        public static void Update(GameTime gameTime)
        {
            // Lock to prevent modifications while updating
            lock (Entities)
            {
                foreach(Entity entity in Entities)
                    entity.Update(gameTime);

                // Remove all entities who need to be destroyed
                Entities.RemoveAll(entity => entity.IsDestroyed);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            // Lock to prevent modifications while drawing
            lock (Entities)
            {
                foreach (Entity entity in Entities)
                    entity.Draw(spriteBatch);
            }
        }
    }
}