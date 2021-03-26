using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    class Map
    {
        float xStart;
        float yStart;

        public Map(float xStart, float yStart)
        {
            this.xStart = xStart;
            this.yStart = yStart;
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(System.Drawing.Color.White);
            GL.Vertex2(xStart, yStart);
            GL.Vertex2(xStart, yStart+0.5f);
            GL.Vertex2(xStart + 0.5f, yStart+0.5f);
            GL.Vertex2(xStart + 0.5f, yStart+1.0f);
            GL.End();
        }

    }
}
