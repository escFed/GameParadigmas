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
        private static GameManager instance; // Singleton instance
        private gameState currentState = gameState.mainMenu;

        private Image mainMenu = Engine.LoadImage("assets/Screens/mainMenu.png");
        private Image youWin = Engine.LoadImage("assets/Screens/youWin.png");
        private Image gameOver = Engine.LoadImage("assets/Screens/gameOver.png");
        private LvlOneController levelController;

        public LvlOneController LevelController => levelController; // Property to access the level controller

        public static GameManager Instance // Singleton property
        {
            get
            {
                if (instance == null)  // Check if instance is null
                {
                    instance = new GameManager(); // Create a new instance if it doesn't exist
                }
                return instance;
            }
        }

        public void Initialize()
        {
            levelController = new LvlOneController();
        }

        public void Update()
        {
            switch (currentState)
            {
                case gameState.mainMenu:
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetLevel(); // Reset the level
                        currentState = gameState.gameScreen; // Change to game state
                    }
                    break;
                case gameState.gameScreen:
                    levelController.Update();
                    break;
                case gameState.youWin:
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetLevel();
                        currentState = gameState.gameScreen;
                    }
                    else if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
                    break;
                case gameState.youLose:
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetLevel();
                        currentState = gameState.gameScreen;
                    }
                    else if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
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
                    Engine.Clear();
                    Engine.Draw(youWin, 0, 0);
                    Engine.Show();
                    break;
                case gameState.youLose:
                    Engine.Clear();
                    Engine.Draw(gameOver, 0, 0);
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
