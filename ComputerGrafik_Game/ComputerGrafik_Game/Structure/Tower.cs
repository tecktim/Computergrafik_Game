using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ComputerGrafik_Game.Structure
{
    class Tower
    {
        public Tower(double attackSpeed, double attackRange, double attackDamage, float sizeXY, float posX, float posY, int cost)
        {
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
        }

        public void update()
        {

        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(posX, posY);
            GL.Vertex2(posX+sizeXY, posY);
            GL.Vertex2(posX+sizeXY, posY+sizeXY);
            GL.Vertex2(posX, posY+sizeXY);
            GL.End();

        }

        public double attackSpeed { get; set; }
        public double attackRange { get; set; }
        public double attackDamage { get; set; }
        //Ground area (rectangle)
        public float sizeXY { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public int cost { get; set; }
    }
}
