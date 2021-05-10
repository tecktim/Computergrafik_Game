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
            this.enemies = new List<Enemy>();
            this.wayPointList = new List<Map>();
            this.bulletList = new List<Bullet>();
            this.towerList = new List<Tower>();
            createWave(10, 0.15f);
            towerListAdd();
            createMap();
        }

        /// <summary>
        /// Game logic update. Should be called once a frame: Moves all objects and resolves collision.
        /// <param name="frameTime">Time in seconds since the last update.</param>
        /// </summary>
        internal void Update(float frameTime)
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.enemies[i].update(this.wayPointList, this.enemies);
            }
            for (int i = 0; i< this.bulletList.Count; i++)
            {
                this.bulletList[i].update();
            }
        }

        //TOWERS
        public void towerListAdd()
        {
            Tower towerTest1 = new Tower(55, 1.0f, 20.0f, .15f, new Vector2(-0.2f, 0.0f), 100, "rifle", this.enemies, this.bulletList);
            Tower towerTest2 = new Tower(100, 1.8f, 20.0f, .1f, new Vector2(0.4f, -0.1f), 100, "sniper", this.enemies, this.bulletList);
            this.towerList.Add(towerTest1);
            this.towerList.Add(towerTest2);
        }

        //MAP
        public void createMap()
        {
            this.wayPointList.Add(new Map(new Vector2(-1.0f, -0.5f), new Vector2(0.1f, -0.5f)));
            this.wayPointList.Add(new Map(new Vector2(0.1f, -0.5f), new Vector2(0.1f, 0.5f)));
            this.wayPointList.Add(new Map(new Vector2(0.1f, 0.5f), new Vector2(0.75f, 0.5f)));
            this.wayPointList.Add(new Map(new Vector2(0.75f, 0.5f), new Vector2(0.75f, -1.0f)));
        }

        //WAVE MANIPULATION
        internal void createWave(int enemyCount, float distance)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Enemy enemy = new Enemy(100.0, 0.1f, 0.01f, 100, new OpenTK.Mathematics.Vector2(-1.0f - distance * i, -0.5f));
                this.enemies.Add(enemy);
            }
        }

        internal void createEnemy()
        {
            if (this.enemies.Count < 3000)
            {
                Enemy enemy = new Enemy(100.0, 0.1f, 0.01f, 100, new OpenTK.Mathematics.Vector2(-1.0f, -0.5f));
                this.enemies.Add(enemy);
            }
        }

        public List<Enemy> enemies { get; set; }
        public List<Map> wayPointList { get; set; }
        public List<Bullet> bulletList { get; set; }
        public List<Tower> towerList { get; set; }
    }
}
