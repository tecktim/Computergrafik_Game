using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace ComputerGrafik_Game.Structure
{
    internal class Bullet
    {
        public Bullet(float velocity, float bulletLength, float bulletWidth, Color4 bulletColor, Vector2 center,Enemy enemy)
        {
            this.velocity = velocity;
            this.bulletLength = bulletLength;
            this.bulletWidth = bulletWidth;
            this.bulletColor = bulletColor;
            this.start = center;
            this.enemy = enemy;
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads); // STATUS_STACK_BUFFER_OVERRUN
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(start.X, start.Y);
            GL.Vertex2(start.X + bulletWidth, start.Y + bulletWidth);
            GL.Vertex2(enemy.center.X, enemy.center.Y);
            GL.Vertex2(enemy.center.X + bulletWidth, enemy.center.Y + bulletWidth);
            GL.End();
        }

        public Enemy enemy { get; set; }
        public Vector2 start { get; set; }
        public float velocity { get; set; }
        public float bulletLength { get; set; }
        public float bulletWidth { get; set; }
        public Color4 bulletColor { get; set; }
    }
}
