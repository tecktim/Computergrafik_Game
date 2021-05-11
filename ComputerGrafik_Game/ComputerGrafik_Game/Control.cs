using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Zenseless.OpenTK;

namespace ComputerGrafik_Game
{
    class Control
    {
        public Control(Model model, View view)
        {
            this.Model = model;
            this.View = view;
        }

		/// <summary>
		/// Check if key is pressed, act accordingly
		/// </summary>
		/// <param name="deltaTime"></param>
		/// <param name="keyboard"></param>
		internal void Update(float deltaTime, KeyboardState keyboard)
		{
			//Spawn enemies
			if (keyboard.IsKeyDown(Keys.Space))
			{
				this.Model.CreateEnemy();
			}

			var axisX = keyboard.IsKeyDown(Keys.PageDown) ? -1f : keyboard.IsKeyDown(Keys.PageUp) ? 1f : 0f;
			var camera = this.View.Camera;
			// zoom
			var zoom = camera.Scale * (1 + deltaTime * axisX);
			zoom = MathHelper.Clamp(zoom, 5f, 20f);
			camera.Scale = zoom;

			// rotate
			float rotate = keyboard.IsKeyDown(Keys.E) ? -1.0f : keyboard.IsKeyDown(Keys.Q) ? 1.0f : 0.0f;
			camera.Rotation += rotate;

			// translate
			float axisLeftRight = keyboard.IsKeyDown(Keys.Left) ? -1.0f : keyboard.IsKeyDown(Keys.Right) ? 1.0f : 0.0f;
			float axisUpDown = keyboard.IsKeyDown(Keys.Down) ? -1.0f : keyboard.IsKeyDown(Keys.Up) ? 1.0f : 0.0f;
			var movement = deltaTime * new Vector2(axisLeftRight, axisUpDown);
			// convert movement from camera space into world space
			camera.Center += movement.TransformDirection(camera.CameraMatrix.Inverted());
		}

		internal void Click(float x, float y, KeyboardState keyboard)
		{
			var cam = this.View.Camera;
			var fromViewportToWorld = Transformation2d.Combine(cam.InvViewportMatrix, cam.CameraMatrix.Inverted());
			var pixelCoordinates = new Vector2(x, y);
			var world = pixelCoordinates.Transform(fromViewportToWorld);
			Console.WriteLine($"{world}");
			if (world.X < -1.0f || x < world.X) return;
			if (world.Y < -1.0f || y < world.Y) return;
			var column = (int)Math.Truncate(world.X);
			var row = (int)Math.Truncate(world.Y);
			Console.WriteLine($"{column}, {row}");
            if (keyboard.IsKeyDown(Keys.D1))
			{
				this.Model.checkSpot(world.X, world.Y, "sniper");
			}
			else if (keyboard.IsKeyDown(Keys.D2))
            {
				this.Model.checkSpot(world.X, world.Y, "rifle");
			}
			Console.WriteLine(this.Model.TowerList.Count);
		}

		public Model Model { get; set; }
        public View View { get; set; }
    }
}
