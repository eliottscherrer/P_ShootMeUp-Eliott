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
        public static Vector2 LastMousePosition => new Vector2(LastMouseState.X, LastMouseState.Y);
        public static Vector2 MouseDirection => MousePosition - LastMousePosition;

        public static void Update()
        {
            LastKeyboardState = KeyboardState;
            LastMouseState = MouseState;
            KeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }

        // Keyboard actions
        public static bool WasKeyJustPressed(Keys key) => LastKeyboardState.IsKeyUp(key) && KeyboardState.IsKeyDown(key);
        public static bool IsKeyDown(Keys key) => KeyboardState.IsKeyDown(key);

        // Mouse actions
        public static bool WasLeftButtonJustPressed() => LastMouseState.LeftButton == ButtonState.Released && MouseState.LeftButton == ButtonState.Pressed;
        public static bool WasRightButtonJustPressed() => LastMouseState.RightButton == ButtonState.Released && MouseState.RightButton == ButtonState.Pressed;
        public static bool IsLeftButtonDown() => MouseState.LeftButton == ButtonState.Pressed;
        public static bool IsRightButtonDown() => MouseState.RightButton == ButtonState.Pressed;

        public static bool WasLeftButtonJustReleased() => LastMouseState.LeftButton == ButtonState.Pressed && MouseState.LeftButton == ButtonState.Released;
        public static bool WasRightButtonJustReleased() => LastMouseState.RightButton == ButtonState.Pressed && MouseState.RightButton == ButtonState.Released;
    }
}
