using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Basic2DGame.GameFiles.Entity_Component_System;
using Basic2DGame.GameFiles.Entity_Component_System.ComponentManager;
using Basic2DGame.GameFiles.Entity_Component_System.Components;
using Basic2DGame.GameFiles.Entity_Component_System.Systems;

namespace Basic2DGame.GameFiles
{
    public class Game1 : Game
    {
        public Entity e1 = new();

        public Game1()
        {
            Variables.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Variables.Content = Content;
            IsMouseVisible = false;

        }

        protected override void Initialize()
        {
            ComponentManager.AddComponent(e1.ID, new HealthComponent(-10));

            #region Post Initalization Processing

            base.Initialize();

            #endregion
        }

        protected override void LoadContent()
        {
            Variables.SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            HealthSystem.Update();

            #region Post-Update Processing

            Variables.PreviousKeyboardState = Keyboard.GetState();
            Variables.PreviousMouseState = Mouse.GetState();

            base.Update(gameTime);

            #endregion
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            #region Post Render Processing

            base.Draw(gameTime);

            #endregion
        }
    }
}