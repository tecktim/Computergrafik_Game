using OpenTK.Mathematics;
using System.Collections.Generic;

namespace ComputerGrafik_Game.Structure
{
    internal class TowerController
    {
        private List<Enemy> enemies;
        private List<Bullet> bulletList;


        public TowerController(List<Enemy> enemies, List<Bullet> bulletList)
        {
            this.enemies = enemies;
            this.bulletList = bulletList;
        }

        public List<Tower> towerList()
        {
            List<Tower> towerList = new List<Tower>();
            Tower towerTest1 = new Tower(55, 1.0f, 20.0f, .15f, new Vector2(-0.2f, 0.0f), 100, "rifle", enemies, bulletList);
            Tower towerTest2 = new Tower(100, 1.8f, 20.0f, .1f, new Vector2(0.4f, -0.1f), 100, "sniper", enemies, bulletList);
            towerList.Add(towerTest1);
            towerList.Add(towerTest2);
            return towerList;
        }

    }
}
