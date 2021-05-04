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
            this.AttackSpeed = attackSpeedInMills;
            this.AttackRange = attackRange;
            this.AttackDamage = attackDamage;
            this.SizeXY = sizeXY;
            this.Cost = cost;
            this.Position = position;
            this.Center = new Vector2(position.X - (sizeXY / 2), position.Y + (sizeXY / 2));
            this.RangeCollider = new CircleCollider(this.Center, attackRange / 2);
            this.ObjectCollider = new BoxCollider(new Vector2(position.X, position.Y), sizeXY, sizeXY);
            this.Type = type;
            this.Enemies = enemies;
            this.BulletList = bulletList;
            SetTimer();
        }

        public void Update(List<Enemy> enemies)
        {

        }

        //https://docs.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-5.0
        private void SetTimer()
        {
            // Creating timer with attackSpeed (millis) as interval
            System.Timers.Timer asTimer = new System.Timers.Timer(AttackSpeed);
            // Hook up elapsed event for the timer
            asTimer.Elapsed += OnTimedEvent;
            asTimer.AutoReset = true;
            asTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CheckRange();
        }

        private Bullet Bullet;
        public void CheckRange()
        {
            if (Enemies.Count > 0)
            {
                bool inRangeTrue = RangeCollider.Circle2CircleCollider(Enemies[0].HitCollider);

                if (inRangeTrue)
                {
                    Bullet = new Bullet(0.01f, 0.01f, 0.005f, System.Drawing.Color.AliceBlue, this.Center, Enemies[0], BulletList, this.AttackDamage, Enemies);
                   
                    BulletList.Add(Bullet);
                    
                    //ShootBullet(bullet, Enemies[0]);
                }
            }
        }
        private void ShootBulletTo(Bullet bullet, Enemy enemy)
        {
            if (enemy.Health > AttackDamage)
            {
                enemy.EnemyHit(this.AttackDamage);
                System.Diagnostics.Debug.Print("bulletlist: " +
                BulletList.Count);
                //BulletList.Remove(bullet);
            }
            else
            {
                if (enemy.EnemyFinalHit() == false)
                {
                    Enemies.Remove(enemy);
                    System.Diagnostics.Debug.Print("enemiesLength: " + Enemies.Count);
                }
            }
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            switch (Type)
            {
                case "rifle":
                    GL.Color3(System.Drawing.Color.Black);
                    break;
                case "sniper":
                    GL.Color3(System.Drawing.Color.AntiqueWhite);
                    break;
            }
            GL.Vertex2(Position.X, Position.Y);
            GL.Vertex2(Position.X + SizeXY, Position.Y);
            GL.Vertex2(Position.X + SizeXY, Position.Y + SizeXY);
            GL.Vertex2(Position.X, Position.Y + SizeXY);
            GL.End();
        }
        public CircleCollider RangeCollider { get; set; }
        public BoxCollider ObjectCollider { get; set; }
        public Vector2 Center { get; set; }
        public float Radius { get; set; }
        public int AttackSpeed { get; set; }
        public float AttackRange { get; set; }
        public float AttackDamage { get; set; }
        public float SizeXY { get; set; }
        public Vector2 Position { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public int ElapsedMillis { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Bullet> BulletList { get; set; }
    }
}
