using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Hud
    {
        private Font font = Engine.LoadFont("assets/Fonts/VT323.ttf", 30);
        private string timeText;

        public void Render()
        {
            Engine.DrawText("Survival Time: " + timeText, 10, 10, 255, 255, 255, font);
            Engine.DrawText("Score: " + ScoreManager.Score, 880, 10, 255, 255, 255, font);
        }

        public void UpdateTime(int time)
        {
            timeText = time.ToString();
        }

    }
}
