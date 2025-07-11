﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Transform
    {
        private Vector2 position;
        private Vector2 scale;

        public Vector2 Position => position;
        public Vector2 Scale => scale;

        public Transform(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public void Translate(Vector2 direction, float speed)
        {
            position.x += direction.x * speed;
            position.y += direction.y * speed;
        }

        public void Reposition(Vector2 rePos)
        {
            position.x = rePos.x;
            position.y = rePos.y;
        }
    }
}
