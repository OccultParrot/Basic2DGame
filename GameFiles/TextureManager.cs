using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.Textures
{
    public class TextureManager
    {
        public Vector2 StandardTileSize = new(32, 32);
        /* Plans for TextureManager
         * We need dictionaries for the following texture types:
         * 1. Tile Sets (For levels)
         * 2. Ground Cover
         * 3. Trees
         * 4. Items
         * 5. Entities
         * 6. UI
         * 7. Miscellaneous (Cursor, etc.)
         * 
         * We need the class to auto-populate with the textures from the Content Pipeline upon initialization.
         * We need a method to get a source rectangle from a tile set or animation frame.
         */

        public TextureManager() 
        {
            TileSets = new()
            {

            };

            GroundCover = new()
            {

            };

            Trees = new()
            {

            };

            Items = new()
            {

            };

            Entities = new()
            {

            };

            UI = new()
            {

            };

            Miscellaneous = new()
            {
                {0, Variables.Content.Load<Texture2D>("Misc\\Cursor") }
            };
        }

        // TODO: Make the get tile source method.
        public Rectangle GetTileSource(int TileID, int TileSetID)
        {
            return Rectangle.Empty;
        }
        public Dictionary<int, Texture2D> TileSets { get; set; }
        public Dictionary<int, Texture2D> GroundCover { get; set; }
        public Dictionary<int, Texture2D> Trees { get; set; }
        public Dictionary<int, Texture2D> Items { get; set; }
        public Dictionary<int, Texture2D> Entities { get; set; }
        public Dictionary<int, Texture2D> UI { get; set; }
        public Dictionary<int, Texture2D> Miscellaneous { get; set; }
    }
}