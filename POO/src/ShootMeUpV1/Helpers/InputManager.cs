using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace ShootMeUpV1
{
    static class InputManager
    {
        // States
        private static KeyboardState KeyboardState, LastKeyboardState;
        private static MouseState MouseState, LastMouseState;

        // Infos
        public static Vector2 MousePosition => new Vector2(MouseState.X, MouseState.Y);

        public static void Update()
        {
            LastKeyboardState = KeyboardState;
            LastMouseState = MouseState;
            KeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }

        public static bool WasKeyJustPressed(Keys key) => LastKeyboardState.IsKeyUp(key) && KeyboardState.IsKeyDown(key);
        public static bool IsKeyDown(Keys key) => KeyboardState.IsKeyDown(key);
    }
}
