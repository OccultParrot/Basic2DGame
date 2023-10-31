using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Basic2DGame.GameFiles
{
    public struct Variables
    {
        public static KeyboardState PreviousKeyboardState { get; set; }

        public static MouseState PreviousMouseState { get; set; }

        public static ContentManager Content { get; set; }

        public static GraphicsDeviceManager Graphics { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }
    }
}
