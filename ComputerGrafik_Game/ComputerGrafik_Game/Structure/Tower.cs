using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ComputerGrafik_Game.Collision;
using ComputerGrafik_Game.Structure.Projectiles;

namespace ComputerGrafik_Game.Structure
{
    class Tower
    {
        public Tower(float attackSpeed, float attackRange, float attackDamage, float sizeXY, Vector2 position, int cost, string type)
        {
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            this.attackDamage = attackDamage;
            this.sizeXY = sizeXY;
            this.cost = cost;
            this.position = position;
            this.center = new Vector2(position.X+ sizeXY/2, position.Y+ sizeXY/2);
            this.rangeCollider = new CircleCollider(center, attackRange/2);
            this.type = type;
        }

        public void update()
        {
        }

        public void checkRange(CircleCollider enemyCollider, float time)
        {
            bool inRangeTrue = this.rangeCollider.Circle2CircleCollider(enemyCollider);

            if (inRangeTrue)
            {
                System.Diagnostics.Debug.Print(this.type + " In Range: true");
                //shoot - spawn bullet - do damage
                //1. schuss - shoot bool wird false gesetzt - zeit vergeht je nach attackspeed -
                //bool wird wieder true gesetzt - 2. Schuss - wiederholen

                Bullet bullet = new Bullet(0.01f, 0.01f, 0.005f, System.Drawing.Color.AliceBlue);
                /*if(time / this.attackSpeed == irgendwas oder sonstwas)
                {
                    bullet.draw();
                    bullet.update();
                }*/
            }
            else
            {
                System.Diagnostics.Debug.Print(this.type +  " In Range: false");
                //nothing happens
            }
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Black);
            GL.Vertex2(position.X, position.Y);
            GL.Vertex2(position.X + sizeXY, position.Y);
            GL.Vertex2(position.X + sizeXY, position.Y + sizeXY);
            GL.Vertex2(position.X, position.Y + sizeXY);
            GL.End();
        }

        public CircleCollider rangeCollider { get; set; }
        public Vector2 center { get; set; }
        public float radius { get; set; }
        public float attackSpeed { get; set; }
        public float attackRange { get; set; }
        public float attackDamage { get; set; }
        //Ground area (rectangle)
        public float sizeXY { get; set; }
        public Vector2 position { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
    }
}
