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
    /// A class for strings that are displayed on the debug console.
    /// </summary>
    internal class DebugString
    {
        public int LifeSpan;
        public string Text;
        public Color Color;

        /// <summary>
        /// A class for strings that are displayed on the debug console.
        /// </summary>
        /// <param name="text"> What the string displays to the debug console. </param>
        /// <param name="lifeSpan"> How long the string exists (In frames). </param>
        /// <param name="color"> The color of the string when it gets displayed. </param>
        /// <param name="AddToDebugStrings"> Whether or not to add the string to the debug strings list. Defaults to true. </param>
        public DebugString(string text, int lifeSpan, Color color, bool AddToDebugStrings = true)
        {
            Text = text;
            LifeSpan = lifeSpan;
            Color = color;
            if (AddToDebugStrings)
                GlobalData.DebugStrings.Add(this);
        }

        /// <summary>
        /// Send a message to the debug console.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lifeSpan"></param>
        /// <param name="color"></param>
        public static void Add(string text, int lifeSpan, Color color)
        {
            _ = new DebugString(text, lifeSpan, color);
        }
    }

    /// <summary>
    /// A class for text boxes.
    /// </summary>
    internal class TextBox
    {
        public string Text;

        public TextBox(string text = "")
        {
            Text = text;
        }
    }
}
