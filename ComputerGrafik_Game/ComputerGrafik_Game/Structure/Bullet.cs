using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace ComputerGrafik_Game.Structure
{
    internal class Bullet
    {
        public Bullet(float velocity, float bulletLength, float bulletWidth, Color4 bulletColor, Tower tower, Enemy enemy)
        {
            this.velocity = velocity;
            this.bulletLength = bulletLength;
            this.bulletWidth = bulletWidth;
            this.bulletColor = bulletColor;
            this.tower = tower;
            this.enemy = enemy;
        }

        private int i = 0;
        public void draw()
        {
            GL.Begin(PrimitiveType.Quads); // STATUS_STACK_BUFFER_OVERRUN
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(tower.center.X, tower.center.Y);
            GL.Vertex2(tower.center.X + bulletWidth, tower.center.Y + bulletWidth);
            GL.Vertex2(enemy.center.X, enemy.center.Y);
            GL.Vertex2(enemy.center.X + bulletWidth, enemy.center.Y + bulletWidth);

            GL.End();
            //System.Diagnostics.Debug.Print("tower position: " + tower.center.X + ", " + tower.center.Y);
            //System.Diagnostics.Debug.Print("enemy position: " + enemy.center.X + ", " + enemy.center.Y);

        }

        public Enemy enemy { get; set; }
        public Tower tower { get; set; }
        public float velocity { get; set; }
        public float bulletLength { get; set; }
        public float bulletWidth { get; set; }
        public Color4 bulletColor { get; set; }
    }
}
