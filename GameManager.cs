using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum gameState
    {
        mainMenu, gameScreen, youWin, youLose
    }
    
    public class GameManager
    {
        private static GameManager instance;
        private gameState currentState = gameState.mainMenu; 

        private Image mainMenu = Engine.LoadImage("assets/mainMenu.png");
        private Image youWin = Engine.LoadImage("assets/youWin.png");
        private Image gameOver = Engine.LoadImage("assets/gameOver.png");
        private LevelController levelController;

        public LevelController LevelController => levelController; // Property to access the level controller

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Initialize()
        {
            levelController = new LevelController();
        }

        public void Update()
        {
            switch (currentState)
            {
                case gameState.mainMenu:
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        currentState = gameState.gameScreen; // Change to game state
                    }
                    break;
                case gameState.gameScreen:
                    levelController.Update(); // Update the level controller
                    break;
                case gameState.youWin:
                    break;
                case gameState.youLose:
                    break;
            }
        }

        public void Render()
        {
            switch (currentState)
            {
                case gameState.mainMenu:
                    Engine.Clear(); // Clear the screen
                    Engine.Draw(mainMenu, 0, 0); // Draw the main menu image
                    Engine.Show(); // Update the screen
                    break;
                case gameState.gameScreen:
                    levelController.Render(); // Render the level controller
                    break;
                case gameState.youWin:
                    Engine.Clear(); // Clear the screen
                    Engine.Draw(youWin, 0, 0); // Draw the you win image
                    Engine.Show();
                    break;
                case gameState.youLose:
                    Engine.Clear(); // Clear the screen
                    Engine.Draw(gameOver, 0, 0); // Draw the game over image
                    Engine.Show();
                    break;
            }
        }
        public void ChangeState(gameState newState)
        {
            currentState = newState; // Change the current state
        }
    }
}
