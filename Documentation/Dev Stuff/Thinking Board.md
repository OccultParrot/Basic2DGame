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
