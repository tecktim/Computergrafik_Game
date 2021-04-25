using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafik_Game.Collision
{
    class BoxCollider
    {
        public BoxCollider(Vector2 topLeft, float width, float height, System.Drawing.Color color) // color for debugging
        {
            this.topLeft = topLeft;
            this.width = width;
            this.height = height;
            this.color = color;
        }

        public bool Box2BoxCollider(BoxCollider otherCollider)
        {
            DrawBoxCollider();
            otherCollider.DrawBoxCollider();
            if (this.topLeft.X < otherCollider.topLeft.X + otherCollider.width && 
                this.topLeft.X + this.width > otherCollider.topLeft.X &&
                this.topLeft.Y < otherCollider.topLeft.Y + otherCollider.height &&
                this.topLeft.Y + this.height > otherCollider.topLeft.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public void DrawBoxCollider()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(this.color);
            GL.Vertex2(this.topLeft);
            GL.Vertex2(this.topLeft.X + this.width, this.topLeft.Y);
            GL.Vertex2(this.topLeft.X + this.width, this.topLeft.Y + this.height);
            GL.Vertex2(this.topLeft.X, this.topLeft.Y + height);
        }

        public Vector2 topLeft { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        System.Drawing.Color color { get; set; } // for debugging

    }
}
