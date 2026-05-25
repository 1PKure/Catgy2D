# Frogger 2D - TP2

Unity 2D project developed for TP2.  
The game is based on the classic Frogger concept: the player must cross lanes with moving cars and reach the goal without getting hit.

## Gameplay

The player controls a cat starting at the bottom of the level.  
The goal is located at the top of the screen.

Cars move horizontally through three different lanes. Each lane has its own speed, direction, spawn interval and car sprite.

If the player collides with a car, they return to the starting position.  
If the player reaches the goal zone, the win scene is loaded.

## Controls

| Key | Action |
|---|---|
| W | Move up |
| S | Move down |
| Esc | Pause |

## Scenes

| Scene | Description |
|---|---|
| MainMenuScene | Main menu with Play and Quit buttons |
| GameScene | Main gameplay scene |
| WinScene | Victory screen with return to menu option |

## Architecture

The project uses a simple MVC structure.

### Model

Stores game data and logical state.

Main scripts:

- GameState.cs
- LaneData.cs
- PlayerModel.cs

### View

Handles visual and audiovisual feedback.

Main scripts and components:

- PlayerView.cs
- CarView.cs
- SpriteRenderer
- Animator
- Canvas
- AudioManager

### Controller

Coordinates gameplay logic, input, spawning, collisions, pause and scene changes.

Main scripts:

- GameController.cs
- PlayerController.cs
- CarController.cs
- LaneSpawner.cs
- PauseController.cs
- SceneLoader.cs

## Main Features

- 2D Frogger-style gameplay
- Player movement with W and S
- Three car lanes
- Different car speed, direction and spawn interval per lane
- Collision reset system
- Win condition
- Main menu
- Pause menu
- Win screen
- Animated player character
- Different car sprites per lane
- MVC-based project organization

## Credits

sound fx & music: https://brackeysgames.itch.io/brackeys-platformer-bundle
player (cat): https://last-tick.itch.io/animated-pixel-cats-64x64
car assets: / https://kenney.nl/assets/racing-pack
background assets: https://free-game-assets.itch.io/free-race-track-tile-set

## Author
[Matias Pulido](https://www.linkedin.com/in/pulidomatias/])
