using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class ScoreManager
    {
        private static int score = 0;

        public static int Score => score;

        public static void AddScore(int points)
        {
            score += points;
        }

        public static void ResetScore()
        {
            score = 0;
        }
    }
}
