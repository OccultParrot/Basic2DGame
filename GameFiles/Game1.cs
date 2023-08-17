using Basic2DGame.GameFiles.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Linq;

namespace Basic2DGame.GameFiles
{
    public class Game1 : Game
    {

        public Game1()
        {
            Variables.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Variables.Content = Content;
            IsMouseVisible = false;

        }

        protected override void Initialize()
        {

            #region Post Initalization Processing

            base.Initialize();

            #endregion
        }

        protected override void LoadContent()
        {
            Variables.SpriteBatch = new SpriteBatch(GraphicsDevice);

            LevelManager.Load();

            Variables.Textures = new();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Variables.TEMPORARY.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Variables.TEMPORARY.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Variables.TEMPORARY.X -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Variables.TEMPORARY.X += 1;

            #region Post-Update Processing

            Variables.PreviousKeyboardState = Keyboard.GetState();
            base.Update(gameTime);

            #endregion
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RenderManager.Draw();

            #region Post Render Processing

            base.Draw(gameTime);

            #endregion
        }
    }
}