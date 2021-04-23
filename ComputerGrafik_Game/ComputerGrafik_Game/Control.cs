using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game
{
    class Control
    {
        public Control(Model model, View view)
        {
            this.model = model;
            this.view = view;
            this.model.enemies = this.model.waveController.createWave();
        }
		internal void Update(float deltaTime, KeyboardState keyboard)
		{
            if (keyboard.IsKeyDown(Keys.Space))
            {
               this.model.waveController.createEnemy(this.model.enemies);
            }

        }

		public Model model { get; set; }
        public View view { get; set; }
    }
}
