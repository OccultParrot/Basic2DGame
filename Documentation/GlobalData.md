# Global Data Documentation

In this file, I will explain all the information that can be found in the GlobalData struct.

# Table of Contents

 - [Variables](#variables)

# Variables

| Name                       | Type                    | Description                                                |
|----------------------------|-------------------------|------------------------------------------------------------|
| IsDebugShown               | bool                    | When true, the debug console is rendered.                  |
| SpriteBatch                | SpriteBatch             | The SpriteBatch used to draw everything in the game.       |
| Graphics                   | GraphicsDeviceManager   | The GraphicsDeviceManager for this project.                |
| StandardFont               | SpriteFont              | The default font used for rendering text.                  |
| ItalicStandardFont         | SpriteFont              | The default font used for rendering text (Italics, Broken).|
| Content                    | ContentManager          | The ContentManager used for this project.                  |
| Viewport                   | Viewport                | The viewport used for this project.                        |
| ScaleMatrix                | Matrix                  | The matrix used to scale the game.                         |
| DesiredWindowWidth         | int                     | The width of the window.                                   |
| DesiredWindowHeight        | int                     | The height of the window.                                  |
| DebugStrings               | List of Debug Strings   | The list of strings displayed on the debug console.        |
| Missing (Entities list)    | // Sorry, Missing!      | The list of entities in the game.                          |
| PreviousKeyboardState      | KeyboardState           | The last state of the keyboard.                            |
| PreviousMouseState         | MouseState              | The last state of the mouse.                               |
| CurrentMap                 | Map                     | The current map the player is on.                          |
| KeyBinds                   | Dictionary<string, Keys>| A dictionary containing all the key binds for the game.    |

