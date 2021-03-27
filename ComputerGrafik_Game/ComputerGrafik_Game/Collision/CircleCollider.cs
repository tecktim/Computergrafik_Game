using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
