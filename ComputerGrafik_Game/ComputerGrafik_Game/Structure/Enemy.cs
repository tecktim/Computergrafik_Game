using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    class Enemy
    {
        private double health;
        private float size;
        private float speed;
        private bool alive;
        private int bounty;
        private Vector2 spawn;
        private Vector2 a;
        private Vector2 b;
        private Vector2 c;


        private float posX;
        private float posY;

        public Enemy(double health, float size, float speed, int bounty, Vector2 spawn) //https://www.youtube.com/watch?v=mmo3HFa2vjg

        {
            this.health = health;
            this.size = size;
            this.speed = speed;
            this.bounty = bounty;
            this.alive = true;
            this.spawn = spawn;
            this.a = spawn;
            this.b = new Vector2(spawn.X+size/2, spawn.Y+size);
            this.c = new Vector2(spawn.X+size, spawn.Y);
        }

        public void update()
        {
            a = a + new Vector2(0.0f, 0.0005f);
            b = b + new Vector2(0.0f, 0.0005f);
            c = c + new Vector2(0.0f, 0.0005f);
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(System.Drawing.Color.White);
            GL.Vertex2(a);
            GL.Vertex2(b);
            GL.Vertex2(c);
            GL.End();
        }


    }
}
