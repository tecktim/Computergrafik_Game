using ComputerGrafik_Game.Collision;
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
            this.LaneWidth = 0.2f;
            if (this.Point1.X == this.Point2.X) {
                this.MapCollider = new BoxCollider(new Vector2(point1.X, (point1.Y + point2.Y) / 2), LaneWidth, point1.Y - point2.Y);
            }
            else if(this.Point1.Y == this.Point2.Y){
                this.MapCollider = new BoxCollider(new Vector2((point1.X + point2.X) / 2, point2.Y), point1.X - point2.X - LaneWidth, LaneWidth);
            }
            else
            {
                this.MapCollider = new BoxCollider(new Vector2(0,0),0,0);
            }
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(this.Point1.X, this.Point1.Y);
            GL.Vertex2(this.Point2.X, this.Point2.Y);
            MapCollider.DrawBoxCollider();
            GL.End();
        }

        public Vector2 Point1 { get; set; }
        public Vector2 Point2 { get; set; }
        public float LaneWidth { get; private set; }
        internal BoxCollider MapCollider { get; set; }
    }
}
