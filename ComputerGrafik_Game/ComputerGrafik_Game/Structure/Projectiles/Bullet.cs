using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure.Projectiles
{
    class Bullet
    {
        public Bullet(float velocity, float bulletLength, float bulletWidth, float bulletColor)
        {
            this.velocity = velocity;
            this.bulletLength = bulletLength;
            this.bulletWidth = bulletWidth;
            this.bulletColor = bulletColor;
        }

        public float velocity { get; set; }
        public float bulletLength { get; set; }
        public float bulletWidth { get; set; }
        public float bulletColor { get; set; }
    }
}
