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

        // DELETE THIS:
        Map map;

        public Game1()
        {
            GlobalData.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GlobalData.Content = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GlobalData.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GlobalData.SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            if (Shortcuts.CatchPressedKey(Keys.N))
            {
                map = new Map("Maps\\ExampleMap.xml");
            }
            FpsSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            GlobalData.Update();
            InputSystem.Update();

            
            #region Post-Update Processing
            
            base.Update(gameTime);

            #endregion
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            RenderSystem.GeneralRender();
            base.Draw(gameTime);
        }
    }
}