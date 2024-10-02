﻿#define CONSOLE_DEBUG

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

            HandleCollisions();

            // Now remove all entities that are marked for destruction
            foreach (Entity entity in EntitiesToRemove)
                Entities.Remove(entity);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in Entities)
                entity.Draw(spriteBatch);
        }

        private static void HandleCollisions()
        {
            // Simple brute-force collision detection (can be optimized)
            for (int i = 0; i < Entities.Count; i++)
            {
                for (int j = i + 1; j < Entities.Count; j++)
                {
                    Entity entityA = Entities[i];
                    Entity entityB = Entities[j];

                    // Check if the entities collide
                    if (entityA.IsCollidingWith(entityB))
                    {
                        #if CONSOLE_DEBUG
                        // Debug output with color coding
                        ConsoleColor colorA = GetColorForType(entityA.GetType().Name);
                        ConsoleColor colorB = GetColorForType(entityB.GetType().Name);

                        Console.ForegroundColor = colorA;
                        Console.Write(entityA.GetType().Name);

                        Console.ResetColor();
                        Console.Write(" collisionne un ");

                        Console.ForegroundColor = colorB;
                        Console.WriteLine(entityB.GetType().Name);

                        Console.ResetColor();
                        #endif

                        entityA.OnCollision(entityB);
                        entityB.OnCollision(entityA);
                    }
                }
            }
        }

        #if CONSOLE_DEBUG
        private static ConsoleColor GetColorForType(string entityType) => entityType switch
        {
            "LocalPlayer" => ConsoleColor.Green,
            "Enemy" => ConsoleColor.Red,
            "Bullet" => ConsoleColor.Cyan,
            _ => ConsoleColor.White
        };
        #endif
    }
}
