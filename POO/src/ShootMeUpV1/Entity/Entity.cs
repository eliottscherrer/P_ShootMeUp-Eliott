using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootMeUpV1
{
    public class Entity
    {
        private readonly List<IComponent> _components = new List<IComponent>();
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Rotation { get; set; } // In radians
        public bool IsDestroyed { get; set; }

        public Entity(Vector2 position)
        {
            Position = position;
            Velocity = Vector2.Zero;
            IsDestroyed = false;
        }

        public void AddComponent(IComponent component)
        {
            component.Initialize(this);
            _components.Add(component);
        }

        // Get a specific component by type T
        public T GetComponent<T>() where T : IComponent => (T)_components.Find(c => c is T);

        // Get all components of type T
        public T[] GetComponents<T>() where T : IComponent => _components.OfType<T>().ToArray();

        public virtual void Update(GameTime gameTime) { }

        public virtual void OnCollision(Entity other) { }
    }
}