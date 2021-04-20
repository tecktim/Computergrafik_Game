using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Timers;
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
        public Tower(int attackSpeedInMills, float attackRange, float attackDamage, float sizeXY, Vector2 position, int cost, string type, List<Enemy> enemies)
        {
            this.attackSpeed = attackSpeedInMills;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
            this.position = position;
            this.center = new Vector2(position.X+ sizeXY/2, position.Y+ sizeXY/2);
            this.rangeCollider = new CircleCollider(center, attackRange/2);
            this.type = type;
            this.enemies = enemies;
            SetTimer();
        }



        public void update(List<Enemy> enemies)
        {
            
        }
        int i = 0;
        //https://docs.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-5.0
        private void SetTimer()
        {
            // Creating timer with attackSpeed (millis) as interval
            System.Timers.Timer asTimer = new System.Timers.Timer(this.attackSpeed);
            // Hook up elapsed event for the timer
            asTimer.Elapsed += OnTimedEvent;
            asTimer.AutoReset = true;
            asTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.CheckRange();
        }


        public void CheckRange()
        {
            if (i < enemies.Count)
            {
                bool inRangeTrue = this.rangeCollider.Circle2CircleCollider(enemies[i].hitCollider);
                if (inRangeTrue)
                {
                    System.Diagnostics.Debug.Print(this.type + " In Range: true");
                    Bullet bullet = new Bullet(0.01f, 0.01f, 0.005f, this.attackDamage, System.Drawing.Color.AliceBlue);
                    
                    ShootBullet(bullet, enemies[i]);

                }
                else
                {
                    System.Diagnostics.Debug.Print(this.type + " In Range: false");
                    //nothing happens
                }
                
            }
    }

        private void ShootBullet(Bullet bullet, Enemy enemy)
        {
            
            bullet.draw();
            bullet.update();
            if (enemy.health > this.attackDamage)
            {
                enemy.enemyHit(this);
            }
            else
            {
                enemy.enemyFinalHit(this);
            }
            i++;
            if (i == enemies.Count)
            {
                i = 0;
            }
            System.Diagnostics.Debug.Print(this.type + " shooting\n");

        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            switch (this.type)
            {
                case "rifle":
                    GL.Color3(System.Drawing.Color.Black);
                    break;
                case "sniper":
                    GL.Color3(System.Drawing.Color.AntiqueWhite);
                    break;
            }
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
        public System.Timers.Timer asTimer { get; set; }
        public int elapsedMillis { get; set; }
        public List<Enemy> enemies { get; set; }
    }
}
