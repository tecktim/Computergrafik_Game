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
            Camera.Scale = 9f;
            Camera.Center = new Vector2(10f, 7f);
        }
        internal Camera Camera { get; } = new Camera();

        internal void Draw(Model model)
        {
            GL.Viewport(-1, -1, 1200, 800);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.LightBlue);

            Camera.Draw();

            for (int i = 0; i < model.Enemies.Count; i++)
            {
                model.Enemies[i].Draw();
                model.Enemies[i].HitCollider.DrawCircleCollider();
            }
            for (int i = 0; i < model.TowerList.Count; i++)
            {
                model.TowerList[i].Draw();
                model.TowerList[i].RangeCollider.DrawCircleCollider();
                model.TowerList[i].ObjectCollider.DrawBoxCollider();
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

        internal void Resize(int width, int height) {
            Camera.Resize(width, height);
        }
    }
}
