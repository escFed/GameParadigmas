using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum EnemyType
    {
        Slow, Fast
    }
    public static class EnemyFactory
    {
        public static void CreateEnemy(EnemyType type, float positionX, float positionY)
        {
            switch (type)
            {
                case EnemyType.Slow:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyDemon(positionX, positionY, 0.2f));
                    break;
                case EnemyType.Fast:
                    GameManager.Instance.LevelController.Enemies.Add(new EnemyEye(positionX, positionY, 0.4f));
                    break;
            }

        }
    }
}
