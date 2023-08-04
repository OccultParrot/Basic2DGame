using Basic2DGame.GameFiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Basic2DGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            GlobalData.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GlobalData.Content = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GlobalData.Initialize();

            DebugString.Add("Press 'M' to view map details", -1, Color.White);

            DebugString.Add($"{7 % 6}" , -1, Color.White);
            MapSystem.Initialize(5);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GlobalData.SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            FpsSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            GlobalData.Update();

            MapSystem.Update();

            InputSystem.Update();

            
            #region Post-Update Processing
            
            base.Update(gameTime);

            #endregion
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RenderSystem.GeneralRender();
            base.Draw(gameTime);
        }
    }
}