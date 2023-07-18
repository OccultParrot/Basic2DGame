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
        public static Matrix TransformMatrix => Matrix.CreateTranslation(-Position.X, -Position.Y, 0f);
    }

    internal class Tile
    {
        public Vector2 Position { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public Tile(Vector2 Position)
        {
            Properties = new()
            {
                { "", "" }
            };
        }

        public void ListProperties()
        {
            DebugString.Add("Properties in Tile:", 300, Color.White);
            DebugString.Add("===================", 300, Color.White);
            foreach (var property in Properties)
            {
                DebugString.Add($"{property.Key}: {property.Value}", 300, Color.White);
            }
        }

        public void SetProperty(string name, string value)
        {
            Properties.TryAdd(name, value);
        }

        public string GetProperty(string name)
        {
            return Properties[name];
        }
    }

    internal class Map
    {

        /// <summary>
        /// Makes a new map.
        /// </summary>
        /// <param name="path">The path to the .XML file the maps information is stored at.</param>
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Size { get; set; }
        public string TileSize { get; set; }
        public string Tileset { get; set; }

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

                XmlNode metaDataNode = xmlDoc.SelectSingleNode("/MapData/MetaData");

                Name = GetNodeValue(metaDataNode, "Name");
                Author = GetNodeValue(metaDataNode, "Author");
                Description = GetNodeValue(metaDataNode, "Description");
                Version = GetNodeValue(metaDataNode, "Version");
                Size = GetNodeValue(metaDataNode, "Size");
                TileSize = GetNodeValue(metaDataNode, "TileSize");
                Tileset = GetNodeValue(metaDataNode, "Tileset");
            }
            catch (Exception ex)
            {
                DebugString.Add("Error loading map data: " + ex.Message, 999, Color.IndianRed);
            }
        }

        private string GetNodeValue(XmlNode parentNode, string nodeName)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeName);
            return node?.InnerText;
        }
    }
}
