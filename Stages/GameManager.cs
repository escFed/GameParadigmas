using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum gameState
    {
        mainMenu, howToPlay, stage1, stage1Win, gameOver, stage2, youWin, gameOver2
    }

    public class GameManager
    {
        private static GameManager instance;
        private gameState currentState = gameState.mainMenu;

        private Image mainMenu = Engine.LoadImage("Assets/Screens/mainMenu1.png");
        private Image howToPlay = Engine.LoadImage("Assets/Screens/howToPlay1.png");
        private Image stage1Win = Engine.LoadImage("Assets/Screens/stage1Win1.png");
        private Image gameOver = Engine.LoadImage("Assets/Screens/gameOver1.png");
        private Image gameOver2 = Engine.LoadImage("Assets/Screens/gameOver1.png");
        private Image youWin = Engine.LoadImage("Assets/Screens/youWin1.png");

        private SoundPlayer menuMusic;
        private SoundPlayer winMusic;
        private SoundPlayer gameOverMusic;
        private SoundPlayer currentMusic;

        private LevelController levelController;

        public LevelController LevelController => levelController; 

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

            menuMusic = new SoundPlayer("Assets/Music/mainMenu.wav");
            winMusic = new SoundPlayer("Assets/Music/youWin.wav");
            gameOverMusic = new SoundPlayer("Assets/Music/gameOver.wav");

            PlayMenuMusic();
        }

        public void Update()
        {
            switch (currentState)
            {
                case gameState.mainMenu:
                    PlayMenuMusic();
                    if (Engine.GetKey(Engine.KEY_O))
                    {
                        currentState = gameState.howToPlay;
                    }
                    else if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.LoadStage(new Stage1(levelController.Bullets, levelController.Enemies));
                        currentState = gameState.stage1;
                    }
                    break;

                case gameState.howToPlay:
                    PlayMenuMusic();
                    if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
                    break;

                case gameState.stage1:
                    levelController.Update();
                    break;

                case gameState.stage1Win:                    
                    PlayWinMusic();
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetStage();
                        levelController.LoadStage(new Stage2(levelController.Bullets, levelController.Enemies));
                        currentState = gameState.stage2;
                    }
                    break;

                case gameState.gameOver:
                    PlayGameOverMusic();
                    if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetStage();
                        levelController.LoadStage(new Stage1(levelController.Bullets, levelController.Enemies));
                        currentState = gameState.stage1;
                    }
                    else if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
                    break;

                case gameState.stage2:
                    levelController.Update();
                    break;

                case gameState.youWin:
                    PlayWinMusic();
                    if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
                    break;

                case gameState.gameOver2:
                    PlayGameOverMusic();
                    if (Engine.GetKey(Engine.KEY_ESC))
                    {
                        currentState = gameState.mainMenu;
                    }
                    else if (Engine.GetKey(Engine.KEY_P))
                    {
                        levelController.ResetStage();
                        levelController.LoadStage(new Stage2(levelController.Bullets, levelController.Enemies));
                        currentState = gameState.stage2;
                    }
                    break;
            }
        }

        public void Render()
        {
            switch (currentState)
            {
                case gameState.mainMenu:
                    Engine.Clear();
                    Engine.Draw(mainMenu, 0, 0);
                    Engine.Show();
                    break;
                case gameState.howToPlay:
                    Engine.Clear();
                    Engine.Draw(howToPlay, 0, 0);
                    Engine.Show();
                    break;
                case gameState.stage1:
                    levelController.Render();
                    break;
                case gameState.stage1Win:
                    Engine.Clear();
                    Engine.Draw(stage1Win, 0, 0);
                    Engine.Show();
                    break;
                case gameState.gameOver:
                    Engine.Clear();
                    Engine.Draw(gameOver, 0, 0);
                    Engine.Show();
                    break;
                case gameState.stage2:
                    levelController.Render();
                    break;
                case gameState.youWin:
                    Engine.Clear();
                    Engine.Draw(youWin, 0, 0);
                    Engine.Show();
                    break;
                case gameState.gameOver2:
                    Engine.Clear();
                    Engine.Draw(gameOver2, 0, 0);
                    Engine.Show();
                    break;
            }
        }
        public void ChangeState(gameState newState)
        {
            currentState = newState;
        }

        private void StopAllMusic()
        { 
            currentMusic?.Stop();
            levelController.StopMusic();
            currentMusic = null;
        }

        private void PlayMenuMusic()
        {
            if(currentMusic != menuMusic)
            {
                StopAllMusic();
                menuMusic.PlayLooping();
                currentMusic = menuMusic;
            }
        }

        private void PlayWinMusic()
        {
            if (currentMusic != winMusic)
            {
                StopAllMusic();
                winMusic.Play();
                currentMusic = winMusic;
            }
        }

        private void PlayGameOverMusic()
        {
            if (currentMusic != gameOverMusic)
            {
                StopAllMusic();
                gameOverMusic.Play();
                currentMusic = gameOverMusic;
            }
        }
    }
}
