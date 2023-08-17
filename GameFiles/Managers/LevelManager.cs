using Basic2DGame.GameFiles.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace Basic2DGame.GameFiles.Managers
{
    internal struct LevelManager
    {
        public static int CurrentLevelID { get; private set; } = -1; // THIS IS FOR TESTING, REMOVE THIS LATER

        public static Level CurrentLevel { get { return Levels[CurrentLevelID]; } }
        public static Dictionary<int, Level> Levels { get; private set; }

        public static void Load()
        {
            Levels = new()
            {
                { -1, new("testing_map", "Testing Level") }
            };
        }

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
        public Level(string xmlName, string name)
        {
            XmlPath = "Resources/Levels/" + xmlName + ".xml";
            Name = name;

            _lvlDoc = new();

            Load();
        }

        public string XmlPath { get; set; }

        private XmlDocument _lvlDoc;

        public string Name { get; set; }


        // IN TILES
        public int Width { get; set; }
        public int Height { get; set; }

        // In pixels
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        // The layers of the level
        // I really doubt that we will ever need 5 layers, but I'm adding them just in case.
        public Layer Layer0 { get; set; }
        public Layer Layer1 { get; set; }
        public Layer Layer2 { get; set; }
        public Layer Layer3 { get; set; }
        public Layer Layer4 { get; set; }
        public Layer Layer5 { get; set; }

        /// <summary>
        /// Loads the map data from the xml file at the <see cref="XmlPath"/> path.
        /// </summary>
        /// <exception cref="ArgumentException"> This exception throws when the layer number it is reading is greater than five </exception>
        private void Load()
        {
            // The current layer we are on. (Is used later)
            Layer currentLayer;

            _lvlDoc.Load(XmlPath);
            XmlElement lvlDocRoot = _lvlDoc.DocumentElement;
            Width = int.Parse(lvlDocRoot.Attributes["tileswide"].Value);
            Height = int.Parse(lvlDocRoot.Attributes["tileshigh"].Value);

            TileWidth = int.Parse(lvlDocRoot.Attributes["tilewidth"].Value);
            TileHeight = int.Parse(lvlDocRoot.Attributes["tileheight"].Value);

            Layer0 = new()
            {
                Tiles = new Tile[Width, Height]
            };
            Layer1 = new()
            {
                Tiles = new Tile[Width, Height]
            };
            Layer2 = new()
            {
                Tiles = new Tile[Width, Height]
            };
            Layer3 = new()
            {
                Tiles = new Tile[Width, Height]
            };
            Layer4 = new()
            {
                Tiles = new Tile[Width, Height]
            };
            Layer5 = new()
            {
                Tiles = new Tile[Width, Height]
            };

            foreach (XmlNode layer in lvlDocRoot.ChildNodes)
            {
                // Big switch statement to determine which layer we are on. (Also initializes all active layers)
                switch (layer.Attributes["number"].Value)
                {
                    default:
                        throw new ArgumentException($"Error in map file: {XmlPath}! Layer numbers must be 0 to 5. Incorrect layer was {layer.Attributes["number"].Value}");

                    case "0":
                        {
                            Layer0.SetName(layer.Attributes["name"].Value);
                            Layer0.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer0;
                            break;
                        }
                    case "1":
                        {
                            Layer1.SetName(layer.Attributes["name"].Value);
                            Layer1.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer1;
                            break;
                        }
                    case "2":
                        {
                            Layer2.SetName(layer.Attributes["name"].Value);
                            Layer2.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer2;
                            break;
                        }
                    case "3":
                        {
                            Layer3.SetName(layer.Attributes["name"].Value);
                            Layer3.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer3;
                            break;
                        }
                    case "4":
                        {
                            Layer4.SetName(layer.Attributes["name"].Value);
                            Layer4.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer4;
                            break;
                        }
                    case "5":
                        {
                            Layer5.SetName(layer.Attributes["name"].Value);
                            Layer5.SetNumber(int.Parse(layer.Attributes["number"].Value));

                            currentLayer = Layer5;
                            break;
                        }
                }

                foreach (XmlNode tile in layer.ChildNodes)
                {
                    // Setting the tile on the current layer at the specific coordinates to the tile from the xml file.
                    currentLayer.Tiles[int.Parse(tile.Attributes["x"].Value), int.Parse(tile.Attributes["y"].Value)] = new Tile()
                    {
                        ID = int.Parse(tile.Attributes["tile"].Value),
                        Rotation = int.Parse(tile.Attributes["rot"].Value),
                        FlipX = bool.Parse(tile.Attributes["flipX"].Value)
                    };
                }
            }
        }

        private void Save()
        {
            // Save the file to an xml file

        }

        /// <summary>
        ///  Gets the tile at the specified coordinates and layer.
        /// </summary>
        /// <param name="x"> The x coordinate </param>
        /// <param name="y"> The y coordinate </param>
        /// <param name="layer"> The layer number, 0 -> 5 </param>
        /// <returns> The tile at specified location </returns>
        /// <exception cref="ArgumentException"></exception>
        public Tile GetTile(int x, int y, int layer)
        {
            // That was way easier than I thought it would be.
            return layer switch
            {
                0 => Layer0.Tiles[x, y],
                1 => Layer1.Tiles[x, y],
                2 => Layer2.Tiles[x, y],
                3 => Layer3.Tiles[x, y],
                4 => Layer4.Tiles[x, y],
                5 => Layer5.Tiles[x, y],
                _ => throw new ArgumentException($"Error in map file: {XmlPath}! Layer numbers must be 0 to 5. Incorrect layer was {layer}")
            };
        }

        /// <summary>
        /// Sets the tile at the specified coordinates and layer to the specified tile.
        /// </summary>
        /// <param name="x"> The x coordinate </param>
        /// <param name="y"> The y coordinate </param>
        /// <param name="layer"> The layer number </param>
        /// <param name="value"> The tile you want to change it to </param>
        /// <exception cref="ArgumentException"></exception>
        public void SetTile(int x, int y, int layer, Tile value)
        {
            switch (layer)
            {
                default:
                    throw new ArgumentException($"Error in map file: {XmlPath}! Layer numbers must be 0 to 5. Incorrect layer was {layer}");

                case 0:
                    {
                        Layer0.Tiles[x, y] = value;
                        break;
                    }
                case 1:
                    {
                        Layer1.Tiles[x, y] = value;
                        break;
                    }
                case 2:
                    {
                        Layer2.Tiles[x, y] = value;
                        break;
                    }
                case 3:
                    {
                        Layer3.Tiles[x, y] = value;
                        break;
                    }
                case 4:
                    {
                        Layer4.Tiles[x, y] = value;
                        break;
                    }
                case 5:
                    {
                        Layer5.Tiles[x, y] = value;
                        break;
                    }
            }
        }

        public class Tile
        {
            // The location of the tile in the tile set.
            public int ID { get; set; }

            // The rotation of the tile.
            public int Rotation { get; set; }

            // Whether or not the tile is flipped on the x axis.
            public bool FlipX { get; set; }
        }

        public struct Layer
        {
            public string Name { get; set; }
            public int Number { get; set; }

            // The actual tile map.
            public Tile[,] Tiles { get; set; }

            public void SetName(string name)
            {
                Name = name;
            }
            public void SetNumber(int number)
            {
                Number = number;
            }
        }
    }
}
