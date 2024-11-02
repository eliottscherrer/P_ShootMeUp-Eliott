using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XInput;
using System;

namespace ShootMeUpV1
{
    public class GameRoot : Game
    {
        // Graphics
        private readonly GraphicsDeviceManager _graphics;
        public static SpriteBatch SpriteBatch { get; private set; }

        // Singleton of GameRoot for global access
        public static GameRoot Instance { get; private set; }

        // Screen infos
        public static Viewport Viewport => Instance.GraphicsDevice.Viewport;
        public static Vector2 ScreenSize => new(Viewport.Width, Viewport.Height);

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Instance = this;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();

            EntityManager.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Visuals.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();
            EntityManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            SpriteBatch.Begin();
            {
                EntityManager.Draw(SpriteBatch);
            }
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
