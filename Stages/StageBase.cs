using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace MyGame
{
    public abstract class StageBase : IStage
    {
        protected List<Bullet> bullets;
        protected List<Enemy> enemies;
        protected Image background;
        protected Player player;
        protected Hud hud;
        protected Timer timer;
        protected SoundPlayer stageMusic;

        public StageBase(List<Bullet> bullets, List<Enemy> enemies, string backgroundPath)
        {
            this.bullets = bullets;
            this.enemies = enemies;
            this.background = Engine.LoadImage(backgroundPath);
        }

        public void Initialize()
        {
            timer = new Timer();
            timer.Start();
            hud = new Hud();
            PlayMusic();

            player = new Player(30, 320);
            GameManager.Instance.LevelController.player = player;

            SpawnEnemies();
        }

        public void Reset()
        {
            StopMusic();
            bullets.Clear();
            enemies.Clear();
            ResetScore();
        }

        public void Update() 
        {
            timer.Update();

            player.Update();

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();
            }

            hud.UpdateTime((int)timer.SurvivalTime);
        }

        public void Render()
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0);
            player.Render();

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Render();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Render();
            }
            hud.Render();
            Engine.Show();
        }

        protected virtual void ResetScore()
        {
            ScoreManager.ResetScore();
        }

        protected abstract void SpawnEnemies();

        protected virtual void PlayMusic() 
        {
        }

        public virtual void StopMusic()
        { 
            stageMusic?.Stop();
        }
    }
}
