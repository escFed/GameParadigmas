using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Stage1 : StageBase 
    {
        public Stage1(List<Bullet> bullets, List<Enemy> enemies) : base(bullets, enemies, "Assets/Screens/castle.png")
        {
        }

        protected override void SpawnEnemies()
        {
            EnemyFactory.CreateEnemy(EnemyType.Demon, 1300, 110);
            EnemyFactory.CreateEnemy(EnemyType.Eye, 1100, 230);
            EnemyFactory.CreateEnemy(EnemyType.Eye, 1200, 370);
            EnemyFactory.CreateEnemy(EnemyType.Demon, 1400, 520);
        }

        protected override void PlayMusic()
        {
            stageMusic = new SoundPlayer("Assets/Music/stage1Music.wav");
            stageMusic.PlayLooping();
        }
    }
}
