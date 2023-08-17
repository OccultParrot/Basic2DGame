using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Managers
{
    public class TextureManager
    {
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
            TileSets = new();

            GroundCover = new();

            Trees = new();

            Items = new();

            Entities = new();

            UI = new();

            Miscellaneous = new();
        }

        public void Load()
        {
            // Add all tile sets
            TileSets.Add(-1, Variables.Content.Load<Texture2D>("tilesets/testing_map"));

            // Add all ground cover

            // Add all trees

            // Add all items

            // Add all entities

            // Add all UI

            // Add all miscellaneous textures
            Miscellaneous.Add(0, Variables.Content.Load<Texture2D>("Misc\\Cursor"));

            // Add all modded textures

        }

        public static Rectangle GetTileSource(int TileID, int TileSetID)
        {
            int columns = Variables.Textures.TileSets[TileSetID].Width / LevelManager.Levels[TileSetID].TileWidth;
            int row = TileID / columns;
            int column = TileID % columns;

            return new Rectangle(column * LevelManager.Levels[TileSetID].TileWidth, row * LevelManager.Levels[TileSetID].TileHeight, LevelManager.Levels[TileSetID].TileWidth, LevelManager.Levels[TileSetID].TileHeight);
        }

        public Dictionary<int, Texture2D> TileSets { get; set; }
        public Dictionary<int, Texture2D> GroundCover { get; set; }
        public Dictionary<int, Texture2D> Trees { get; set; }
        public Dictionary<int, Texture2D> Items { get; set; }
        public Dictionary<int, Texture2D> Entities { get; set; }
        public Dictionary<int, Texture2D> UI { get; set; }
        public Dictionary<int, Texture2D> Miscellaneous { get; set; }

        public Dictionary<int, Texture2D> ModdedTextures { get; set; }
    }
}