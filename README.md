# Mario

A Mario-like 2D platformer made in Unity 2022.3.10f1.

The player can run and jump, collect a coin, and swing on a grappling hook in one short platformer level. That level also includes an enemy, a moving platform, a score counter, heart icons, and a jump particle effect. A separate menu scene provides Play and Exit buttons. This is a student game project.

## What's in the project

The Unity project lives in the `My game/` folder. `My game/ProjectSettings/ProjectVersion.txt` records editor version 2022.3.10f1 (revision `ff3792e53c62`). Project settings use the Unity 2D template (`com.unity.template.2d`).

Scenes:

- `My game/Assets/Scenes/Menu.unity` is the menu. It is outside Build Settings.
- `My game/Assets/Scenes/Platformer Level.unity` is the playable level, and the only scene enabled in Build Settings.
- `My game/Assets/Scenes/SampleScene.unity` is a small jump test. It is outside Build Settings.

Scripts in `My game/Assets/`:

| Script | Role |
|--------|------|
| `Player.cs` | Horizontal movement, grounded jump, coin collection, and grappling input in the platformer level |
| `Jump.cs` | Upward force on Space, with no ground check. No scene references this script. The class name is `NewBehaviourScript`. |
| `ImprovedJumping.cs` | Grounded jump and jump smoke in SampleScene. The class name is `Jump`. |
| `EnemyBehaviour.cs` | Enemy patrol movement and facing |
| `EnemyInteraction.cs` | Enemy contact removes one heart and starts a three-second invulnerability window |
| `EnemySlammer.cs` | Destroys an enemy on trigger overlap |
| `PlatformController.cs` | Moving platforms that carry the player |
| `Hook.cs` | Grappling hook, using a distance joint and a rope line |
| `ScoreCounter.cs` | Increments and displays the score |
| `SpecialEffects.cs` | Coin sound, plus smoke particles used by the sample jump script |
| `UiMenu.cs` | Loads build index 0, and defines an application quit method |
| `UiInstanceController.cs` | Creates and removes heart icons (four at start) |
| `BoundingSwitch.cs` | Enables a child virtual camera while the player is inside the trigger. It is on `Prefabs/Boundingbox.prefab`, and no scene saves an instance of that prefab. |
| `EdgeDetector.cs` | Turns a patrolling enemy around at a ground edge |

GitHub language detection currently lists ShaderLab first, then C#, then HLSL. The ShaderLab share comes from the TextMesh Pro shader assets. The gameplay code is C#.

## How to play

In the platformer level, with the legacy Input Manager:

- Move left and right with the arrow keys or A and D.
- Jump with Space while a short downward raycast hits something.
- Toggle the grappling hook with F.

A pickup tagged `Coin` raises the score by 1 and plays the coin sound. Touching an enemy removes one heart. When the heart stack is empty, further hits do nothing. There is no game-over scene.

## How to open

1. Install Unity Hub and Unity 2022.3.10f1, the editor version stored in `My game/ProjectSettings/ProjectVersion.txt`. If Hub offers a different editor, review the upgrade dialog before continuing.
2. Open the `My game` folder as the Unity project.
3. Open the Menu scene or the Platformer Level scene and press Play.

A built player starts in Platformer Level, because that is the only scene in Build Settings. To see the menu, open `Menu.unity` in the editor and press Play.

The menu title reads MENU. PLAY calls `UiMenu.LoadLevel`, which loads build index 0 (Platformer Level). EXIT calls `UiMenu.ExitApp`, which quits a built player and does nothing in the editor.
