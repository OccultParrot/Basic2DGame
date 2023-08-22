We have the cameras position, and size.
In order to find the visible area, we need to find the 4 corners of the camera.
We can do this by using the camera's position, and the camera's size.

by using the camera's position, we can find the first corner, and the first visible tile, which is the cameras position rounded down.

```csharp
// The camera's position is 5.23, 3.45
Camera.Position = new Vector2(5.23, 3.45)

// The first visable tile is at is 5, 3 on the map.
int RoundedPositionX = (int)Math.Floor(Camera.Position.X); // 5
int RoundedPositionY = (int)Math.Floor(Camera.Position.Y); // 3

// The offset is the distance from the camera's position, to the first visable tile.
float XOffset = Camera.Position.X - RoundedPositionX; // 0.23
float YOffset = Camera.Position.Y - RoundedPositionY; // 0.45

// The current map is the map that the camera is currently on.
Map CurrentMap = MapSystem.Map;

// The first visable tile is the tile at the camera's position rounded down.
Tile FirstVisableTile = CurrentMap.GetTile(RoundedPositionX, RoundedPositionY);
```

Now that we have the first visible tile, we can find the other 3 corners of the camera.

```csharp
int CameraWidth = Camera.Viewport.Width;
int CameraHeight = Camera.Viewport.Height;

// The last visible tile is the tile at the camera's position, plus the camera's size divided by the tile size.
Tile LastVisableTile = CurrentMap.GetTile(RoundedPositionX + (CameraWidth / CurrentMap.TileWidth), RoundedPositionY + (CameraHeight / CurrentMap.TileHeight));
```

Now that we have the first and last visible tiles, we can find the correct tiles to draw, and where to draw them.
```csharp
// The first visible tile is the tile at the camera's position rounded down.
Tile FirstVisableTile = CurrentMap.GetTile(RoundedPositionX, RoundedPositionY);

// The last visible tile is the tile at the camera's position, plus the camera's size divided by the tile size.
Tile LastVisableTile = CurrentMap.GetTile(RoundedPositionX + (CameraWidth / CurrentMap.TileWidth), RoundedPositionY + (CameraHeight / CurrentMap.TileHeight));

// Now, we can loop through the tiles on screen, and draw them.
for (int y = RoundedPosition.Y; y <= LastVisableTile.Y; y++)
{
	for (int x = RoundedPosition.X; x <= LastVisableTile.X; x++)
	{
		Tile CurrentTile = CurrentMap.GetTile(x, y);
		// Draw the tile here.
	}
}
```

I really hope this works, because I have spent a while coming up with this idea.


# Cameras Position and stuff...

Stuff we need to know:
The view port (Vector2), or the size of the area the camera can move around in.
The cameras position (two int variables), or where the camera is on the view port.

## The View Port

The view port is the area of the map, in tiles times the area of a tile.

```csharp
// First we define the size of the map in tiles.
int MapWidth = MapSystem.Map.TilesWide;
int MapHeight = MapSystem.Map.TilesHigh;

// Then we define the size of a tile.
int TileWidth = MapSystem.Map.TileWidth;
int TileHeight = MapSystem.Map.TileHeight;

// Now we can find the size of the view port!
int ViewPortWidth = MapWidth * TileWidth;
int ViewPortHeight = MapHeight * TileHeight;

// Now we can create the view port!
Vector2 ViewPort = new Vector2(ViewPortWidth, ViewPortHeight);
```

## The Cameras Position

The cameras position is the position of the camera on the view port.

```csharp
// The cameras position is 5, 45
Camera.X = 5;
Camera.Y = 45;
```

The cameras position is kinda the easy part.

# Finding visible tiles

Now that we have the cameras position, and the view port, we can find the visible tiles.

First we need to know the position on the map of the top left tile.

```csharp
// The position of the top left tile is the cameras position divided by the tile size.
int TopLeftTileX = Camera.X / TileWidth;
int TopLeftTileY = Camera.Y / TileHeight;
```	

Now that we have the position of the top left tile, we can find the position of the bottom right tile.

... I have no idea how to do this. lol

first we figure out how wide and tall the camera is in tiles.

```csharp
// The width of the camera in tiles is the window width divided the camera zoom, divided by the tile width.
int CameraWidthInTiles = (int)Math.Floor(WindowWidth / (Camera.Zoom * GlobalData.Scale) / TileWidth);

// The height of the camera in tiles is the window height divided the camera zoom, divided by the tile height.
int CameraHeightInTiles = (int)Math.Floor(WindowHeight / (Camera.Zoom * GlobalData.Scale) / TileHeight);
```

Now, The bottom right tile is the top left tile, plus the width and height of the camera in tiles.

```csharp
// Calculating the bottom right tile.
int BottomRightTileX = TopLeftTileX + CameraWidthInTiles;
int BottomRightTileY = TopLeftTileY + CameraHeightInTiles;
```

# Drawing the tiles

Now that we have both the top left tile, and the bottom right tile, we can draw the tiles.

```csharp
// Looping through the tiles.
for (int y = TopLeftTileY; y <= BottomRightTileY; y++)
{
	for (int x = TopLeftTileX; x <= BottomRightTileX; x++)
	{
		// Get the current tile.
		Tile CurrentTile = MapSystem.Map.GetTile(x, y);
		
		// Draw the tile here.
	}
}
```

Here's to hoping this works. :/

I think I finally have the tile stuff done for now, except for the rendering part. :D

# new and improved tile stuff!

(also actually works)

```csharp
// We need to do the following:
// 1. Get the current level
// 2. Get the current camera position
// 3. Get the current camera size
// 4. Get the current camera zoom
// 5. 

// Zoom and stuff are unused for now.
Level CurrentLevel = LevelManager.CurrentLevel;
Vector2 CameraPosition = Variables.TEMPORARY;
float CameraZoom = 5f;

for (int y = 0; y < CurrentLevel.LevelHeight; y++)
{
    for (int x = 0; x < CurrentLevel.LevelWidth; x++)
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
```

# Camera Struct
In the camera struct we need to hold the following information:
The position of the camera in the `_x` and the `_y` properties
The zoom of the camera in the `_zoom` property.

There will be two fields in the struct
`Position`,
and `Zoom`.

## Position
When you get the position field, it will return a new Vector2 holding the `_x` and `_y` properties.

```csharp
public Vector2 Position {
	get {
		return new Vector2(_x, _y)
	};
	set {
		_x = value.X;
		_y = value.Y;
	}
}
```

## Zoom
It just returns the `_zoom` property, but is a private set.



