using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private List<Bullet> bullets = new List<Bullet>();
        private List<Enemy> enemies = new List<Enemy>();
        public Player player;

        private IStage currentStage;

        public List<Bullet> Bullets => bullets;
        public List<Enemy> Enemies => enemies;

        public IStage CurrentStage => currentStage;

        public LevelController()
        {
        }

        public void LoadStage(IStage stage)
        {
            currentStage?.StopMusic();
            currentStage = stage;
            currentStage.Initialize();
        }

        public void ResetStage()
        {
            CurrentStage.Reset();
        }

        public void Update()
        {
            currentStage.Update();
        }

        public void Render()
        {
            currentStage.Render();
        }

        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public void StopMusic()
        {
            currentStage?.StopMusic();
        }
    }
}