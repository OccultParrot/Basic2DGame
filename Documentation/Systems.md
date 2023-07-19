# Systems

In this document we will be covering the systems that are used in the game, and how they work.

# Table of Contents

 - [Introduction](#introduction)
 - [What is it?](#what-is-it)
 - [Implemented Systems](#implemented-systems)
	* [RenderSystem](#rendersystem)
	* [FpsSystem](fpssystem)
	* [InputSystem](inputsystem)
	* [MapSystem](mapsystem)

# Introduction

I like to separate the different sections of code into systems, that I can then use to control different parts of the game. This allows me to have a lot of control over the game, and allows me to easily add new features to the game. I will be going over each system, and how it works, and how to use it.

# What is it?

Each system is a struct, where you just have to call Update, or Draw to run that system. 
Along with those main functions, there are also other functions that you can call to do other things, such as getting the frames per second, or updating the text in the specified text box.

# Implemented Systems

In the project there are currently 4 systems, and they are:

 - [RenderSystem](#rendersystem)
 - [FpsSystem](fpssystem)
 - [InputSystem](inputsystem)
 - [MapSystem](mapsystem)

## RenderSystem

The render system draws everything to the screen, such as the map, debug screen, and all the entities. It also handles the camera, and the view of the game.

To run it, you just have to call the general render function, which will draw everything to the screen.

```csharp
RenderSystem.GeneralRender()
```

Along with the general render function, there are also other functions that you can call to draw specific things to the screen, such as the map, or the debug screen.
These are:

```csharp
// Renders the debug screen
RenderSystem.RenderDebug()

// Renders the map
RenderSystem.RenderMap()
```

## FpsSystem

The FPS system, or frames per second system, is used to get the frames per second of the game.
It is a relatively small system with only one function, Update, but it has a variable called FramesPerSecond that is the number of frames per second.

To run it, you just have to call the update function, which will update the frames per second.

```csharp
// Updates the frames per second
FpsSystem.Update()

// Getting the FPS
float fps = FpsSystem.FramesPerSecond
```

## InputSystem

The input system is used to get the input from the user, and then use that input to do something in the game.
It has two functions, Update, and AlterTextbox.

To run it, you just have to call the update function, which will update the input.

```csharp
// Updates the input system
InputSystem.Update();
```

To run the alter textbox function, you just have to call the function, and pass in the textbox that you want to alter. This function takes the users input and enters the character of it into the text box.

```csharp
// Making a new textbox
TextBox textbox = new TextBox("Hello, World!");

// Altering the textbox
InputSystem.AlterTextBox(textbox);
```

## MapSystem

:warning: THIS SYSTEM DOESN'T WORK YET! :warning:
