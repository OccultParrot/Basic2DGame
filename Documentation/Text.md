# Textboxes & Such

In this file, I will be going over all the different ways text is send or collected in this game.

# Table of Contents

- [An Overview of What's to Come](#an-overview-of-whats-to-come)
- [DebugString](#debugstring)
	* [LifeSpan](#lifespan)
	* [Sending a DebugString](#sending-a-debugstring)
- [TextBox](#textbox)
- [InputBox](#inputbox)

# An Overview of What's to Come

In the Text file, there are a handful of very useful classes that you can use to print information to the screen, or let the user write somthing.

 - [DebugString](#debugstring)
 - [TextBox](#textbox)
 - [InputBox](#inputbox)

# Classes

## DebugString

The DebugString class is used to print information to the debug screen. The information found in these is as follows:
Text, the text that is printed to the screen.
[LifeSpan](#lifespan), how long the text is displayed for, in frames.
Color, the color of the text when it is displayed.

### LifeSpan

The life span variable is a very important part of a debug string.
If the life span is set to a number larger than 0, the string will be displayed for that many frames. 
If it is LOWER than 0, it is displayed indefinably.
If the life span is set to 0, it will never be displayed and will be culled in the next frame.

Examples:

```csharp
// This will be displayed for 60 frames.
DebugString.Add("Hello World!", 60, Color.White);

// This will be displayed forever.
DebugString.Add("Hello World!", -1, Color.White); 

// This will never be displayed.
DebugString.Add("Hello World!", 0, Color.White); 
```

### Sending a DebugString

To send a debug string, you can do it in three ways. 

You can use the Add method found in the DebugString class, like this:

```csharp
// Sends the string "Hello World!" to the debug console, with a life span of 60 frames, and a color of white.
DebugString.Add("Hello World!", 60, Color.White);
```

You can also just make a new one:

```csharp
// We use "_" because it is a temporary variable.
_ = new DebugString("Hello World!", 60, Color.White);
```

Lastly, you can manually add it to the list. The way to stop it from automatically being displayed is that you set the variable "AddToDebugStrings" to false during the constructor.
I don't know why you would want to do this, but you can.

```csharp
// Makes a new debug string, but does not add it to the list.
DebugString debugString = new DebugString("Hello World!", 60, Color.White, false);

// Adds the debug string to the list.
GlobalData.DebugStrings.Add(debugString);
```

## TextBox

:warning: **THIS CLASS IS NOT FINISHED YET!** :warning:

This class is used to display text on the screen. If you are looking for a way to get input from the user, you should look at the [InputBox](#inputbox) class.

In this class, there are a couple of variables that you can change to change the way the text box is displayed.

- Text, the text that is displayed in the text box.

## InputBox

:warning: **THIS CLASS IS NOT FINISHED YET!** :warning:

