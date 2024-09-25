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
    }
}
