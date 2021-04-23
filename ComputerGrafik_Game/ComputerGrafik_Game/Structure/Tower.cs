using ComputerGrafik_Game.Collision;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Timers;

namespace ComputerGrafik_Game.Structure
{
    internal class Tower
    {
        public Tower(int attackSpeedInMills, float attackRange, float attackDamage, float sizeXY, Vector2 position, int cost, string type, List<Enemy> enemies, List<Bullet> bulletList)
        {
            this.attackSpeed = attackSpeedInMills;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
            this.position = position;
            this.center = new Vector2(position.X + sizeXY / 2, position.Y + sizeXY / 2);
            this.rangeCollider = new CircleCollider(center, attackRange / 2);
            this.type = type;
            this.enemies = enemies;
            this.bulletList = bulletList;
            SetTimer();
        }

        public void update(List<Enemy> enemies)
        {

        }

        //https://docs.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-5.0
        private void SetTimer()
        {
            // Creating timer with attackSpeed (millis) as interval
            System.Timers.Timer asTimer = new System.Timers.Timer(attackSpeed);
            // Hook up elapsed event for the timer
            asTimer.Elapsed += OnTimedEvent;
            asTimer.AutoReset = true;
            asTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CheckRange();
        }

        private Bullet bullet;
        public void CheckRange()
        {
            if (enemies.Count > 0)
            {
                bool inRangeTrue = rangeCollider.Circle2CircleCollider(enemies[0].hitCollider);

                if (inRangeTrue)
                {
                    bullet = new Bullet(0.01f, 0.01f, 0.005f, System.Drawing.Color.AliceBlue, this.center, enemies[0]);
                    bulletList.Add(bullet);
                    ShootBullet(bullet, enemies[0]);
                }
            }
        }
        private void ShootBullet(Bullet bullet, Enemy enemy)
        {
            if (enemy.health > attackDamage)
            {
                enemy.enemyHit(this.attackDamage);
                System.Diagnostics.Debug.Print("bulletlist: " +
                bulletList.Count);
                bulletList.Remove(bullet);
            }
            else
            {
                if (enemy.enemyFinalHit() == false)
                {
                    enemies.Remove(enemy);
                    System.Diagnostics.Debug.Print("enemiesLength: " + enemies.Count);
                }
            }
        }
        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            switch (type)
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
        public float sizeXY { get; set; }
        public Vector2 position { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public int elapsedMillis { get; set; }
        public List<Enemy> enemies { get; set; }
        public List<Bullet> bulletList;
    }
}
