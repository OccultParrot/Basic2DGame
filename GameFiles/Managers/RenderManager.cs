using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Managers
{
    public readonly struct RenderManager
    {
        public static void Draw()
        {
            /* Render Plans:
            * We want to draw the game in the following order:
            * 1. The map
            * 2. Ground Cover (grass, flowers, etc.)
            * 3. Trees
            * 4. Projectiles
            * 5. Items
            * 6. Entities
            * 7. UI
            * 8. Cursor
            */

            Variables.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            Variables.SpriteBatch.DrawString(Variables.Content.Load<SpriteFont>("Fonts/MainFont"), $"Mouse Pos: {Mouse.GetState().Position.X}, {Mouse.GetState().Position.Y}", new Vector2(10, 10), Color.White);
            DrawMap();
            DrawProjectiles();
            DrawItems();
            DrawEntities();
            DrawUI();
            DrawCursor();

            // FOR TESTING

            Variables.SpriteBatch.End();
        }

        private static void DrawMap()
        {

            // We need to do the following:
            // 1. Get the current level
            // 2. Get the current camera position
            // 3. Get the current camera size
            // 4. Get the current camera zoom
            // 5. 

            // Zoom and stuff are unused for now.
            Level CurrentLevel = LevelManager.CurrentLevel;
            Vector2 CameraPosition = Camera.Position;
            float CameraZoom = Camera.Zoom;

            for (int y = 0; y < CurrentLevel.Height; y++)
            {
                for (int x = 0; x < CurrentLevel.Width; x++)
                {
                    if (CurrentLevel.Layer0.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Vector2(x * (CurrentLevel.TileWidth * CameraZoom) - (int)CameraPosition.X, y * (CurrentLevel.TileHeight * CameraZoom) - (int)CameraPosition.Y),
                                               TextureManager.GetTileSource(CurrentLevel.Layer0.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White,
                                               0f,
                                               Vector2.Zero,
                                               CameraZoom,
                                               SpriteEffects.None,
                                               0f);
                    // If the tile is null, skip it
                    else
                        continue;

                    if (CurrentLevel.Layer1.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Rectangle(x * CurrentLevel.TileWidth - (int)CameraPosition.X, y * CurrentLevel.TileHeight - (int)CameraPosition.Y, CurrentLevel.TileWidth, CurrentLevel.TileHeight),
                                               TextureManager.GetTileSource(CurrentLevel.Layer1.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White);
                    // If the tile is null, skip it
                    else
                        continue;

                    if (CurrentLevel.Layer2.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Rectangle(x * CurrentLevel.TileWidth - (int)CameraPosition.X, y * CurrentLevel.TileHeight - (int)CameraPosition.Y, CurrentLevel.TileWidth, CurrentLevel.TileHeight),
                                               TextureManager.GetTileSource(CurrentLevel.Layer2.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White);
                    // If the tile is null, skip it
                    else
                        continue;

                    if (CurrentLevel.Layer3.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Rectangle(x * CurrentLevel.TileWidth - (int)CameraPosition.X, y * CurrentLevel.TileHeight - (int)CameraPosition.Y, CurrentLevel.TileWidth, CurrentLevel.TileHeight),
                                               TextureManager.GetTileSource(CurrentLevel.Layer3.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White);
                    // If the tile is null, skip it
                    else
                        continue;

                    if (CurrentLevel.Layer4.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Rectangle(x * CurrentLevel.TileWidth - (int)CameraPosition.X, y * CurrentLevel.TileHeight - (int)CameraPosition.Y, CurrentLevel.TileWidth, CurrentLevel.TileHeight),
                                               TextureManager.GetTileSource(CurrentLevel.Layer4.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White);
                    // If the tile is null, skip it
                    else
                        continue;

                    if (CurrentLevel.Layer5.Tiles[x, y] != null)
                        Variables.SpriteBatch.Draw(Variables.Textures.TileSets[LevelManager.CurrentLevelID],
                                               new Rectangle(x * CurrentLevel.TileWidth - (int)CameraPosition.X, y * CurrentLevel.TileHeight - (int)CameraPosition.Y, CurrentLevel.TileWidth, CurrentLevel.TileHeight),
                                               TextureManager.GetTileSource(CurrentLevel.Layer5.Tiles[x, y].ID, LevelManager.CurrentLevelID),
                                               Color.White);
                    // If the tile is null, skip it
                    else
                        continue;
                }
            }
        }

        private static void DrawProjectiles()
        {
        }

        private static void DrawItems()
        {
        }

        private static void DrawEntities()
        {
        }

        private static void DrawUI()
        {
        }

        private static void DrawCursor()
        {

            Variables.SpriteBatch.Draw(
                Variables.Textures.Miscellaneous[0],
                Mouse.GetState().Position.ToVector2() - new Vector2(1, 1),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                3f,
                SpriteEffects.None,
                0f);
        }
    }
}
