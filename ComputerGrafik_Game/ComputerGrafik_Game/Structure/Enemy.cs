using ComputerGrafik_Game.Collision;
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
            this.health = health;
            this.size = size;
            this.speed = speed;
            this.bounty = bounty;
            alive = true;
            this.spawn = spawn;
            a = new Vector2(spawn.X, spawn.Y);
            b = new Vector2(spawn.X + size / 2, spawn.Y + size);
            c = new Vector2(spawn.X + size, spawn.Y);

            // A IS LOWER LEFT, B IS LOWER RIGHT, C IS UPPER RIGHT, D IS UPPER LEFT (Corners of the healthbar)
            hbInnerA = new Vector2(a.X + 0.01f, b.Y + 0.02f);
            hbInnerB = new Vector2(c.X - 0.01f, b.Y + 0.02f);
            hbInnerC = new Vector2(c.X - 0.01f, b.Y + 0.04f);
            hbInnerD = new Vector2(a.X + 0.01f, b.Y + 0.04f);

            hbOuterA = hbInnerA;
            hbOuterB = hbInnerB;
            hbOuterC = hbInnerC;
            hbOuterD = hbInnerD;

            /*this.hbInnerA = new Vector2(hbOuterA.X + 0.02f * hbOuterB.X, hbOuterA.Y + 0.02f * hbOuterD.Y);
            this.hbInnerB = new Vector2(hbOuterB.X - 0.02f * hbOuterA.X, hbOuterB.Y + 0.02f * hbOuterC.Y);
            this.hbInnerC = new Vector2(hbOuterC.X - 0.02f * (hbOuterD.X + hbOuterC.X), hbOuterC.Y - 0.02f * hbOuterC.Y);
            this.hbInnerD = new Vector2(hbOuterD.X - 0.02f * hbOuterD.X, hbOuterD.Y - 0.02f * hbOuterD.Y);*/

            center = new Vector2((a.X + c.X) / 2, (a.Y + b.Y) / 2);
            hitCollider = new CircleCollider(center, this.size / 2);
        }

        private Vector2 left = new Vector2(-0.005f, 0.0f);
        private Vector2 right = new Vector2(0.005f, 0.0f);
        private Vector2 up = new Vector2(0.0f, 0.005f);
        private Vector2 down = new Vector2(0.0f, -0.005f);

        private Vector2 dead = new Vector2(5000.0f, -5000.0f);


        private void updatePosition(Vector2 direction)
        {
            a = a + direction;
            b = b + direction;
            c = c + direction;
            hbOuterA = hbOuterA + direction;
            hbOuterB = hbOuterB + direction;
            hbOuterC = hbOuterC + direction;
            hbOuterD = hbOuterD + direction;
            hbInnerA = hbInnerA + direction;
            hbInnerB = hbInnerB + direction;
            hbInnerC = hbInnerC + direction;
            hbInnerD = hbInnerD + direction;
        }

        private void moveLeft()
        {
            updatePosition(left);
        }
        private void moveRight()
        {

            updatePosition(right);
        }
        private void moveUp()
        {
            updatePosition(up);
        }
        private void moveDown()
        {
            updatePosition(down);
        }

        public void draw()
        {
            drawEnemy();
            drawHealth();
        }

        public void drawHealth()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.DarkOliveGreen);
            GL.Vertex2(hbInnerA);
            GL.Vertex2(hbInnerB);
            GL.Vertex2(hbInnerC);
            GL.Vertex2(hbInnerD);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(System.Drawing.Color.Red);
            GL.LineWidth(5f);
            GL.Vertex2(hbOuterA);
            GL.Vertex2(hbOuterB);
            GL.Vertex2(hbOuterC);
            GL.Vertex2(hbOuterD);
            GL.End();
        }

        private void drawEnemy()
        {
            GL.Begin(PrimitiveType.Triangles);
            if (health >= 75)
            {
                GL.Color3(System.Drawing.Color.Green);
            }
            if (health < 75 && health > 25)
            {
                GL.Color3(System.Drawing.Color.Orange);
            }
            if (health <= 25)
            {
                GL.Color3(System.Drawing.Color.Red);
            }
            GL.Vertex2(a);
            GL.Vertex2(b);
            GL.Vertex2(c);
            GL.End();
        }

        private int i = 0;

        public void update(List<Map> wayPointList, List<Enemy> enemyList)
        {
            center = new Vector2((a.X + c.X) / 2, (a.Y + b.Y) / 2);
            hitCollider = new CircleCollider(center - new Vector2(0f, size / 6), size / 1.8f);

            if (i < wayPointList.Count)
            {
                Map waypoint;
                waypoint = wayPointList[i];

                if (a.X < waypoint.point2.X)
                {
                    moveRight();
                    correctRound();
                }
                else if (a.X > waypoint.point2.X)
                {
                    moveLeft();
                    correctRound();
                }
                else if (a.Y < waypoint.point2.Y)
                {
                    moveUp();
                    correctRound();
                }
                else if (a.Y > waypoint.point2.Y)
                {
                    moveDown();

                    correctRound();
                }
                else
                {
                    if (a.X == waypoint.point2.X && a.Y == waypoint.point2.Y)
                    {
                        i++;
                    }
                }
            }
            else
            {
                enemyList.RemoveAt(0);
            }
        }

        public void dispose()
        {

        }

        private void correctRound()
        {
            a = new Vector2((float)Math.Round((decimal)a.X, 3), (float)Math.Round((decimal)a.Y, 3));
            b = new Vector2((float)Math.Round((decimal)b.X, 3), (float)Math.Round((decimal)b.Y, 3));
            c = new Vector2((float)Math.Round((decimal)c.X, 3), (float)Math.Round((decimal)c.Y, 3));
        }

        public bool enemyHit(Tower tower)
        {

            health = health - tower.attackDamage;

            float hbOffset1 = (float)health / 100 / 35;
            //System.Diagnostics.Debug.Print("enemy hbOffset 1 " + hbOffset1);

            float hbOffset2 = 1 - hbOffset1;
            //System.Diagnostics.Debug.Print("enemy hbOffset 2 " + hbOffset2);


            hbInnerB = new Vector2(hbInnerB.X - hbOffset1, hbInnerB.Y);
            hbInnerC = new Vector2(hbInnerC.X - hbOffset1, hbInnerC.Y);

            //this.hbInnerB = new Vector2(this.hbInnerA.X, this.hbInnerB.Y);
            //this.hbInnerC = new Vector2(this.hbInnerD.X, this.hbInnerC.Y);


            alive = true;
            //System.Diagnostics.Debug.Print("Enemy health: " + this.health);
            return alive;
        }

        public bool enemyFinalHit(Tower tower)
        {
            hbInnerB = new Vector2(hbInnerA.X, hbInnerB.Y);
            hbInnerC = new Vector2(hbInnerD.X, hbInnerC.Y);
            health = 0;
            dispose();
            alive = false;
            return alive;
        }

        public CircleCollider hitCollider { get; set; }
        public Vector2 center { get; set; }
        public double health { get; set; }
        public static double MaxHealth = 100;
        public float size { get; set; }
        public float speed { get; set; }
        public int bounty { get; set; }
        public Vector2 spawn { get; set; }
        public Vector2 a { get; set; }
        public Vector2 b { get; set; }
        public Vector2 c { get; set; }
        public Vector2 hbOuterA { get; set; }
        public Vector2 hbOuterB { get; set; }
        public Vector2 hbOuterC { get; set; }
        public Vector2 hbOuterD { get; set; }
        public Vector2 hbInnerA { get; set; }
        public Vector2 hbInnerB { get; set; }
        public Vector2 hbInnerC { get; set; }
        public Vector2 hbInnerD { get; set; }
        public bool alive { get; set; }
    }
}

