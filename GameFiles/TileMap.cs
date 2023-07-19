using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Basic2DGame.GameFiles
{
    internal struct Camera
    {
        public static Vector2 Position { get; set; } = Vector2.Zero;

        public static float Zoom { get; set; } = 1f;

        public static Rectangle Viewport => new Rectangle((int)Position.X, (int)Position.Y, GlobalData.DesiredWindowWidth, GlobalData.DesiredWindowHeight);
        public static Matrix TransformMatrix => Matrix.CreateTranslation(-Position.X, -Position.Y, 0f);
    }

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int TileId { get; set; }
        public int Rotation { get; set; }
        public bool FlipX { get; set; }

        public Tile(int x, int y, int tileId, int rotation, bool flipX)
        {
            X = x;
            Y = y;
            TileId = tileId;
            Rotation = rotation;
            FlipX = flipX;
        }
    }

    public class Map
    {
        public int TilesWide { get; private set; }
        public int TilesHigh { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public Tile[,] TileMap { get; private set; }
        public TileSet TileSet { get; private set; }

        public Map(string xmlFilePath)
        {
            LoadMapData(xmlFilePath);
        }

        private void LoadMapData(string xmlFilePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                // Read map information
                XmlNode mapNode = xmlDoc.SelectSingleNode("tilemap");
                TilesWide = int.Parse(mapNode.Attributes["tileswide"].Value);
                TilesHigh = int.Parse(mapNode.Attributes["tileshigh"].Value);
                TileWidth = int.Parse(mapNode.Attributes["tilewidth"].Value);
                TileHeight = int.Parse(mapNode.Attributes["tileheight"].Value);

                string tileSetPath = mapNode.Attributes["tileset"].Value;
                TileSet = new TileSet(tileSetPath, TileWidth, TileHeight);

                // Read tile data
                XmlNodeList layerNodes = xmlDoc.SelectNodes("tilemap/layer");
                XmlNodeList tileNodes = layerNodes[0].SelectNodes("tile");
                TileMap = new Tile[TilesWide, TilesHigh];

                foreach (XmlNode tileNode in tileNodes)
                {
                    int x = int.Parse(tileNode.Attributes["x"].Value);
                    int y = int.Parse(tileNode.Attributes["y"].Value);
                    int tileId = int.Parse(tileNode.Attributes["tile"].Value);
                    int rotation = int.Parse(tileNode.Attributes["rot"].Value);
                    bool flipX = bool.Parse(tileNode.Attributes["flipX"].Value);

                    TileMap[x, y] = new Tile(x, y, tileId, rotation, flipX);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading map data: " + ex.Message);
            }
        }

        // Add other useful functions here...

        // Get a specific tile at (x, y) coordinates
        public Tile GetTile(int x, int y)
        {
            if (x >= 0 && x < TilesWide && y >= 0 && y < TilesHigh)
            {
                return TileMap[x, y];
            }
            return null;
        }

        // Update the data of a specific tile
        public void SetTile(int x, int y, int tileId, int rotation, bool flipX)
        {
            if (x >= 0 && x < TilesWide && y >= 0 && y < TilesHigh)
            {
                TileMap[x, y] = new Tile(x, y, tileId, rotation, flipX);
            }
        }
    }
    public class TileSet
    {
        public Texture2D Texture { get; set;}
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TilesWide { get; set; }
        public int TilesHigh { get; set; }

        public TileSet(string tileSetPath, int tileWidth, int tileHeight)
        {
            Texture = GlobalData.Content.Load<Texture2D>(tileSetPath);
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TilesWide = Texture.Width / tileWidth;
            TilesHigh = Texture.Height / tileHeight;
        }

        
        public Rectangle GetSourceRectangle(int tileID)
        {
            // TODO: Make this!
        }
    }

}
