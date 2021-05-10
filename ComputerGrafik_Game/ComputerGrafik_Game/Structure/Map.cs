using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace ComputerGrafik_Game.Structure
{
    public class Map
    {
        public Map(Vector2 point1, Vector2 point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(this.Point1.X, this.Point1.Y);
            GL.Vertex2(this.Point2.X, this.Point2.Y);
            GL.End();
        }

        public Vector2 Point1 { get; set; }
        public Vector2 Point2 { get; set; }

    }
}
