﻿using OpenTK.Graphics.OpenGL;
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

        public Enemy(double health, float size, float speed, int bounty, Vector2 spawn, GlobalVariables globalVariables) 

        {
            this.health = health;
            this.size = size;
            this.speed = speed;
            this.bounty = bounty;
            this.alive = true;
            this.spawn = spawn;
            this.a = new Vector2(spawn.X, spawn.Y);
            this.b = new Vector2(spawn.X+size/2, spawn.Y+size);
            this.c = new Vector2(spawn.X+size, spawn.Y);
            this.globalVariables = globalVariables;
        }

        Vector2 left = new Vector2(-0.005f, 0.0f);
        Vector2 right = new Vector2(0.005f, 0.0f);
        Vector2 up = new Vector2(0.0f, 0.005f);
        Vector2 down = new Vector2(0.0f, -0.005f);

        public void moveLeft()
        {
            a = a + left;
            b = b + left;
            c = c + left;
        }
        public void moveRight()
        {
            a = a + right;
            b = b + right;
            c = c + right;
        }
        public void moveUp()
        {
            a = a + up;
            b = b + up;
            c = c + up;
        }
        public void moveDown()
        {
            a = a + down;
            b = b + down;
            c = c + down;
        }

        public void update(string dir)
        {
            switch (dir)
            {
                case "UP":
                    moveUp();
                    break;
                case "LEFT":
                    moveLeft();
                    break;
                case "RIGHT":
                    moveRight();
                    break;
                case "DOWN":
                    moveDown();
                    break;

            }
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

        public double health { get; set; }
        public float size { get; set; }
        public float speed { get; set; }
        public int bounty { get; set; }
        public Vector2 spawn { get; set; }
        public GlobalVariables globalVariables { get; set; }
        public Vector2 a { get; set; }
        public Vector2 b { get; set; }
        public Vector2 c { get; set; }
        public bool alive { get; set; }



    }
}
