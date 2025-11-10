# 2D Maze Game (Unity)

## General Description

This project is a 2D maze game created in Unity.

The player is a red cube that starts in the center of the screen.

**Goal of the game:**  
Guide the red cube out of the maze through a single exit point located at the edge of the maze.  
When the player reaches the exit:

- A victory screen is displayed.
- The player can start a new game.

---

## Player Movement – `PlayerMovement`

The player’s movement is controlled by a script called `PlayerMovement`:

- The script is attached to the player object (the red cube).
- The player receives input from the keyboard (Arrow keys / WASD), both on the horizontal and vertical axes.
- From the input, a single movement vector is calculated and normalized so that diagonal movement is not faster than straight movement.

Movement is handled through a `Rigidbody2D` component:

- The player does not “teleport” between positions, but moves smoothly using Unity’s physics system.
- The script uses a predefined speed and the time that passed between frames (`deltaTime`) to create smooth and constant movement.

**Result:** The player is a red cube that moves smoothly inside the maze, according to the user’s input.

---

## Collision and Walls – `Rigidbody2D` + `BoxCollider2D`

To make sure the player cannot move through walls:

- The player has a `BoxCollider2D` in addition to the `Rigidbody2D`.
- Each wall in the maze also has a `BoxCollider2D` (not set as a trigger).

Unity’s physics engine detects collisions between the player’s collider and the wall colliders and stops the movement.

**Result:**  
The player can move only inside the maze corridors and cannot go through the walls.

---

## Main Camera – Following the Player

The main camera in the game is set up to follow the player automatically:

- The `Main Camera` is a **child** of the player object in the hierarchy.
- The camera is positioned at a fixed distance from the player (for example, above it on the Z axis).

Because of the parent–child relationship:

- Whenever the player moves, the camera moves with it.
- The player stays in the center of the screen while moving through the maze.
- There is no need for special follow logic – making the camera a child of the player is enough for it to track the player.

---

## Win Condition – Exiting the Maze

To define a win condition:

- On one side of the maze, an exit area is created – a transparent rectangular object.
- The exit area has a `Collider2D` set as **Trigger**, so it does not behave like a wall but as a detection zone.

When the player (with the correct Tag) enters this area:

- A script such as `ExitTrigger`  detects the event.
- Debug messages can be printed to the Console (for testing).
- The victory screen is shown.
- Game time is stopped by setting `Time.timeScale = 0`, so the game is “frozen” at the moment of victory.

**Result:**  
The player wins when they exit the maze through the dedicated exit area at the maze boundary.

---

## Victory Screen and Restart – `Canvas`, `ExitTrigger`, `GameManager`

### Canvas and Victory Panel

To show the player that they have won and allow them to start again:

- A `Canvas` is used.
- On the Canvas, a `Panel` is created, which serves as the victory window (`winPanel`), with text and a button.
- The panel is disabled by default and is only enabled when the player wins.

When the player enters the exit area:

- The `ExitTrigger` script activates the `winPanel`.
- `Time.timeScale` is set to `0`, stopping movement and physics.

### `GameManager` – New Game Logic

To handle restarting the game, a `GameManager` script is used:

- The `GameManager` contains a function that is connected to the “New Game” button.
- When the button is pressed:
  - `Time.timeScale` is set back to `1` (to resume normal time).
  - The current scene is reloaded using Unity’s scene management system.

**Result:**  
The game resets:

- The player is returned to the starting position.
- The maze is reloaded.
- The player can start a new attempt.

---

## Mini-Map Camera – `Camera_Mini_World`

In addition to the main camera, the game includes another camera called `Camera_Mini_World`, which displays the entire maze as a mini-map in a corner of the screen.

---

## Fitting the Mini-Map to the Maze – `MiniMapFitCamera`

To make sure the mini-map always shows the entire maze correctly, even when switching between 16:9 and 9:16 aspect ratios:

- A script called `MiniMapFitCamera` is used.
- Every frame, the script calculates the current screen aspect ratio:

  ```text
  aspect = screen width / screen height
  ```

- According to the the aspect ratio:
  - If the ratio is greater than 1 – landscape mode (around 16:9): use maze width/height values that match a landscape layout.
  - If the ratio is less than or equal to 1 – portrait mode (around 9:16): use different width/height values suited for a portrait layout.

Based on the maze dimensions and the current aspect:

- The script calculates the correct orthographic size (`orthographicSize`) for the mini-map camera so that the entire maze fits inside the view.
- The calculation considers both vertical and horizontal axes and chooses the size that guarantees no part of the maze is cut off.

**Goal:**  
Keep the mini-map showing the entire maze without stretching or cutting, for any screen aspect ratio.

---

## Mini-Map Viewport Layout – `MiniMapViewportSwitcher`

To keep the mini-map window looking good in both 16:9 and 9:16:

- A script called `MiniMapViewportSwitcher` is used.
- The script stores two viewport rectangle configurations (`Viewport Rect`):
  - `rectLandscape` – for landscape mode (for example, a wide rectangle in a corner).
  - `rectPortrait` – for portrait mode (a shape suitable for a tall screen).

Every frame, the script checks the screen’s aspect ratio:

- If the screen is in landscape – the camera uses the landscape viewport rectangle.
- If the screen is in portrait – the camera uses the portrait viewport rectangle.

**Result:**  
The mini-map:

- Keeps a correct aspect ratio.
- Appears in a comfortable position on the screen.
- Does not cover the main gameplay area or stretch in a strange way.

---

## Summary

In this 2D maze game:

- The player is a red cube in the center of the screen, moving with the `PlayerMovement` script and a `Rigidbody2D`.
- `BoxCollider2D` on the player and the walls prevent passing through walls, so the player can move only inside the maze corridors.
- The main camera is a child of the player and automatically follows them.
- A single exit point, defined as a transparent trigger, serves as the win condition – when the player enters it, a victory screen appears.
- A `Canvas`, together with  `ExitTrigger` and `GameManager`, handles showing the victory screen and starting a new game.
- A mini-map camera (`Camera_Mini_World`) displays the whole maze and adjusts its size and position for 16:9 and 9:16 using `MiniMapFitCamera` and `MiniMapViewportSwitcher`.


## Link to itoch.io:
["Site:"](https://amit-and-gal.itch.io/2d-maze-game)
