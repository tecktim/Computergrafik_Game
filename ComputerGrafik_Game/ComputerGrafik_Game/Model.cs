using ComputerGrafik_Game.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game
{
    class Model
    {
        public Model()
        {
            WaveController waveController = new WaveController(30, 0.1f);
            List<Enemy> enemies = waveController.createWave();

            MapController mapBuild = new MapController();
            List<Map> wayPointList = mapBuild.buildMap();

            BulletController bulletController = new BulletController();
            List<Bullet> bulletList = bulletController.buildBulletList();

            TowerController towerController = new TowerController(enemies, bulletList);
            List<Tower> towerList = towerController.towerList();
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
        }

        public WaveController waveController { get; set; }
        public List<Enemy> enemies { get; set; }

        public MapController mapController { get; set; }
        public List<Map> wayPointList { get; set; }

        public BulletController bulletController { get; set; }
        public List<Bullet> bulletList { get; set; }
        public TowerController towerController { get; set; }
        public List<Tower> towerList { get; set; }

    }
}
