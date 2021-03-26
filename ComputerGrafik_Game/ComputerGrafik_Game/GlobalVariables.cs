using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game
{
    public class GlobalVariables
    {
        GameWindow globalWindow;
        public GlobalVariables(GameWindow window)
        {
            this.globalWindow = window;
        }
    }
}
