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
            BasicOni = content.Load<Texture2D>("Sprites/Player/Idle__000");             // Temporary sprite since the Enemy sprite isn't finished yet
            SwordSlash = content.Load<Texture2D>("Sprites/Bullet/TempBulletSprite");    // Temporary sprite since the Bullet sprite isn't finished yet
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, float rotation)
        {
            // Define the thickness of the border
            int thickness = 1;

            // Define the origin for rotation (rotate around the top-left corner of the rectangle)
            Vector2 origin = new Vector2(0, 0);

            // Top border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, thickness), color);

            // Left border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Top, thickness, rectangle.Height), color);

            // Right border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Right - thickness, rectangle.Top, thickness, rectangle.Height), color);

            // Bottom border
            spriteBatch.Draw(GameRoot.Pixel, new Rectangle(rectangle.Left, rectangle.Bottom - thickness, rectangle.Width, thickness), color);
        }
    }
}