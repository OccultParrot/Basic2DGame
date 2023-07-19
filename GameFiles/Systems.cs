using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic2DGame.GameFiles
{

    /// <summary>
    /// The RenderSystem is responsible for drawing everything.
    /// </summary>
    internal struct RenderSystem
    {
        /// <summary>
        /// Draws everything in the default order.
        /// </summary>
        public static void GeneralRender()
        {
            GlobalData.SpriteBatch.Begin(transformMatrix: GlobalData.ScaleMatrix);

            if (GlobalData.IsDebugShown)
                RenderDebug();

            GlobalData.SpriteBatch.End();
        }

        /// <summary>
        /// Used to render the debug console.
        /// </summary>
        public static void RenderDebug()
        {
            List<DebugString> strings = GlobalData.DebugStrings;

            int scale = 2;

            int spacing = 4 * scale;
            int textSize = 12 * scale;

            DebugString longestString = strings[0]; // Assume the first string is the longest initially

            for (int i = 1; i < strings.Count; i++)
            {
                if (strings[i].Text == "BLANK")
                {
                    strings.RemoveAt(i);
                    i--; // Back up i by one because the list has had the old item at i removed
                }
                if (strings[i].Text.Length > longestString.Text.Length)
                {
                    longestString = strings[i]; // Update the longest string if a longer one is found
                }
            }


            Color RectColor = Color.Black;
            RectColor.A = 50;

            // The rectangle that the debug console will be drawn in
            GlobalData.SpriteBatch.DrawRectangle(new
                (
                0,
                0,
                ((int)GlobalData.StandardFont.MeasureString(longestString.Text).X + spacing * 2) * scale,
                spacing * 2 + (strings.Count * (textSize + spacing))
                ), RectColor);

            for (int i = 0; i < strings.Count; i++)
            {
                // If the debug string has a lifespan, draw it.
                if (strings[i].LifeSpan >= 0)
                    GlobalData.SpriteBatch.DrawString(GlobalData.StandardFont, strings[i].Text, new Vector2(spacing, i * (textSize + spacing)), strings[i].Color, 0f, Vector2.Zero, (float)scale, SpriteEffects.None, 0f);
                // Else if the debug string is immortal, draw it.
                else
                {
                    // Big Complex Multi-Colored Drawing
                    if (strings[i].Text.Contains("FPS:"))
                    {
                        GlobalData.SpriteBatch.DrawString(
                            GlobalData.StandardFont,
                            // Only the first 4 characters
                            strings[i].Text[..4],
                            new Vector2(
                                spacing,
                                i * (textSize + spacing)),
                            strings[i].Color,
                            0f,
                            Vector2.Zero,
                            (float)scale,
                            SpriteEffects.None,
                            0f);

                        GlobalData.SpriteBatch.DrawString(
                            GlobalData.ItalicStandardFont,
                            // Only the last characters, starting at 4
                            strings[i].Text[4..],
                            new Vector2(
                                spacing + GlobalData.StandardFont.MeasureString(strings[i].Text[..4]).X * scale,
                                i * (textSize + spacing)),
                            Color.LightGoldenrodYellow,
                            0f,
                            Vector2.Zero,
                            (float)scale,
                            SpriteEffects.None,
                            0f);
                    }

                    // Big Complex Multi-Colored Drawing
                    else if (strings[i].Text.Contains("Number of Entities:"))
                    {
                        GlobalData.SpriteBatch.DrawString(
                            GlobalData.StandardFont,
                            // Only the first 18 characters
                            strings[i].Text[..19],
                            new Vector2(
                                spacing,
                                i * (textSize + spacing)),
                            strings[i].Color,
                            0f,
                            Vector2.Zero,
                            (float)scale,
                            SpriteEffects.None,
                            0f);

                        GlobalData.SpriteBatch.DrawString(
                            GlobalData.ItalicStandardFont,
                            // Only the last characters, starting at 19
                            strings[i].Text[19..],
                            new Vector2(
                                spacing + GlobalData.StandardFont.MeasureString(strings[i].Text[..19]).X * scale,
                                i * (textSize + spacing)),
                            Color.Lime,
                            0f,
                            Vector2.Zero,
                            (float)scale,
                            SpriteEffects.None,
                            0f);
                    }
                }
            }
        }

        public static void RenderMap()
        {

        }
    }

    /// <summary>
    /// Used to get / calculate the FramesPerSecond.
    /// </summary>
    internal struct FpsSystem
    {
        private static float ElapsedSeconds;
        private static int FrameCount;

        /// <summary>
        /// The amount of frames per second that the program is displaying.
        /// </summary>
        public static float FramesPerSecond { get; private set; }

        /// <summary>
        /// Calculates the frames per second the program displays.
        /// </summary>
        /// <param name="elapsedSeconds"> Use "(float)gameTime.ElapsedGameTime.TotalSeconds"</param>
        public static void Update(float elapsedSeconds)
        {
            // Calculate the elapsed seconds
            ElapsedSeconds += (float)elapsedSeconds;

            // Increment the frame count
            FrameCount++;

            // Calculate FramesPerSecond
            FramesPerSecond = FrameCount / ElapsedSeconds;

        }
    }

    /// <summary>
    /// Used to handle input, Including filling in text boxes.
    /// </summary>
    internal struct InputSystem
    {
        public static void Update()
        {
            GetInputs();

            GlobalData.PreviousKeyboardState = Keyboard.GetState();
            GlobalData.PreviousMouseState = Mouse.GetState();
        }
        /// <summary>
        /// Used for handling the input of text boxes.
        /// </summary>
        /// <param name="textBox"> The textbox to catch input </param>
        public static void AlterTextBox(TextBox textBox)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            // Handle backspace
            if (Shortcuts.CatchPressedKey(Keys.Back))
            {
                if (textBox.Text.Length > 0)
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                }
            }
            // Handle typing
            else
            {
                foreach (Keys key in currentKeyboardState.GetPressedKeys())
                {
                    string character = GetCharacterFromKey(key);
                    textBox.Text += character;
                }
            }
        }

        /// <summary>
        /// Gets the character from the key. Ex: A, B, C, 1, 2, 3, etc.
        /// </summary>
        /// <param name="key"> The key to collect the character from </param>
        /// <returns> Returns the character as a string </returns>
        private static string GetCharacterFromKey(Keys key)
        {
            bool isShiftDown = Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift);

            // Handle individual keys
            if (Shortcuts.CatchPressedKey(key))
            {
                // Letters
                if (key >= Keys.A && key <= Keys.Z)
                {
                    char character = (char)((int)key + (isShiftDown ? 0 : 32));
                    return character.ToString();
                }

                // Numbers
                if (key >= Keys.D0 && key <= Keys.D9)
                {
                    char character = (char)((int)key + (isShiftDown ? -16 : 48));
                    return character.ToString();
                }

                // Special characters
                switch (key)
                {
                    case Keys.Enter: return "\n";
                    case Keys.Space: return " ";
                    case Keys.OemComma: return isShiftDown ? "<" : ",";
                    case Keys.OemPeriod: return isShiftDown ? ">" : ".";
                    case Keys.OemBackslash: return isShiftDown ? "|" : "\\";
                    case Keys.OemCloseBrackets: return isShiftDown ? "}" : "]";
                    case Keys.OemOpenBrackets: return isShiftDown ? "{" : "[";
                    case Keys.OemMinus: return isShiftDown ? "_" : "-";
                    case Keys.OemPlus: return isShiftDown ? "+" : "=";
                    case Keys.OemSemicolon: return isShiftDown ? ":" : ";";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Catches all inputs from the keyboard and mouse, and handles them accordingly.
        /// </summary>
        private static void GetInputs()
        {
            if (Shortcuts.CatchPressedKey(GlobalData.KeyBinds["Show Debug"]))
            {
                GlobalData.IsDebugShown = !GlobalData.IsDebugShown;
            }
        }
    }

    /// <summary>
    /// The system for everything related to maps, such as rendering, and altering information.
    /// </summary>
    internal struct MapSystem
    {

    }
}
