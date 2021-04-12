﻿using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Collision
{
    class CircleCollider
    {
        Vector2 center;
        float radius;

        public CircleCollider(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public bool Circle2CircleCollider(CircleCollider otherCollider)
        {
            float radius = this.radius + otherCollider.radius;
            float deltaX = this.center.X - otherCollider.center.X;
            //deltaX = deltaX * deltaX;
            float deltaY = this.center.Y - otherCollider.center.Y;
            //deltaY = deltaY * deltaY;
            if((deltaX + deltaY)*(deltaX+deltaY) < (this.radius + otherCollider.radius) * (this.radius + otherCollider.radius))
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
            GL.Color3(System.Drawing.Color.Aquamarine);
            foreach (var point in this.circlePoints)
            {
                GL.Vertex2(this.center + this.radius * point);
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
