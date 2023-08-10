using Basic2DGame.Textures;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame
{
    internal class LevelManager
    {
        public int CurrentLevelID { get; private set; }
        public static Dictionary<int, Level> Levels { get; private set; } = new()
        {
            { -1, new("Levels/TestLevel", "Testing Level") }
        };

    }
    public class Level
    {
        /* Plans for levels
         * Needed fields:
         * 1. Path to the xml file
         * 2. Name of the level
         * 3. ID of the level (This is the key in the dictionary)
         * 4. The width and height of the level in tiles
         * 5. The layers of the level
         * 
         * Needed methods:
         * 1. Load from xml path
         * 2. Save to xml path
         * 3. Get tile at position at layer
         * 4. Set tile at position at layer
         */
        public Level(string xmlPath, string name)
        {
            XmlPath = xmlPath;
            Name = name;

            Load();
        }

        public string XmlPath { get; private set; }

        public string Name { get; private set; }

        // IN TILES
        public int LevelWidth { get; private set; }
        public int LevelHeight { get; private set; }

        // The layers of the level
        public Tile[,] Background { get; private set; }
        public Tile[,] Foreground { get; private set; }
        public Tile[,] GroundCover { get; private set; }

        private void Load()
        {
            // Load the level from the XML file.
            // TODO: Write the level xml loading.
        }

        private void Save()
        {
            // Save the file to an xml file
            // TODO: Write the level xml saving.
        }

        private Tile GetTile(int x, int y, int layer)
        {
            // Returns the value of a tile from a specific position on the level
            // TODO: Write the GetTile method.

            return new(); // TEMPORARY! REMOVE WHEN METHOD IS WRITTEN.
        }

        private void SetTile(int x, int y, Tile value)
        {
            // Sets the value of a tile from a specific position on the level
            // TODO: Write the SetTile method.
        }
    }

    public class Tile
    {
        
    }
}
