using ComputerGrafik_Game.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace ComputerGrafik_Game
{
    class Model
    {
        public Model()
        {
            this.Enemies = new List<Enemy>();
            this.WayPointList = new List<Map>();
            this.BulletList = new List<Bullet>();
            this.TowerList = new List<Tower>();
            CreateWave(10, 0.15f);
            TowerListAdd();
            CreateMap();
        }

        /// <summary>
        /// Game logic update. Should be called once a frame: Moves all objects and resolves collision.
        /// <param name="frameTime">Time in seconds since the last update.</param>
        /// </summary>
        internal void Update(float frameTime)
        {
            for (int i = 0; i < this.Enemies.Count; i++)
            {
                this.Enemies[i].Update(this.WayPointList, this.Enemies);
            }

            for (int i = 0; i < this.BulletList.Count; i++)
            {
                this.BulletList[i].Update();
            }
        }

        //TOWERS
        public void TowerListAdd()
        {
            Tower towerTest1 = new Tower(55, 1.0f, 20.0f, .15f, new Vector2(-0.2f, 0.0f), 100, "rifle", this.Enemies, this.BulletList);
            Tower towerTest2 = new Tower(100, 1.8f, 20.0f, .1f, new Vector2(0.4f, -0.1f), 100, "sniper", this.Enemies, this.BulletList);
            this.TowerList.Add(towerTest1);
            this.TowerList.Add(towerTest2);
        }

        //MAP
        public void CreateMap()
        {
            this.WayPointList.Add(new Map(new Vector2(-1.0f, -0.5f), new Vector2(0.1f, -0.5f)));
            this.WayPointList.Add(new Map(new Vector2(0.1f, -0.5f), new Vector2(0.1f, 0.5f)));
            this.WayPointList.Add(new Map(new Vector2(0.1f, 0.5f), new Vector2(0.75f, 0.5f)));
            this.WayPointList.Add(new Map(new Vector2(0.75f, 0.5f), new Vector2(0.75f, -1.0f)));
        }

        //WAVE MANIPULATION
        internal void CreateWave(int enemyCount, float distance)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Enemy enemy = new Enemy(100.0, 0.1f, 0.01f, 100, new OpenTK.Mathematics.Vector2(-1.0f - distance * i, -0.5f));
                this.Enemies.Add(enemy);
            }
        }

        internal void CreateEnemy()
        {
            if (this.Enemies.Count < 3000)
            {
                Enemy enemy = new Enemy(100.0, 0.1f, 0.01f, 100, new OpenTK.Mathematics.Vector2(-1.0f, -0.5f));
                this.Enemies.Add(enemy);
            }
        }

        public List<Enemy> Enemies { get; set; }
        public List<Map> WayPointList { get; set; }
        public List<Bullet> BulletList { get; set; }
        public List<Tower> TowerList { get; set; }
    }
}
