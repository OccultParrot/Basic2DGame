using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Basic2DGame.GameFiles.Entity_Component_System.Components
{
    internal struct PositionComponent : IComponent
    {
        // The position of the entity.
        public Vector2 Position { get; set; }
        // The x position of the entity
        public float X { get { return Position.X; } }
        // The y position of the entity
        public float Y { get { return Position.Y; } }

        public PositionComponent(float x, float y)
        {
            Position = new Vector2(x, y);
        }
        public PositionComponent(Vector2 position)
        {
            Position = position;
        }

        void IComponent.Update()
        {
            
        }

        void IComponent.ChangeValue(string valueName, object value)
        {
            switch (valueName)
            {
                case "X":
                    Position = new Vector2((float)value, Position.Y);
                    break;
                case "Y":
                    Position = new Vector2(Position.X, (float)value);
                    break;
                case "Position":
                    Position = (Vector2)value;
                    break;
            }
        }
    }
}
