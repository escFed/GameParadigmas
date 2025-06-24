using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BulletPool <T> where T : Bullet, new()
    {
        private List<T> bulletsInUse = new List<T>();
        private List<T> bulletsAvailable = new List<T>();


        public T GetBullet(float positionX, float positionY)
        {
            T bullet = null;

            if (bulletsAvailable.Count > 0)
            {
                bullet = bulletsAvailable[0];
                bulletsAvailable.RemoveAt(0);
            }
            else
            {
                bullet = new T();
                bullet.OnDeactivate += b => RecycleBullet((T)b);
            }
            bullet.Activate(positionX, positionY);
            bulletsInUse.Add(bullet);
            return bullet;
        }

        public void RecycleBullet(T bullet)
        {
            bullet.Deactivate();
            bulletsInUse.Remove(bullet);
            bulletsAvailable.Add(bullet);
        }
    }
}
