using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
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
            //GL.Viewport(-1, -1, 1200, 800);
            GL.Viewport(0, 0, 1200, 800);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.LightBlue);
            

            for (int i = 0; i < model.Enemies.Count; i++)
            {
                model.Enemies[i].Draw();
                model.Enemies[i].HitCollider.DrawCircleCollider();
            }
            for (int i = 0; i < model.TowerList.Count; i++)
            {
                model.TowerList[i].Draw();
                model.TowerList[i].RangeCollider.DrawCircleCollider();
            }
            for (int i = 0; i < model.WayPointList.Count; i++)
            {
                model.WayPointList[i].Draw();
            }
            for (int i = 0; i < model.BulletList.Count; i++)
            {
                model.BulletList[i].Draw();
            }
        }
    }
}
