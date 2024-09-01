---

# 🐍 Snake Game

Welcome to the classic **Snake Game**! This is a simple yet addictive game that tests your reflexes and timing as you guide a snake to eat food while avoiding walls and its own growing tail. Let's dive into how this game works!

## 🎮 How to Play

1. **Objective**: Guide the snake to eat the food (*) that appears randomly on the grid. Each time the snake eats the food, it grows longer. The game ends if the snake hits a wall or its own tail.

2. **Controls**:
   - **Up Arrow**: Move Up
   - **Down Arrow**: Move Down
   - **Left Arrow**: Move Left
   - **Right Arrow**: Move Right

3. **Game Over**: The game ends if the snake collides with the grid boundary or its own body. When this happens, you'll see a "Game Over" message, and you can press any key to exit.

## 🚀 Game Logic Breakdown

### 1. **Game Setup**

   - **Grid**: The game is played on a grid of 30 columns by 20 rows, which represents the play area. The grid is surrounded by a border to keep the snake contained.
   - **Snake**: The snake starts at the center of the grid with an initial length of 2. It moves in the direction of the player's key input.
   - **Food**: The food appears at random positions on the grid. When the snake eats the food, it grows longer, and new food is placed at a different random location.

### 2. **Game Loop**

   - **Initialize Game**: The game begins with a blinking welcome message, adding a bit of flair. Once you press Enter, the game starts.
   - **Input**: The snake's direction is controlled by arrow keys. The snake cannot reverse its direction directly (e.g., moving left if it's currently moving right).
   - **Move Snake**: The snake moves one step at a time in the current direction. If it eats food, the snake grows longer; otherwise, the last segment of its tail is removed to simulate movement.
   - **Collision Detection**: The game checks if the snake collides with the walls or itself. If a collision is detected, the game ends.

### 3. **Visuals**

   - **Grid Drawing**: The grid is drawn on the console with borders. The snake is represented by "O" characters, and the food is represented by an asterisk "*".
   - **Blinking Title**: The game title blinks at the start screen, creating an exciting atmosphere before the game begins.

## 🕹️ Code Highlights

- **Modular Design**: The game is broken down into functions for initialization, input handling, snake movement, collision detection, and grid drawing.
- **Random Food Placement**: The food is placed randomly on the grid, ensuring that it never appears on the snake's body.
- **Smooth Game Flow**: The game speed is controlled by a delay, making the game more challenging as the snake grows longer.

## 🏁 Ending Note

Enjoy the nostalgia with this simple yet captivating Snake Game! It's a great way to practice your coding skills and have some fun at the same time. Just be careful not to let the snake bite itself—it's game over if it does! 😄

---
