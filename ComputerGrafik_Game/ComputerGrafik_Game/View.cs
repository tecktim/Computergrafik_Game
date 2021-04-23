using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game
{
    /// <summary>
	/// Class that handles all the actual drawing using OpenGL.
	/// </summary>
    class View
    {
        public View()
        {

        }

        internal void Draw(Model model)
        {
            GL.Viewport(-1, -1, 1200, 800);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            for (int i = 0; i < model.enemies.Count; i++)
            {
                model.enemies[i].draw();
                model.enemies[i].hitCollider.DrawCircleCollider();
            }

            for (int i = 0; i < model.towerList.Count; i++)
            {
                model.towerList[i].draw();
                model.towerList[i].rangeCollider.DrawCircleCollider();
            }

            for (int i = 0; i < model.wayPointList.Count; i++)
            {
                model.wayPointList[i].draw();
            }

            for (int i = 0; i < model.bulletList.Count; i++)
            {
                model.bulletList[i].draw();
            }

        }
    }
}
