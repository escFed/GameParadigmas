using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum EnemyType
    {
        Demon, Eye, Death, Boss
    }
    public static class EnemyFactory
    {
        public static void CreateEnemy(EnemyType type, float positionX, float positionY)
        {
            switch (type)
            {
                case EnemyType.Demon:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyDemon(positionX, positionY, 0.2f));
                    break;
                case EnemyType.Eye:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyEye(positionX, positionY, 0.4f));
                    break;
                case EnemyType.Death:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyDeath(positionX, positionY, 0.3f));
                    break;
                case EnemyType.Boss:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyBoss(positionX, positionY, 0.01f));
                    break;
            }

        }
    }
}
