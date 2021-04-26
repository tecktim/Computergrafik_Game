using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Collision
{
    internal class CircleCollider
    {
        private Vector2 center;
        private float radius;

        public CircleCollider(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        //funktioniert immer perfekt
        public bool Circle2CircleCollider(CircleCollider otherCollider)
        {
            float radius = this.radius + otherCollider.radius;
            float deltaX = center.X - otherCollider.center.X;
            float deltaY = center.Y - otherCollider.center.Y;

            float distance = (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            if (distance < radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //funktioniert leider nicht immer richtig
        public bool Circle2CircleCollider(CircleCollider otherCollider, bool useNoSqrt)
        {
            float radius = this.radius + otherCollider.radius;
            float deltaX = center.X - otherCollider.center.X;
            float deltaY = center.Y - otherCollider.center.Y;

            float delta = (deltaX * deltaX) + (deltaY * deltaY);
            if (delta < radius * radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private readonly List<Vector2> circlePoints = CreateCirclePoints(20);

        public void DrawCircleCollider()
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(System.Drawing.Color.Black);
            foreach (var point in circlePoints)
            {
                GL.Vertex2(center + radius * point);
            }
            GL.End();
        }

        private static List<Vector2> CreateCirclePoints(int corners)
        {
            float delta = 2f * MathF.PI / corners;
            var points = new List<Vector2>();
            for (int i = 0; i < corners; ++i)
            {
                var alpha = i * delta;
                // step around the unit circle
                var x = MathF.Cos(alpha);
                var y = MathF.Sin(alpha);
                points.Add(new Vector2(x, y));
            }
            return points;
        }

    }
}
