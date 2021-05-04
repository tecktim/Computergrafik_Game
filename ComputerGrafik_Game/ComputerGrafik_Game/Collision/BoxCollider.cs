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
        public BoxCollider(Vector2 center, float width, float height) // color for debugging
        {
            this.center = center;
            this.width = width;
            this.height = height;
            this.color = color;
        }

        public bool Box2BoxCollider(BoxCollider otherCollider)
        {
            //DrawBoxCollider();
            //otherCollider.DrawBoxCollider();
            Vector2 topLeft = new Vector2(this.center.X - (this.width / 2), this.center.Y + (this.height / 2));
            Vector2 othertopLeft = new Vector2(otherCollider.center.X - (otherCollider.width / 2), otherCollider.center.Y + (otherCollider.height / 2));
            if (topLeft.X < othertopLeft.X + otherCollider.width && 
                topLeft.X + this.width > othertopLeft.X &&
                topLeft.Y < othertopLeft.Y + otherCollider.height &&
                topLeft.Y + this.height > othertopLeft.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        /* Nicht umgestellt auf center
        public void DrawBoxCollider()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(this.color);


            GL.Vertex2(this.topLeft); 
            GL.Vertex2(this.topLeft.X + this.width, this.topLeft.Y);
            GL.Vertex2(this.topLeft.X + this.width, this.topLeft.Y + this.height);
            GL.Vertex2(this.topLeft.X, this.topLeft.Y + height);
    }*/

        public Vector2 center { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        System.Drawing.Color color { get; set; } // for debugging

    }
}
