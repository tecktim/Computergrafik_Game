using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    public class Map
    {
        public Map(Vector2 point1, Vector2 point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        
        public void draw()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(System.Drawing.Color.White);
            GL.Vertex2(point1.X, point1.Y);
            GL.Vertex2(point2.X, point2.Y);
            GL.End();
        }

        public Vector2 point1 { get; set; }
        public Vector2 point2 { get; set; }

    }
}
