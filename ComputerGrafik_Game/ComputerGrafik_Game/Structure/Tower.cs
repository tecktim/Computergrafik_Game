using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    class Tower
    {
        public Tower(double attackSpeed, double attackRange, double attackDamage, float sizeXY, int cost)
        {
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
        }

        public double attackSpeed { get; set; }
        public double attackRange { get; set; }
        public double attackDamage { get; set; }
        //Ground area (rectangle)
        public float sizeXY { get; set; }
        public int cost { get; set; }
    }
}
