using Microsoft.Xna.Framework;

namespace Basic2DGame.GameFiles
{
    public struct Camera
    {
        private static int x = 0;
        private static int y = 0;

        private static float zoom = 1f;

        public static Vector2 Position
        {
            get
            {
                return new Vector2(x, y);
            }
            set
            {
                x = (int)value.X;
                y = (int)value.Y;
            }
        }

        public static float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                if (value > 0)
                {
                    zoom = value;
                }
            }
        }
    }
}
