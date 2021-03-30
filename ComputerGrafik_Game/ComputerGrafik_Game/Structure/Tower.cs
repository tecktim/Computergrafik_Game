using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ComputerGrafik_Game.Collision;


namespace ComputerGrafik_Game.Structure
{
    class Tower
    {
        public Tower(float attackSpeed, float attackRange, float attackDamage, float sizeXY, Vector2 position, int cost)
        {
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
            this.position = position;
            this.center = new Vector2(position.X+ sizeXY/2, position.Y+ sizeXY/2);
            this.rangeCollider = new CircleCollider(center, attackRange);
        }

        public void update()
        {
            CircleCollider otherCircle;
            otherCircle = enemyTest.hitCollider;
            if (this.rangeCollider.Circle2CircleCollider(otherCircle) == true)
            {
                System.Diagnostics.Debug.Print("In Range: true");
            }
            else
            {
                System.Diagnostics.Debug.Print("In Range: false");
            }
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(position.X, position.Y);
            GL.Vertex2(position.X + sizeXY, position.Y);
            GL.Vertex2(position.X + sizeXY, position.Y + sizeXY);
            GL.Vertex2(position.X, position.Y + sizeXY);
            GL.End();
        }

        public CircleCollider rangeCollider { get; set; }
        public Vector2 center { get; set; }
        public float radius { get; set; }
        public float attackSpeed { get; set; }
        public float attackRange { get; set; }
        public float attackDamage { get; set; }
        //Ground area (rectangle)
        public float sizeXY { get; set; }
        public Vector2 position { get; set; }
        public int cost { get; set; }
    }
}
