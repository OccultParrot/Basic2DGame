using Basic2DGame.GameFiles.Managers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles
{
    public struct Variables
    {
        public static KeyboardState PreviousKeyboardState { get; set; }

        public static TextureManager Textures { get; set; }

        public static ContentManager Content { get; set; }

        public static GraphicsDeviceManager Graphics { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static Vector2 TEMPORARY; // DELEAT THIS EVENTUALY
    }
}
