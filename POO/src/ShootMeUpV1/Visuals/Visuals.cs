using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ShootMeUpV1
{
    static class Visuals
    {
        // Sprites
        public static Texture2D Player { get; private set; }
        public static Texture2D BasicOni { get; private set; }
        public static Texture2D SwordSlash { get; private set; }

        // Fonts
        public static SpriteFont SpriteFont { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Sprites/Player/Idle__000");
            SpriteFont = content.Load<SpriteFont>("Font");
            return; // Those sprites are yet to be done

            BasicOni = content.Load<Texture2D>("BasicOni");
            SwordSlash = content.Load<Texture2D>("SwordSlash");
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            // Draw top border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);

            // Draw left border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);

            // Draw right border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height), color);

            // Draw bottom border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);
        }
    }
}
