# Unity Gameplay Demo

Tuto Given by UCSB Gaucho game lab.

This Unity project demonstrates a small interactive game built using Unity's **New Input System**, physics-based mechanics, and a modular sound and UI system. The player must interact with the environment, collect objects, and complete challenges to reach the finish.

---

## 🎮 Features

### ✅ Player Movement (New Input System)
- Movement and jumping are handled using Unity’s New Input System.
- Implements a basic **state machine** with states: `GROUNDED`, `IN_AIR`, and `DEAD`.
- Smooth acceleration and responsive physics using `Rigidbody`.

### 🕹️ Pressure Plate & Door Mechanism
- Standing on a **pressure plate** opens a door.
- Doors use `Coroutine` animations to move smoothly between open and closed positions.

### 💰 Coin Collection System
- Collecting coins triggers a counter.
- Upon collecting all coins, a door opens to allow progression.

### 🎯 Final Door: Ball Catch Challenge
- For the final door, a unique **"catch the ball"** mechanic is implemented.
- Picking up the required ball unlocks the last door.

### 🏁 Win / ❌ Lose Conditions
- **Win**: Reaching the finish line triggers a win message and restarts the game after a delay.
- **Lose**: Leaving the play area bounds shows a game over message and restarts the game after a delay.

### 🔊 Audio Manager
- Centralized `AudioManager` manages music and SFX using custom `Sound` structs.
- Sound plays on:
  - Jump
  - Button interactions
  - Coin collection
  - Door actions
  - Win/Loss events
- Background music plays automatically on game start.

### 🎚️ Settings Panel
- Press **Escape** or **Return** to toggle a settings UI panel.
- Panel includes sliders to adjust:
  - Music volume
  - SFX volume
- Changes are applied live via `AudioSource.volume`.

---

## 🛠️ Getting Started

### Requirements
- Unity Editor (version 2021+ recommended)
- Input System package (Install via Package Manager)

### How to Play
1. Clone or download this repository. YOu might need to reinstall or download some assets (notably sounds). cause i don't know the rights for most of these assets.
2. Open the project in Unity.
3. Press Play in the Unity Editor.
4. Use WASD / arrow keys + Space to control the player.
5. Interact with objects to progress and win.

---

## Demo

https://github.com/user-attachments/assets/f580879b-3107-4110-9609-d814ad0d3d14

https://github.com/user-attachments/assets/a84926bf-0e22-4eaa-a86d-5ea8b783146a

--- 

## 📌 Notes

- UI volume sliders are visually implemented and partially wired; backend logic is ready for future improvements.
- Project is modular and open for extensions like saving volume settings or adding checkpoints.

---

## 📜 License

MIT License - feel free to use, modify, and expand.

---
