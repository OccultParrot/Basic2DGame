using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Basic2DGame.GameFiles.Entity_Component_System.Components
{
    public struct BoundsComponent : IComponent
    {
        // The size of the entity. Size.X is the width, Size.Y is the height.
        public Vector2 Size { get; private set; }
        // The width of the entity.
        public int Width { get { return (int)Size.X; } }
        // The height of the entity.
        public int Height { get { return (int)Size.Y; } }

        // Two options upon construction. You can either pass in a Vector2 or two integers.
        public BoundsComponent(Vector2 size)
        {
            Size = size;
        }
        public BoundsComponent(int width, int height)
        {
            Size = new Vector2(width, height);
        }

        void IComponent.Update()
        {
            
        }

        // Changes the value of a variable.
        void IComponent.ChangeValue(string valueName, object value)
        {
            switch (valueName)
            {
                case "Size":
                    Size = (Vector2)value;
                    break;
                case "Width":
                    Size = new Vector2((int)value, Height);
                    break;
                case "Height":
                    Size = new Vector2(Width, (int)value);
                    break;
            }
        }
    }
}
