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
            this.center = new Vector2((this.a.X + this.c.X)/2, (this.a.Y + this.b.Y)/2);
            this.hitCollider = new CircleCollider(this.center, this.size/2);

        }

        private Vector2 left = new Vector2(-0.005f, 0.0f);
        private Vector2 right = new Vector2(0.005f, 0.0f);
        private Vector2 up = new Vector2(0.0f, 0.005f);
        private Vector2 down = new Vector2(0.0f, -0.005f);

        private void moveLeft()
        {
            a = a + left;
            b = b + left;
            c = c + left;
        }
        private void moveRight()
        {
            a = a + right;
            b = b + right;
            c = c + right;
        }
        private void moveUp()
        {
            a = a + up;
            b = b + up;
            c = c + up;
        }
        private void moveDown()
        {
            a = a + down;
            b = b + down;
            c = c + down;
        }

        public void draw()
        {
            drawEnemy();
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
            if(health <= 25)
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
                dispose();
                
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
                dispose();
            }
        }

        public void dispose()
        {
            float dead = -5000.0f;
            this.a = new Vector2(+-dead, +-dead);
            this.b = new Vector2(+-dead, +-dead);
            this.c = new Vector2(+-dead, +-dead);
        }

        private void correctRound()
        {
            this.a = new Vector2((float)Math.Round((decimal)this.a.X, 3), (float)Math.Round((decimal)this.a.Y, 3));
            this.b = new Vector2((float)Math.Round((decimal)this.b.X, 3), (float)Math.Round((decimal)this.b.Y, 3));
            this.c = new Vector2((float)Math.Round((decimal)this.c.X, 3), (float)Math.Round((decimal)this.c.Y, 3));
        }

        public bool enemyHit(Tower tower)
        {
            if (health > 0)
            {
                this.health = health - tower.attackDamage;
                alive = true;
                System.Diagnostics.Debug.Print("Enemy health: " + health);
                return alive;
            }
            else
            {
                dispose();
                alive = false;
                System.Diagnostics.Debug.Print("Enemy health: " + health);
                return alive;
            }
            
        }


        public CircleCollider hitCollider { get; set; }
        public Vector2 center { get; set; }
        public double health { get; set; }
        public float size { get; set; }
        public float speed { get; set; }
        public int bounty { get; set; }
        public Vector2 spawn { get; set; }
        public Vector2 a { get; set; }
        public Vector2 b { get; set; }
        public Vector2 c { get; set; }
        public bool alive { get; set; }
    }
}

