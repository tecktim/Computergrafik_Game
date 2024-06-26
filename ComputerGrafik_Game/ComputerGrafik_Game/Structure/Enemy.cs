﻿using ComputerGrafik_Game.Collision;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Structure
{
    internal class Enemy
    {

        public Enemy(double health, float size, float speed, int bounty, Vector2 spawn)

        {
            this.Health = health;
            this.Size = size;
            this.Speed = speed;
            this.Bounty = bounty;
            this.alive = true;
            this.Spawn = spawn;
            this.A = new Vector2(spawn.X, spawn.Y);
            this.B = new Vector2(spawn.X + size / 2, spawn.Y + size);
            this.C = new Vector2(spawn.X + size, spawn.Y);
            // A IS LOWER LEFT, B IS LOWER RIGHT, C IS UPPER RIGHT, D IS UPPER LEFT (Corners of the healthbar)
            this.HbInnerA = this.HbOuterA = new Vector2(A.X + 0.01f, B.Y + 0.02f);
            this.HbInnerB = this.HbOuterB = new Vector2(C.X - 0.01f, B.Y + 0.02f);
            this.hbInnerC = this.HbOuterC = new Vector2(C.X - 0.01f, B.Y + 0.04f);
            this.hbInnerD = this.HbOuterD = new Vector2(A.X + 0.01f, B.Y + 0.04f);
            this.Center = new Vector2((A.X + C.X) / 2, (A.Y + B.Y) / 2);
            this.HitCollider = new CircleCollider(Center, this.Size / 2);
        }

        private Vector2 left = new Vector2(-0.005f, 0.0f);
        private Vector2 right = new Vector2(0.005f, 0.0f);
        private Vector2 up = new Vector2(0.0f, 0.005f);
        private Vector2 down = new Vector2(0.0f, -0.005f);

        private int i = 0;
        public void Update(List<Map> wayPointList, List<Enemy> enemyList)
        {
            Center = new Vector2((A.X + C.X) / 2, (A.Y + B.Y) / 2);
            HitCollider = new CircleCollider(Center - new Vector2(0f, Size / 6), Size / 1.8f);

            if (i < wayPointList.Count)
            {
                Map waypoint;
                waypoint = wayPointList[i];
                if (A.X < waypoint.Point2.X)
                { UpdatePosition(right); CorrectRound(); }
                else if (A.X > waypoint.Point2.X)
                { UpdatePosition(left); CorrectRound(); }
                else if (A.Y < waypoint.Point2.Y)
                { UpdatePosition(up); CorrectRound(); }
                else if (A.Y > waypoint.Point2.Y)
                { UpdatePosition(down); CorrectRound(); }
                else
                { if (A.X == waypoint.Point2.X && A.Y == waypoint.Point2.Y) { i++; } }
            } else
            { enemyList.RemoveAt(0); }
        }

        private void UpdatePosition(Vector2 direction)
        {
            A = A + direction;
            B = B + direction;
            C = C + direction;
            HbOuterA = HbOuterA + direction;
            HbOuterB = HbOuterB + direction;
            HbOuterC = HbOuterC + direction;
            HbOuterD = HbOuterD + direction;
            HbInnerA = HbInnerA + direction;
            HbInnerB = HbInnerB + direction;
            hbInnerC = hbInnerC + direction;
            hbInnerD = hbInnerD + direction;
        }
        
        private void CorrectRound()
        {
            A = new Vector2((float)Math.Round((decimal)A.X, 3), (float)Math.Round((decimal)A.Y, 3));
            B = new Vector2((float)Math.Round((decimal)B.X, 3), (float)Math.Round((decimal)B.Y, 3));
            C = new Vector2((float)Math.Round((decimal)C.X, 3), (float)Math.Round((decimal)C.Y, 3));
        }

        public bool EnemyHit(float damage)
        {
            Health = Health - damage;
            float hbOffset1 = (float)Health / 100 / 35;
            float hbOffset2 = 1 - hbOffset1;
            HbInnerB = new Vector2(HbInnerB.X - hbOffset1, HbInnerB.Y);
            hbInnerC = new Vector2(hbInnerC.X - hbOffset1, hbInnerC.Y);
            alive = true;
            return alive;
        }

        public bool EnemyFinalHit()
        {
            HbInnerB = new Vector2(HbInnerA.X, HbInnerB.Y);
            hbInnerC = new Vector2(hbInnerD.X, hbInnerC.Y);
            Health = 0;
            alive = false;
            return alive;
        }

        public void Draw()
        {
            DrawEnemy();
            DrawHealth();
        }

        public void DrawHealth()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.DarkOliveGreen);
            GL.Vertex2(HbInnerA);
            GL.Vertex2(HbInnerB);
            GL.Vertex2(hbInnerC);
            GL.Vertex2(hbInnerD);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(System.Drawing.Color.Red);
            GL.LineWidth(5f);
            GL.Vertex2(HbOuterA);
            GL.Vertex2(HbOuterB);
            GL.Vertex2(HbOuterC);
            GL.Vertex2(HbOuterD);
            GL.End();
        }

        private void DrawEnemy()
        {
            GL.Begin(PrimitiveType.Triangles);
            if (Health >= 75)
            {
                GL.Color3(System.Drawing.Color.Green);
            }
            if (Health < 75 && Health > 25)
            {
                GL.Color3(System.Drawing.Color.Orange);
            }
            if (Health <= 25)
            {
                GL.Color3(System.Drawing.Color.Red);
            }
            GL.Vertex2(A);
            GL.Vertex2(B);
            GL.Vertex2(C);
            GL.End();
        }

        public CircleCollider HitCollider { get; set; }
        public Vector2 Center { get; set; }
        public double Health { get; set; }
        public static double MaxHealth = 100;
        public float Size { get; set; }
        public float Speed { get; set; }
        public int Bounty { get; set; }
        public Vector2 Spawn { get; set; }
        public Vector2 A { get; set; }
        public Vector2 B { get; set; }
        public Vector2 C { get; set; }
        public Vector2 HbOuterA { get; set; }
        public Vector2 HbOuterB { get; set; }
        public Vector2 HbOuterC { get; set; }
        public Vector2 HbOuterD { get; set; }
        public Vector2 HbInnerA { get; set; }
        public Vector2 HbInnerB { get; set; }
        public Vector2 hbInnerC { get; set; }
        public Vector2 hbInnerD { get; set; }
        public bool alive { get; set; }
    }
}

