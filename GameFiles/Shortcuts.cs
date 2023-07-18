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
    internal struct Shortcuts
    {
        public static bool CatchPressedKey(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key) && !GlobalData.PreviousKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
