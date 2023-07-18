using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Basic2DGame.GameFiles
{
    public static class SpriteBatchExtensions
    {
        private static Texture2D pixelTexture;

        /// <summary>
        /// Draws a filled in rectangle.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="rectangle"> The rectangle you want filled in. </param>
        /// <param name="color"> The color you want the rectangle filled in with. </param>
        public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(GetPixelTexture(spriteBatch.GraphicsDevice), rectangle, color);
        }

        private static Texture2D GetPixelTexture(GraphicsDevice graphicsDevice)
        {
            if (pixelTexture == null)
            {
                pixelTexture = new Texture2D(graphicsDevice, 1, 1);
                pixelTexture.SetData(new[] { Color.White });
            }

            return pixelTexture;
        }
    }

}
