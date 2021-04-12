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
using ComputerGrafik_Game.Structure.Projectiles;
using System.Diagnostics;
using System.Threading;

namespace ComputerGrafik_Game.Structure
{
    class Tower
    {
        public Tower(int attackSpeedInMills, float attackRange, float attackDamage, float sizeXY, Vector2 position, int cost, string type, Stopwatch asTimer)
        {
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
            this.position = position;
            this.center = new Vector2(position.X+ sizeXY/2, position.Y+ sizeXY/2);
            this.rangeCollider = new CircleCollider(center, attackRange/2);
            this.type = type;
            this.asTimer = asTimer;
        }



        public void update()
        {

        }

        int j = 0;
        int k = 0;
        public void checkAttack(Enemy enemy)
        {
            this.asTimer.Start();
            Thread.Sleep(attackSpeed);
            this.asTimer.Stop();
            

            if (asTimer.ElapsedTicks > attackSpeed)
            {
                checkRange(enemy);
                asTimer.Restart();
                j++;
                System.Diagnostics.Debug.Print("this is a shoot, elapsedMillis is: " + asTimer.ElapsedTicks + " try no:" + j);
            }
            else
            {
                k++;
                System.Diagnostics.Debug.Print("this is a  NOT  A shoot, elapsedMillis is: " + asTimer.ElapsedTicks + " try no:" + k);


            }
        }
        public void checkRange(Enemy enemy)
        {
            bool inRangeTrue = this.rangeCollider.Circle2CircleCollider(enemy.hitCollider);

            if (inRangeTrue)
            {
                System.Diagnostics.Debug.Print(this.type + " In Range: true");
                Bullet bullet = new Bullet(0.01f, 0.01f, 0.005f, this.attackDamage, System.Drawing.Color.AliceBlue);
                shootBullet(bullet);

                //shoot - spawn bullet - do damage
                //1. schuss - shoot bool wird false gesetzt - zeit vergeht je nach attackspeed -
                //bool wird wieder true gesetzt - 2. Schuss - wiederholen
            }
            else
            {
                System.Diagnostics.Debug.Print(this.type +  " In Range: false");
                //nothing happens
            }
        }

        void shootBullet(Bullet bullet)
        {

            bullet.draw();
            bullet.update();
            System.Diagnostics.Debug.Print(this.type + " IS SHOOOOOOTING YAAAAA");

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
        public int attackSpeed { get; set; }
        public float attackRange { get; set; }
        public float attackDamage { get; set; }
        //Ground area (rectangle)
        public float sizeXY { get; set; }
        public Vector2 position { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public Stopwatch asTimer { get; set; }
        public int elapsedMillis { get; set; }
    }
}
