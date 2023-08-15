using Basic2DGame.Textures;
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

namespace Basic2DGame.GameFiles
{
    internal struct LevelManager
    {
        public static int CurrentLevelID { get; private set; }
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
        public int LevelWidth { get; set; }
        public int LevelHeight { get; set; }

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

        private void Load()
        {
            // Load the level from the XML file.
            // TODO: Write the level xml loading.

            // The current layer we are on. (Is used later)
            Layer currentLayer;

            _lvlDoc.Load(XmlPath);
            XmlElement lvlDocRoot = _lvlDoc.DocumentElement;
            LevelWidth = int.Parse(lvlDocRoot.Attributes["tileswide"].Value);
            LevelHeight = int.Parse(lvlDocRoot.Attributes["tileshigh"].Value);

            TileWidth = int.Parse(lvlDocRoot.Attributes["tilewidth"].Value);
            TileHeight = int.Parse(lvlDocRoot.Attributes["tileheight"].Value);

            // Getting the layer nodes from the xml file.
            XmlNodeList layers = lvlDocRoot.ChildNodes;

            foreach (XmlNode layer in layers)
            {
                // Big switch statement to determine which layer we are on. (Also initializes all active layers)
                switch (layer.Attributes["number"].Value)
                {
                    default:
                        throw new ArgumentException($"Error in map file: {XmlPath}! Layer numbers must be 0 to 5. Incorrect layer was {layer.Attributes["number"].Value}");

                    case "0":
                        {
                            Layer0 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
                            currentLayer = Layer0;
                            break;
                        }
                    case "1":
                        {
                            Layer1 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
                            currentLayer = Layer1;
                            break;
                        }
                    case "2":
                        {
                            Layer2 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
                            currentLayer = Layer2;
                            break;
                        }
                    case "3":
                        {
                            Layer3 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
                            currentLayer = Layer3;
                            break;
                        }
                    case "4":
                        {
                            Layer4 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
                            currentLayer = Layer4;
                            break;
                        }
                    case "5":
                        {
                            Layer5 = new()
                            {
                                Tiles = new Tile[LevelWidth, LevelHeight],
                                Name = layer.Attributes["name"].Value,
                                Number = int.Parse(layer.Attributes["number"].Value)
                            };
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
                    Debug.WriteLine($"({tile.Attributes["x"].Value}, {tile.Attributes["y"].Value}) {tile.Attributes["tile"].Value}");
                }
            }
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
        public int ID { get; set; }
        public int Rotation { get; set; }
        public bool FlipX { get; set; }
    }

    public struct Layer
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Tile[,] Tiles { get; set; }
    }
    public interface ILayers
    {
        
    }
}
