using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUpV1
{
    public class ProtectionComponent : IUpdatableComponent
    {
        private Entity _entity;

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Update(GameTime gameTime)
        {
            if (InputManager.WasKeyJustPressed(Keys.E)) // TODO: Change the PlaceProtection() keybind
            {
                PlaceProtection();
            }
        }

        private void PlaceProtection()
        {
            throw new NotImplementedException();
        }
    }
}
