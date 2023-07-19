# Tile Map Documentation

In this document, I will explain how to use the map and tile classes, along with the camera and how to use them.

## Table of Contents

 - [Map Class](#map-class)
	* [Map Properties](#map-properties)
	* [Map Methods](#map-methods)

 - [Tile Class](#tile-class)
	* [Tile Methods](#methods)
		+ [GetProperty](#getproperty)
		+ [SetProperty](#setproperty)
		+ [ListProperties](#listproperties)
	* [Tile Properties](#properties)
 
 - [Camera struct](#camera-struct)

# Map Class

This class holds all of the data for the map.
On initialization, you must pass in the file path to the map file, I recommend making a folder in your project dedicated to storing maps.
An example for initializing a map is as follows:

```csharp
Map map = new Map("Maps\\ExampleMap.xml");
```

## Map Properties
The map class has a few properties that you can use to get information about the map.

A list of all the properties is as follows:

| Property     | Use 
|--------------|----
| Name         | The name of the map
| Author       | The author of the map
| Description  | The description of the map
| Version      | The version of the map
| Width        | The width of the map in tiles
| Height       | The height of the map in tiles
| TileWidth    | The width of each tile in pixels
| TileHeight   | The height of each tile in pixels
| Tileset      | The path to the tileset image for the map
| MapData      | A 2D array of all the tiles in the map
| VisibleTiles | A 2D array of all the tiles that are visible in the map

## Map Methods

None here yet lol :P

# Tile Class

This class holds all of the data for a tile.
Rarely will you ever need to initialize the tile class yourself, as the map class will do it for you,
but if you do, here is how.

```csharp
Tile tile = new();
```

In the Tile class there are two variables, a Vector2 for position and a Dictionary for properties.
The dictionary is used to store any custom properties that you may want to add to the tile, such as rotation, or if the player can walk on it.
Both the key and the value of the dictionary are strings, so you can store any type of data you want in the dictionary.

## Methods

### GetProperty

This method is used to get the value of a property if present in the dictionary.

```csharp
// Getting the value of the property "Collision" from the tile
string collision = tile.GetProperty("Collision");
```

### SetProperty

This method is used to set the value of a property in the dictionary.
```csharp
// Setting the value of the property "Collision" to "true"
tile.SetProperty("Collision", "true");
```

### ListProperties

This method will list all the properties in the tile and their values in the debug console.

```csharp
// Listing all the properties in the tile
tile.ListProperties();
```

Prints:

```txt
Properties in Tile:
===================
Collision: true
Rotation: 0
Visible: true
Layer: 0
Color: Color.White // I don't actually know what it will print for color, I haven't tested it yet.
```

## Properties

There are a few properties in the tile class that you can use to get information about the tile.

| Property  | Default Value | Use                                             |
|---------- |---------------|-------------------------------------------------|
| Collision | false         | Whether or not the player can walk on the tile. |
| Rotation  | 0             | The rotation of the tile in degrees.            |
| Visible   | true          | Whether or not the tile is visible.             |
| Layer     | 0             | The layer that the tile is on.                  |
| Color     | Color.White   | The color the tile texture is printed on.       |

# Camera struct

The camera struct is used to control the camera in the game.
It has a few properties that you can use to get information about the camera, such as Position and Zoom.

Position is a Vector2 and tells you where the camera is in the tile map.

Zoom is a float, and tells you how zoomed in the camera is.

Right now the camera is not finished, but it should be soon.
