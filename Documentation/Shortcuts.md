# Short Cuts!

In this document, I will be covering the useful functions in the ShortCuts file.

# Table of Contents

 - [Introduction](#introduction)
 - [Functions](#functions)
	* [CatchPressedKey](#catchpressedkey)

# Introduction

A lot of times in coding you end up writing the same big chunk of code over and over, and it shouldn't be like this! 
Your wasting time writing that, when you could be using to keep writing important stuff and to fix this problem, I have ended up writing a bunch of functions that can be used to make your life easier.

# Functions

There are a lot of functions in the ShortCuts file, and I will be covering each one of them in this document.

Here is a list of them with links to them:

 - [CatchPressedKey]

Lol, there are not many yet.

## CatchPressedKey

This function is used to test if the key was pressed, but not held down. The way to do this without the shortcut is a lot of text, and requires you to make more variables, but this way uses variables found in GlobalData!

To run it, just pass through the key you are wanting to detect.

```csharp
Keys key = [The key you want to detect]

// Without the shortcut
if (Keyboard.GetState().IsKeyDown(key) && !GlobalData.PreviousKeyboardState.IsKeyDown(key))
	DoWork();

// With the shortcut
if (ShortCuts.CatchPressedKey(key))
	DoWork();
```

I know its not that much of a deal, but when you have to type the same long if statement over and over, it gets aggravating.
