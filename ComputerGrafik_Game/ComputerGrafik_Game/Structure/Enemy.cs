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
using System.ComponentModel;

namespace ComputerGrafik_Game.Structure
{
    class Enemy 
    {
        public Enemy(double health, float size, float speed, int bounty, Vector2 spawn)

        {
            this.health = health;
            this.size = size;
            this.speed = speed;
            this.bounty = bounty;
            this.alive = true;
            this.spawn = spawn;
            this.a = new Vector2(spawn.X, spawn.Y);
            this.b = new Vector2(spawn.X + size / 2, spawn.Y + size);
            this.c = new Vector2(spawn.X + size, spawn.Y);

            // A IS LOWER LEFT, B IS LOWER RIGHT, C IS UPPER RIGHT, D IS UPPER LEFT (Corners of the healthbar)
            this.hbInnerA = new Vector2(this.a.X + 0.01f, this.b.Y + 0.02f);
            this.hbInnerB = new Vector2(this.c.X - 0.01f, this.b.Y + 0.02f);
            this.hbInnerC = new Vector2(this.c.X - 0.01f, this.b.Y + 0.04f);
            this.hbInnerD = new Vector2(this.a.X + 0.01f, this.b.Y + 0.04f);

            this.hbOuterA = hbInnerA;
            this.hbOuterB = hbInnerB;
            this.hbOuterC = hbInnerC;
            this.hbOuterD = hbInnerD;


            /*this.hbInnerA = new Vector2(hbOuterA.X + 0.02f * hbOuterB.X, hbOuterA.Y + 0.02f * hbOuterD.Y);
            this.hbInnerB = new Vector2(hbOuterB.X - 0.02f * hbOuterA.X, hbOuterB.Y + 0.02f * hbOuterC.Y);
            this.hbInnerC = new Vector2(hbOuterC.X - 0.02f * (hbOuterD.X + hbOuterC.X), hbOuterC.Y - 0.02f * hbOuterC.Y);
            this.hbInnerD = new Vector2(hbOuterD.X - 0.02f * hbOuterD.X, hbOuterD.Y - 0.02f * hbOuterD.Y);*/

            this.center = new Vector2((this.a.X + this.c.X)/2, (this.a.Y + this.b.Y)/2);
            this.hitCollider = new CircleCollider(this.center, this.size/2);
        }

        private Vector2 left = new Vector2(-0.005f, 0.0f);
        private Vector2 right = new Vector2(0.005f, 0.0f);
        private Vector2 up = new Vector2(0.0f, 0.005f);
        private Vector2 down = new Vector2(0.0f, -0.005f);

        private Vector2 dead = new Vector2(5000.0f, -5000.0f);


        private void updatePosition(Vector2 direction)
        {
            this.a = this.a + direction;
            this.b = this.b + direction;
            this.c = this.c + direction;
            this.hbOuterA = this.hbOuterA + direction;
            this.hbOuterB = this.hbOuterB + direction;
            this.hbOuterC = this.hbOuterC + direction;
            this.hbOuterD = this.hbOuterD + direction;
            this.hbInnerA = this.hbInnerA + direction;
            this.hbInnerB = this.hbInnerB + direction;
            this.hbInnerC = this.hbInnerC + direction;
            this.hbInnerD = this.hbInnerD + direction;
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
            GL.Vertex2(this.hbInnerA);
            GL.Vertex2(this.hbInnerB);
            GL.Vertex2(this.hbInnerC);
            GL.Vertex2(this.hbInnerD);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(System.Drawing.Color.Red);
            GL.LineWidth(5f);
            GL.Vertex2(this.hbOuterA);
            GL.Vertex2(this.hbOuterB);
            GL.Vertex2(this.hbOuterC);
            GL.Vertex2(this.hbOuterD);
            GL.End();
        }

        private void drawEnemy()
        {
            GL.Begin(PrimitiveType.Triangles);
            if (health >= 75) {
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
            GL.Vertex2(this.a);
            GL.Vertex2(this.b);
            GL.Vertex2(this.c);
            GL.End();
        }


        int i = 0;
        public void update(List<Map> wayPointList)
        {
            this.center = new Vector2((this.a.X + this.c.X) / 2, (this.a.Y + this.b.Y) / 2);
            this.hitCollider = new CircleCollider(this.center - new Vector2(0f, size / 6), this.size / 1.8f);
            
            if(this.health <= 0) {
                this.dispose();
            }


            if (i < wayPointList.Count)
            {
                Map waypoint;
                waypoint = wayPointList[i];

                if (this.a.X < waypoint.point2.X)
                {
                    this.moveRight();
                    this.correctRound();
                }
                else if (this.a.X > waypoint.point2.X)
                {
                    this.moveLeft();
                    this.correctRound();
                }
                else if (this.a.Y < waypoint.point2.Y)
                {
                    this.moveUp();
                    this.correctRound();
                }
                else if (this.a.Y > waypoint.point2.Y)
                {
                    this.moveDown();

                    this.correctRound();
                }
                else
                {
                    if (this.a.X == waypoint.point2.X && this.a.Y == waypoint.point2.Y)
                    {
                        i++;
                    }
                }
            }
            else
            {
                this.dispose();
            }
        }

        public void dispose()
        {
            this.alive = false;
            updatePosition(this.dead);
        }

        private void correctRound()
        {
            this.a = new Vector2((float)Math.Round((decimal)this.a.X, 3), (float)Math.Round((decimal)this.a.Y, 3));
            this.b = new Vector2((float)Math.Round((decimal)this.b.X, 3), (float)Math.Round((decimal)this.b.Y, 3));
            this.c = new Vector2((float)Math.Round((decimal)this.c.X, 3), (float)Math.Round((decimal)this.c.Y, 3));
        }

        public bool enemyHit(Tower tower)
        {
            
            this.health = this.health - tower.attackDamage;

            float hbOffset1 = (float)this.health / 100/ 35;
            System.Diagnostics.Debug.Print("enemy hbOffset 1 " + hbOffset1);

            float hbOffset2 = 1 - hbOffset1;
            System.Diagnostics.Debug.Print("enemy hbOffset 2 " + hbOffset2);


            this.hbInnerB = new Vector2(this.hbInnerB.X - hbOffset1 , this.hbInnerB.Y);
            this.hbInnerC = new Vector2(this.hbInnerC.X - hbOffset1 , this.hbInnerC.Y);

            //this.hbInnerB = new Vector2(this.hbInnerA.X, this.hbInnerB.Y);
            //this.hbInnerC = new Vector2(this.hbInnerD.X, this.hbInnerC.Y);
            

            alive = true;
            System.Diagnostics.Debug.Print("Enemy health: " + this.health);
            if (health <0) { this.dispose(); return false; }
            return alive;
        }

        public bool enemyFinalHit(Tower tower)
        {
            this.hbInnerB = new Vector2(this.hbInnerA.X, this.hbInnerB.Y);
            this.hbInnerC = new Vector2(this.hbInnerD.X, this.hbInnerC.Y);
            this.health = 0;
            this.dispose();
            return !alive;
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

