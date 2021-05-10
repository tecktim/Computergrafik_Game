using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Structure
{
    internal class Bullet
    {
        public Bullet(float velocity, float bulletLength, float bulletWidth, Color4 bulletColor, Vector2 center, Enemy enemy, List<Bullet> bulletList, float damage, List<Enemy> enemies)
        {
            this.velocity = velocity;
            this.bulletLength = bulletLength;
            this.bulletWidth = bulletWidth;
            this.bulletColor = bulletColor;
            this.start = center;
            this.enemy = enemy;
            this.bulletList = bulletList;
            this.damage = damage;
            this.enemies = enemies;
        }
        float drawStartX;
        float drawEndX;
        float drawStartY;
        float drawEndY;
        public void init()
        {
            drawStartX = this.start.X;
            drawStartY = this.start.Y;
            if (this.enemy.center.X < this.start.X)
            {
                drawEndX = this.start.X - bulletLength;
            }
            if (this.enemy.center.X > this.start.X)
            {
                drawEndX = this.start.X + bulletLength;
            }
            if (this.enemy.center.Y < this.start.Y)
            {
                drawEndY = this.start.Y - bulletLength;
            }
            if (this.enemy.center.Y < this.start.Y)
            {
                drawEndY = this.start.Y + bulletLength;
            }
        }

        public void update()
        {
            if(this.enemy.center.X < this.start.X)
            {
                drawStartX -= 0.005f;
                drawEndX -= 0.005f;
            }
            if (this.enemy.center.X > this.start.X)
            {
                drawStartX += 0.005f;
                drawEndX += 0.005f;
            }
            if (this.enemy.center.Y < this.start.Y)
            {
                drawStartY -= 0.005f;
                drawEndY -= 0.005f;
            }
            if (this.enemy.center.Y > this.start.Y)
            {
                drawStartY += 0.005f;
                drawEndY += 0.005f;
            }
            
        }

        public void test()
        {
            drawStartX = (float)Math.Round((decimal)drawStartX, 3);
            drawStartY = (float)Math.Round((decimal)drawStartY, 3);
            
            if (drawStartX == enemy.center.X || drawStartY == enemy.center.Y)
            {
                if (enemy.health > this.damage)
                {
                    enemy.enemyHit(this.damage);

                    bulletList.Remove(this);
                }
                else
                {
                    if (enemy.enemyFinalHit() == false)
                    {
                        enemies.Remove(enemy);
                    }
                }
                bulletList.Remove(this);
            }
            
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads); // STATUS_STACK_BUFFER_OVERRUN
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(drawStartX, drawStartY);
            GL.Vertex2(drawStartX + bulletWidth, drawStartY+bulletWidth);
            GL.Vertex2(drawEndX, drawEndY);
            GL.Vertex2(drawEndX + bulletWidth, drawEndY+bulletWidth);
            GL.End();
            test();
        }

        public Enemy enemy { get; set; }

        private List<Bullet> bulletList;
        private float damage;
        private List<Enemy> enemies;

        public Vector2 start { get; set; }
        public float velocity { get; set; }
        public float bulletLength { get; set; }
        public float bulletWidth { get; set; }
        public Color4 bulletColor { get; set; }
    }
}
