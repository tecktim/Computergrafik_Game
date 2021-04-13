using ComputerGrafik_Game.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game
{
    class WaveController
    {
        int enemyCount;
        float distance;
        public WaveController(int enemyCount, float distance){
            this.enemyCount = enemyCount;
            this.distance = distance;
        }

        public List<Enemy> createWave()
        {
            List<Enemy> enemies = new List<Enemy>();
            for (int i=0;i<enemyCount;i++)
            {
                Enemy enemy = new Enemy(100.0, 0.1f, 0.01f, 100, new OpenTK.Mathematics.Vector2(-1.0f - distance * i, -0.5f));
                enemies.Add(enemy);
            }
            return enemies;
        }
    }
}
