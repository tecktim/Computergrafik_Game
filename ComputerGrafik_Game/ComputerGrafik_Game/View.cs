using ComputerGrafik_Game.Collision;
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
            Matrix4 model = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-55.0f));
            Matrix4 view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 1200 / 800, 0.1f, 100.0f);

            
        }

        

        internal void Draw(Model model)
        {
            //GL.Viewport(-1, -1, 1200, 800);
            GL.Viewport(0, 0, 1200, 800);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.LightBlue);

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
