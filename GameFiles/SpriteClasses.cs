using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Basic2DGame.GameFiles.ClassLib;

public class Sprite
{
    // Position properties
    private int _x;
    private int _y;

    // Texture properties
    public Texture2D Texture {get; set;} // Public temporaraly.

    public SpriteComponent[] Components {get; private set;}

    // Public Properties
    public Vector2 MapPosition
    {
        get
        {
            return new Vector2(_x, _y);
        }
        set 
        {
            _x = value.X;
            _y = value.Y;
        }
    }

    public Vector2 ScreenPosition
    {
        get 
        {
            return 
            (
                new Vector2(
                    MapPosition.X * LevelManager.CurrentLevel.Width, 
                    MapPosition.Y * LevelManager.CurrentLevel.Height
                    ) + Camera.Position
            );
        }
    }

    // Constructor
    public Sprite(int textureID, int textureAtlas, Vector2 position = new(0, 0), SpriteComponent[] components = new())
    {
        MapPosition = position;
        Texture = Variables.Textures.GetTextureFromAtlas(textureAtlas, textureID);
        Components = components;
    }

    public void SetComponent<T>(T component)
    {
        
    }
}

// The blank sprite component. No unique information stored.
public struct BlankSpriteComponent
{
    // The counter for creating unique IDs
    private static int idCounter = 0;

    // The id of the sprite component
    private int _id;

    public SpriteComponent()
    {
        _id = _idCounter++; // Giving the sprite component an unique id.
    }
}