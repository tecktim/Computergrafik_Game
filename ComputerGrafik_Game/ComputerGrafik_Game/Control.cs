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
        }
                 
        /// <summary>
        /// Check if key is pressed, act accordingly
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="keyboard"></param>
        internal void Update(float deltaTime, KeyboardState keyboard)
		{
            
            //this.model.createWave(5, 0.1f);
            if (keyboard.IsKeyDown(Keys.Space))
            {
               this.model.createEnemy();
            }

        }

		public Model model { get; set; }
        public View view { get; set; }
    }
}
