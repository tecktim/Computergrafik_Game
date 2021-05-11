using ComputerGrafik_Game.Collision;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Structure
{
    internal class Bullet
    {
        
        public Bullet(float velocity, float bulletLength, float bulletWidth, Color4 bulletColor, Vector2 Center, Enemy enemy, List<Bullet> bulletList, float damage, List<Enemy> enemies)
        {
            
            this.Velocity = velocity;
            this.BulletLength = bulletLength;
            this.BulletWidth = bulletWidth;
            this.BulletColor = bulletColor;
            this.Start = Center;
            this.Enemy = enemy;
            this.BulletList = bulletList;
            this.Damage = damage;
            this.Enemies = enemies;
            this.BulletCollider = new CircleCollider(this.Start, this.BulletWidth*2);
        }

        public void Update()
        {
            float tx = this.Enemy.A.X - this.BulletCollider.center.X;
            float ty = this.Enemy.A.Y - this.BulletCollider.center.Y;

            float length = MathF.Sqrt(tx * tx + ty * ty);



            if (length > this.Velocity)
            {
                this.BulletCollider.center.X = this.BulletCollider.center.X + tx / length * this.Velocity;
                this.BulletCollider.center.Y = this.BulletCollider.center.Y + ty / length * this.Velocity;
            }
            else
            {
                this.BulletList.Remove(this);
            }
            

            /*if(this.Enemy.A.X < this.Start.X)
            {
                this.BulletCollider.center = this.BulletCollider.center - new Vector2(0.005f,0f);
            }
            if (this.Enemy.A.X > this.Start.X)
            {
                this.BulletCollider.center = this.BulletCollider.center + new Vector2(0.005f, 0f);
            }
            if (this.Enemy.A.Y < this.Start.Y)
            {
                this.BulletCollider.center = this.BulletCollider.center - new Vector2(0f, 0.005f);
            }
            if (this.Enemy.A.Y > this.Start.Y)
            {
                this.BulletCollider.center = this.BulletCollider.center + new Vector2(0f, 0.005f);
            }*/
            Test();
        }

        public void Test()
        {
            //this.circlePosition.X = (float)Math.Round((decimal)this.circlePosition.X, 3);
            //this.circlePosition.Y = (float)Math.Round((decimal)this.circlePosition.Y, 3);
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy EnemyI = Enemies[i];
                if (BulletCollider.Circle2CircleCollider(EnemyI.HitCollider) == true)
                {
                    if (EnemyI.Health > this.Damage)
                    {
                        EnemyI.EnemyHit(this.Damage);

                        BulletList.Remove(this);
                    }
                    else
                    {
                        if (EnemyI.EnemyFinalHit() == false)
                        {
                            Enemies.Remove(EnemyI); //removing in iteration of list can be dangerous, kopie der liste mit foreach iterieren wäre deutlich besser
                            //am ende vom frame remove
                        }
                    }
                    BulletList.Remove(this);
                }
            }
            
            
        }

        public void Draw()
        {
            
            
            GL.Begin(PrimitiveType.Quads); // STATUS_STACK_BUFFER_OVERRUN
            GL.Color3(System.Drawing.Color.Black);
            /*GL.Vertex2(start.X, start.Y);
            GL.Vertex2(start.X + BulletWidth, start.Y + BulletWidth);
            GL.Vertex2(enemy.Center.X, enemy.Center.Y);
            GL.Vertex2(enemy.Center.X + BulletWidth, enemy.Center.Y + BulletWidth);*/
            /* GL.Vertex2(drawStartX, drawStartY);
             GL.Vertex2(drawStartX + BulletWidth, drawStartY+BulletWidth);
             GL.Vertex2(drawEndX, drawEndY);
             GL.Vertex2(drawEndX + BulletWidth, drawEndY+BulletWidth);*/
            BulletCollider.DrawCircleCollider();
            GL.End();
            
        }

        public Enemy Enemy { get; set; }

        private List<Bullet> BulletList;
        private float Damage;
        private List<Enemy> Enemies;

        public CircleCollider BulletCollider { get; private set; }
        public Vector2 Start { get; set; }
        public float Velocity { get; set; }
        public float BulletLength { get; set; }
        public float BulletWidth { get; set; }
        public Color4 BulletColor { get; set; }
        
    }
}
