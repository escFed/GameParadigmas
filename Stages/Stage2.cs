using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using MyGame;

namespace MyGame
{
    public class Stage2 : StageBase
    {
        public Stage2(List<Bullet> bullets, List<Enemy> enemies) : base(bullets, enemies, "Assets/Screens/battleFinal.png")
        {
        }

        protected override void SpawnEnemies()
        {
            EnemyFactory.CreateEnemy(EnemyType.Boss,  950,  100);
            EnemyFactory.CreateEnemy(EnemyType.Death, 1300, 150);
            EnemyFactory.CreateEnemy(EnemyType.Death, 1100, 250);
            EnemyFactory.CreateEnemy(EnemyType.Death, 1200, 490);
        }

        protected override void PlayMusic()
        {
            stageMusic = new SoundPlayer("Assets/Music/stage2Music.wav");
            stageMusic.PlayLooping();
        }
    }
}
