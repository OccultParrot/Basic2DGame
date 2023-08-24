using Basic2DGame.GameFiles.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            Variables.Textures.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Camera.Position += new Vector2(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Camera.Position -= new Vector2(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Camera.Position += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Camera.Position -= new Vector2(-1, 0);

            if (Mouse.GetState().ScrollWheelValue > Variables.PreviousMouseState.ScrollWheelValue)
                Camera.Zoom += 0.1f;
            if (Mouse.GetState().ScrollWheelValue < Variables.PreviousMouseState.ScrollWheelValue)
                Camera.Zoom -= 0.1f;

            #region Post-Update Processing

            Variables.PreviousKeyboardState = Keyboard.GetState();
            Variables.PreviousMouseState = Mouse.GetState();

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