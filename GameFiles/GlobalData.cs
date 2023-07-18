using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles
{
    /// <summary>
    /// A struct containing all data that all systems need to access.
    /// </summary>
    internal struct GlobalData
    {
        #region Properties

        /// <summary>
        /// When true, the debug console is rendered.
        /// </summary>
        public static bool IsDebugShown { get; set; }

        /// <summary>
        /// The SpriteBatch used to draw everything in the game.
        /// </summary>
        public static SpriteBatch SpriteBatch { get; set; }

        /// <summary>
        /// The GraphicsDeviceManager for this project.
        /// </summary>
        public static GraphicsDeviceManager Graphics { get; set; }

        /// <summary>
        /// The default font used for rendering text.
        /// </summary>
        public static SpriteFont StandardFont { get; set; }

        /// <summary>
        /// The default font used for rendering text (Italics).
        /// </summary>
        public static SpriteFont ItalicStandardFont { get; set; }

        /// <summary>
        /// The ContentManager used for this project.
        /// </summary>
        public static ContentManager Content { get; set; }

        /// <summary>
        /// The viewport used for this project.
        /// </summary>
        public static Viewport Viewport { get; set; }

        /// <summary>
        /// The matrix used to scale the game.
        /// </summary>
        public static Matrix ScaleMatrix { get; set; }

        /// <summary>
        /// The width of the window.
        /// </summary>
        public static int DesiredWindowWidth { get; set; }

        /// <summary>
        /// The Height of the window.
        /// </summary>
        public static int DesiredWindowHeight { get; set; }

        /// <summary>
        /// The list of strings displayed on the debug console.
        /// </summary>
        public static List<DebugString> DebugStrings { get; set; }

        /// <summary>
        /// The list of entities in the game.
        /// </summary>
        // Sorry, Missing!

        /// <summary>
        /// The last state of the keyboard.
        /// </summary>
        public static KeyboardState PreviousKeyboardState { get; set; }

        /// <summary>
        /// The last state of the mouse.
        /// </summary>
        public static MouseState PreviousMouseState { get; set; }

        /// <summary>
        /// The current map the player is on.
        /// </summary>
        public static Map CurrentMap { get; set; }

        /// <summary>
        /// A dictionary containing all the key binds for the game.
        /// </summary>
        public static Dictionary<string, Keys> KeyBinds;

        #endregion

        /// <summary>
        /// Run this in the Initialize method to initialize the GlobalData properties.
        /// </summary>
        public static void Initialize()
        {
            KeyBinds = new()
            {
                {"Up", Keys.W },
                {"Left", Keys.A },
                {"Down", Keys.S },
                {"Right", Keys.D },
                {"Show Debug", Keys.F3 }
            };

            DesiredWindowWidth = 1920;
            DesiredWindowHeight = 1080;

            StandardFont = Content.Load<SpriteFont>("StandardFont");
            ItalicStandardFont = Content.Load<SpriteFont>("StandardFontItalics");

            // Initialize the viewport to match the screen size
            Viewport = new Viewport(0, 0, DesiredWindowWidth, DesiredWindowHeight);

            // Calculate the scale matrix
            ScaleMatrix = Matrix.CreateScale((float)Viewport.Width / Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width,
                                             (float)Viewport.Height / Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height,
                                             1f);

            //Entities = new();

            DebugStrings = new()
            {
                new DebugString($"FPS: {FpsSystem.FramesPerSecond}", -1, Color.White, false),
                //new DebugString($"Number of Entities: {Entities.Count}", -1, Color.White, false)
            };

            // Changing the size of the window
            Graphics.PreferredBackBufferWidth = DesiredWindowWidth;
            Graphics.PreferredBackBufferHeight = DesiredWindowHeight;

            Graphics.ApplyChanges();

            IsDebugShown = false;
        }

        /// <summary>
        /// Run this to update global information that needs to be updated every frame.
        /// </summary>
        public static void Update()
        {
            // Update the debug strings
            DebugStrings[0] = new DebugString($"FPS: {FpsSystem.FramesPerSecond}", -1, Color.White, false);
            //DebugStrings[1] = new DebugString($"Number of Entities: {Entities.Count}", -1, Color.White, false);

            for (int i = 0; i < DebugStrings.Count; i++)
            {
                // If the lifespan of a debug string is greater than 0, we minus it by one.
                if (DebugStrings[i].LifeSpan > 0)
                {
                    DebugStrings[i].LifeSpan--;
                }

                // If the lifespan of a debug string is equal to 0, we remove it and back the counter up by one
                else if (DebugStrings[i].LifeSpan == 0)
                {
                    DebugStrings.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
