# Managers

## Table of Contents

 - [Introduction](#introduction)
 - Managers
    - [Render Manager](#render-manager)
    - [Texture Manager](#texture-manager)
    - [Level Manager](#level-manager)
 - [Classes](#classes)
    - [Level](#level)
    - [Layer](#layer)
    - [Tile](#tile)
 - [Texture List](#texture-list)
    - [Tile Sets](#tile-sets)
    - [Ground Cover](#ground-cover)
    - [Trees](#trees)
    - [Items](#items)
    - [Entities](#entities)
    - [UI](#ui)
    - [Miscellaneous](#miscellaneous)

## Introduction

Managers are special structs that are used to manage the state of a game.
They do things such as rendering, updating, and handling inputs.

List of managers, and their uses:

| Manager                             | Description                                    |
| ----------------------------------- | ---------------------------------------------- |
| [Render Manager](#render-manager)   | Manages the rendering of the game.             |
| [Texture Manager](#texture-manager) | Manages the loading and unloading of textures. |
| [Level Manager](#level-manager)     | Manages the loading and unloading of levels.   |

## Render Manager

The render manager is used to render the game. It renders in a specific order:
 1. The map
 2. Ground Cover (grass, flowers, etc.)
 3. Trees
 4. Projectiles
 5. Items
 6. Entities
 7. UI
 8. Cursor

There is only one method, `Draw`, which renders the game.

Example:

```csharp
// In Game1.cs
protected override void Draw(GameTime gameTime)
{
    GraphicsDevice.Clear(Color.CornflowerBlue);

    // Render the game
    RenderManager.Draw();

    base.Draw(gameTime);
}
```

## Texture Manager

The texture manager is used to load and unload textures. It is used by the render manager to render the game along with other stuff.

There are two methods, `Load` and `GetTileSource`.

There are seven texture dictionaries, where each texture is assigned a number, and that number is used to get the texture.

| Texture Dictionary | Description                                                                 |
| ------------------ | --------------------------------------------------------------------------- |
| `TileSets`         | Contains all tile sets used to render the levels.                           |
| `GroundCover`      | Contains all ground cover textures used to render the ground cover.         |
| `Trees`            | Contains all tree textures used to render the trees.                        |
| `Items`            | Contains all item textures used to render the items.                        |
| `Entities`         | Contains all entity textures used to render the entities.                   |
| `UI`               | Contains all UI textures used to render the UI.                             |
| `Miscellaneous`    | Contains all miscellaneous textures used to render the cursor and particles |

A list of every texture and their key can be found in the [Texture List](#texture-list) section.

### Load

The `Load` method is used to load all textures.

Example:

```csharp
// In Game1.cs
protected override void LoadContent()
{
	// Load all textures
	TextureManager.Load(Content);
	base.LoadContent();
}
```

### GetTileSource

This method is one you will rarely use. It is used to get the source rectangle of a tile in a tile set.

It is a static method, so you don't need to create an instance of the texture manager to use it.

Example:

```csharp
Rectangle SourceRectangle = TextureManager.GetTileSource(CurrentLevel.Layer0.Tiles[x, y].ID
```

## Level Manager

The level manager is used to manipulate the levels of the game.

There is one method, `Load` which is used to load all the levels.

There is three properties though, [`CurrentLevelID`](#currentlevelid), CurrentLevel, and `Levels`

### CurrentLevelID

CurrentLevelID is commonly used in combination with the [TextureManager](#texture-manager) dictionary `TileSets` because the level id corresponds to the tile set that uses that number as its key.

### CurrentLevel

Current level is used to fetch the current level that is in use rather than having to type `Levels[CurrentLevelID]`

### Levels

Levels is a dictionary that holds an instance of the [Level](#level) class corrosponding to a specific key.

The list of every level in this dictionary is as follows:

<!-- Lol, not much here yet -->

| Level Name  | Key |
| ----------- | --- |
| Testing Map | -1  |

# Classes

In some of the managers, there are classes used in them, such as how the [Level Manager](#level-manager) uses the [Level](#level) class.

## Level

The level class is used to store all the data of a level.
It has several properties, and a constructor.

A list of all the properties and their descriptions can be found below:

| Property | Description |
| -------- | ----------- |
| `XmlPath` | The path to the xml file that contains the level data. |
| `Name` | The name of the level. |
| `Width` | The width of the level in tiles. |
| `Height` | The height of the level in tiles. |
| `TileWidth` | The width of a tile in pixels. |
| `TileHeight` | The height of a tile in pixels. |
| `Layer0` | The first layer of the level. |
| `Layer1` | The second layer of the level. |
| `Layer2` | The third layer of the level. |
| `Layer3` | The fourth layer of the level. |
| `Layer4` | The fifth layer of the level. |
| `Layer5` | The sixth layer of the level. |

The constructor takes in the path to the xml file that contains the level data, along with the name of the level.

Each layer is an instance of the [Layer](#layer) class.

## Layer

The layer class is used to store the data of a layer in a level.
It has several properties.

A list of all the properties and their descriptions can be found below:

| Property | Description |
| -------- | ----------- |
| `Tiles` | A 2D array of tiles. |
| `Name` | The name of the layer. |
| `Number` | The number the layer is. This is used in the saving of a level. |

The `Tiles` property is a 2D array of tiles, where each tile is an instance of the [Tile](#tile) class.

## Tile

The tile class is used to store the data of a tile in a layer. It has a few properties.

A list of all the properties and their descriptions can be found below:

| Property | Description |
| -------- | ----------- |
| `ID` | The location of the tile in the tile set. |
| `Rotation` | The rotation of the tile. |
| `FlipX` | Whether or not the tile is flipped on the x axis. |

# Texture List

This is a list of all the textures in the game, and their key. They are sorted by which atlas they belong to, and their number

## Tile Sets

| Texture Name | Key |
| ------------ | --- |
| Testing Map  | -1  |

## Ground Cover

| Texture Name | Key |
| ------------ | --- |

## Trees

| Texture Name | Key |
| ------------ | --- |

## Items

| Texture Name | Key |
| ------------ | --- |

## Entities

| Texture Name | Key |
| ------------ | --- |

## UI

| Texture Name | Key |
| ------------ | --- |

## Miscellaneous

| Texture Name | Key |
| ------------ | --- |
| Cursor       | 0   |
