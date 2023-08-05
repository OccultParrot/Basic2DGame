using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles
{
    internal struct TextureManager
    {
        #region All the texture dictionaries

        /// <summary>
        /// A collection of all the UI textures used in the game.
        /// </summary>
        public static Dictionary<int, Texture2D> UIAtlas { get; private set; } = new()
        {

        };

        /// <summary>
        /// A collection of all the tile sets used in the game.
        /// </summary>
        public static Dictionary<int, Texture2D> TileSetAtlas { get; private set; } = new()
        {

        };

        /// <summary>
        /// A collection of all the item textures used in the game.
        /// </summary>
        public static Dictionary<int, Texture2D> ItemAtlas { get; private set; } = new()
        {

        };

        /// <summary>
        /// A collection of all the entity textures used in the game.
        /// </summary>
        public static Dictionary<int, Texture2D> EntityAtlas { get; private set; } = new()
        {

        };

        #endregion

        public static void Load()
        {
            try
            {
                DebugString.Add("Loading textures...", 5, Color.Yellow);

                // Loading all the textures
                LoadUI();
                LoadItemSprites();
                LoadEntitySprites();
                LoadTileSets();

                DebugString.Add("Successfully loaded all textures!", 60, Color.Green);
            }
            catch (Exception e)
            {
                DebugString.Add("== Error loading textures! ==", 120, Color.Red);
                DebugString.Add($"{e.Message}", 120, Color.Red);
            }
        }

        #region All the load texture methods

        private static void LoadUI() { }
        private static void LoadItemSprites() { }
        private static void LoadEntitySprites() { }
        private static void LoadTileSets() 
        {
            TileSetAtlas.Add(-1, GlobalData.Content.Load<Texture2D>("testing_map_tileset"));
        }

        #endregion
    }
}
