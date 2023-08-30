using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Basic2DGame.GameFiles.Managers;
using System.Collections.Generic;

using System;

namespace Basic2DGame.GameFiles.Sprites;

public class Sprite
{
    // The Texture
    public Texture2D Texture { get; set; } // Public temporarily.

    // Component List. All unique information is stored here.
    public List<SpriteComponent> Components { get; private set; }

    // Constructor
    public Sprite(int textureID, int textureAtlas, List<SpriteComponent> components)
    {
        MapPosition = position;
        Texture = Variables.Textures.GetTextureFromAtlas(textureAtlas, textureID);
        Components = components;
    }

    public void SetComponent<T>(T component) where T : SpriteComponent
    {
        if (GetComponent<T>() != null)
        {
            //GetComponent<T>() = component;
        }
    }

    public T GetComponent<T>() where T : SpriteComponent
    {
        foreach (SpriteComponent component in Components)
        {
            if (component is T desiredComponent)
            {
                return desiredComponent;
            }
        }
        return null; // Component not found
    }
}

// The blank sprite component. No unique information stored. All sprite components inherit from this one
public class SpriteComponent
{
    // The counter for creating unique IDs
    private static int idCounter = 0;

    // The id of the sprite component
    private readonly int _id;

    public SpriteComponent()
    {
        _id = idCounter++; // Giving the sprite component an unique id.
    }
}

// The sprite component that holds position information.
public class PositionSpriteComponent : SpriteComponent
{
    // The position of the sprite
    private float _x;
    private float _y;

    // Two different ways to access the position
    public Vector2 GridPosition
    {
        get
        {
            return new(_x, _y);
        }
        set
        {
            if (value.X < 0 || value.Y < 0)
            {
                throw new Exception("Grid position cannot be negative");
            }
            else
            {
                _x = value.X;
                _y = value.Y;
            }
        }
    }

    public Vector2 ScreenPosition
    {
        get
        {
            return (new Vector2(GridPosition.X * LevelManager.CurrentLevel.TileWidth, GridPosition.Y * LevelManager.CurrentLevel.TileHeight) + Camera.Position);
        }
    }

    // The constructors
    public PositionSpriteComponent(float x = 0, float y = 0)
    {
        _x = x;
        _y = y;
    }

    public PositionSpriteComponent(Vector2 position)
    {
        _x = position.X;
        _y = position.Y;
    }
}