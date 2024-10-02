using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public static void DrawRectangle(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, Color color)
        {
            // Calculate the four corners of the rectangle
            Vector2[] corners = new Vector2[4]
            {
                new Vector2(0, 0),              // Top-left
                new Vector2(size.X, 0),         // Top-right
                new Vector2(size.X, size.Y),    // Bottom-right
                new Vector2(0, size.Y)          // Bottom-left
            };

            // Apply rotation and translate to position
            for (int i = 0; i < corners.Length; i++)
            {
                // Rotate the point
                corners[i] = Vector2.Transform(corners[i], Matrix.CreateRotationZ(rotation));

                // Translate the point to the desired position
                corners[i] += position;
            }

            // Draw the lines between the corners (could be made into a loop but it would be terrible to read)
            DrawLine(spriteBatch, corners[0], corners[1], color);
            DrawLine(spriteBatch, corners[1], corners[2], color);
            DrawLine(spriteBatch, corners[2], corners[3], color);
            DrawLine(spriteBatch, corners[3], corners[0], color);
        }

        private static void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
        {
            // Calculate the length and angle of the line
            float length = Vector2.Distance(start, end);
            float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);

            // Draw the line as a rectangle (1xN) rotated to the correct angle
            spriteBatch.Draw(GameRoot.Pixel, start, null, color, angle, Vector2.Zero, new Vector2(length, 1f), SpriteEffects.None, 0f);
        }
    }
}
