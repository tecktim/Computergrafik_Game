using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    class TowerController
    {
        List<Enemy> enemies;

       
        public TowerController(List<Enemy> enemies)
        {
            this.enemies = enemies;
        }

        public List<Tower> towerList()
        {
            List<Tower> towerList = new List<Tower>();
            Tower towerTest1 = new Tower(200, 0.7f, 1.0f, .15f, new Vector2(-0.2f, 0.0f), 100, "rifle", enemies);
            Tower towerTest2 = new Tower(400, 1.4f, 40.0f, .1f, new Vector2(0.4f, -0.1f), 100, "sniper", enemies);
            towerList.Add(towerTest1);
            towerList.Add(towerTest2);
            return towerList;
        }

    }
}
