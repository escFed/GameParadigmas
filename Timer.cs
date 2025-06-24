using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Timer
    {
        private float currentTime = 0f;
        private float survivalTime = 40f;

        private float lastTime = 0f;

        public float SurvivalTime => survivalTime;

        public void Start()
        {
            currentTime = survivalTime;
            lastTime = survivalTime;
        }

        public void Update()
        {
            if (survivalTime > 0)
            {
                survivalTime -= Time.DeltaTime;

                if (lastTime - survivalTime >= 1)
                {
                    lastTime = survivalTime;
                }
            }

            else if (survivalTime < 0)
            {
                GameManager.Instance.ChangeState(gameState.stage1Win);
                survivalTime = 0;
            }
        }
    }
}
