using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles
{
    internal readonly struct GameConsole
    {
        private static readonly List<Message> messages = new();
        private static readonly int maxMessages = 10;

        public static void Initialize() => SendMessage("Console initialized.");

        public static void SendMessage(string message, string messageColor = "White")
        {
            Message _message = new(message, messageColor);
            messages.Add(_message);
            if (messages.Count > maxMessages)
                messages.RemoveAt(0);
        }

        public static IEnumerable<string> Messages
        {
            get
            {
                List<string> _messages = new();
                foreach (Message message in messages)
                {
                    _messages.Add(message.Text);
                }
                return _messages;
            }
        }
    }
    /// <summary>
    /// A basic message for the console.
    /// </summary>
    internal struct Message
    {
        public String Text { get; set; }
        public Color Color { get; set; }

        /// <summary>
        /// The basic message constructor.
        /// </summary>
        /// <param name="text"> The text in the message. </param>
        /// <param name="color"> The color you want the message. </param>
        public Message(String text, string color = "White")
        {
            Text = text;
            Color = color switch
            {
                "Red" => Color.Red,
                "Green" => Color.Green,
                "Blue" => Color.Blue,
                "White" => Color.White,
                "Black" => Color.Black,
                "Yellow" => Color.Yellow,
                "Orange" => Color.Orange,
                "Purple" => Color.Purple,
                "Pink" => Color.Pink,
                "Cyan" => Color.Cyan,
                "Magenta" => Color.Magenta,
                "Brown" => Color.Brown,
                _ => Color.White,// If the color string is not recognized, return the default color (White in this case).
            };
        }
    }
}
