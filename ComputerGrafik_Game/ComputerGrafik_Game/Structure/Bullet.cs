using OpenTK.Mathematics;

namespace ComputerGrafik_Game.Structure.Projectiles
{
    class Bullet
    {
        public Bullet(float velocity, float bulletLength, float bulletWidth, float damage, Color4 bulletColor)
        {
            this.velocity = velocity;
            this.bulletLength = bulletLength;
            this.bulletWidth = bulletWidth;
            this.bulletColor = bulletColor;
        }


        public void draw()
        {

        }
        public void update()
        {

        }
        public float velocity { get; set; }
        public float bulletLength { get; set; }
        public float bulletWidth { get; set; }
        public Color4 bulletColor { get; set; }
    }
}
