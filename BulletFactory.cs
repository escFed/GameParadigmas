using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class BulletFactory
    {
        public static Bullet CreateBullet(string type, float x, float y, Player player = null)
        {
            switch (type.ToLower())
            {
                case "fast":
                    return new BulletFast(x, y);

                case "default":
                default:
                    return new BulletDefault(x, y);
            }
        }
    }
}
