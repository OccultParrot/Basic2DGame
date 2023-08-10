using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic2DGame.Systems
{
    public class RenderSystem
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
            DrawGroundCover();
            DrawTrees();
            DrawProjectiles();
            DrawItems();
            DrawEntities();
            DrawUI();
            DrawCursor();

            Variables.SpriteBatch.End();
        }

        private static void DrawMap()
        {
            /* The order for rendering the map.
             * 1. Draw the background layer.
             * 2. Draw the foreground layer.
             * 3. Draw the Ground Cover layer.
             */

            // Drawing each level.
            DrawLayer(LevelManager.Levels[LevelSystem.CurrentLevelID].Background);
            DrawLayer(LevelManager.Levels[LevelSystem.CurrentLevelID].Foreground);
            DrawLayer(LevelManager.Levels[LevelSystem.CurrentLevelID].GroundCover);
        }

        private static void DrawLayer(Tile[,] layer)
        {

        }

        private static void DrawGroundCover()
        {
        }

        private static void DrawTrees()
        {
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
                Mouse.GetState().Position.ToVector2() - new Vector2(1,1),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                3f,
                SpriteEffects.None,
                0f);

            Variables.SpriteBatch.End();
        }
    }

    public class LevelSystem
    {
        public static int CurrentLevelID { get; set; }
    }
}