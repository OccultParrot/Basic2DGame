# Title

In this document, we will be going over the extensions I have added to the game.

# Table of Contents

 - [Introduction](#introduction)
 - [What are they?](#what-are-they)
	* [DrawRectangle](#drawrectangle)

# Introduction

When using basic MonoGame, there are things you wish you could do with it, but you cannot, such as drawing a rectangle to the screen without a texture file.

# What are they?

I have added a few extensions to MonoGame:

 - [DrawRectangle](#drawrectangle)

Not many yet lol

## DrawRectangle

This extension to the sprite batch, is a way to draw a rectangle to the screen, using the supplied rectangle, and color.

To run it, pass through a rectangle and a color.

```csharp
// Defining the rectangle
Rectangle rect = new(0, 0, 32, 32);

// Defining the color of the rectangle
Color rectColor = Color.White;

// Drawing the rectangle
GlobalData.SpriteBatch.DrawRectangle(rect, rectColor);
```
