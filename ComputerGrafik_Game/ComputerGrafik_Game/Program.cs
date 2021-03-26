using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ComputerGrafik_Game;
using ComputerGrafik_Game.Structure;
//using ComputerGrafik_Game.GlobalVariables;

GameWindow window = new GameWindow(
    new GameWindowSettings
    {
        RenderFrequency = 60,
        UpdateFrequency = 60
    },
    new NativeWindowSettings
    {
        Location = new Vector2i(250, 250),
        Size = new Vector2i(1280, 800),
        Profile = ContextProfile.Compatability
    }
    );

GL.ClearColor(Color4.Brown);
float x = 0f;

//GL.ClearColor(0,0,0,255);

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();


void Update(float time)
{
    
}

void Draw()
{
    GL.LoadIdentity();
    //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
    //GL.Ortho(0.0f, window.Size.X, 0.0f, window.Size.Y, 0f, 1000f);
    //GL.Ortho(1.0f, 0.0f, 0.0f, 1.0f, 0f, 1000.0f);

    enemy1.draw();
    GL.Begin(PrimitiveType.Triangles);
    GL.Color3(System.Drawing.Color.White);
    GL.Vertex2(0.0f, 0.0f);
    GL.Vertex2(0.5f, 0.0f);
    GL.Vertex2(0.5f, 0.5f);
    GL.End();
    //GL.Viewport(0, 0, window.Size.X, window.Size.Y);
    GL.Clear(ClearBufferMask.ColorBufferBit);

    window.SwapBuffers();
    System.Diagnostics.Debug.Print("Drawing dono");
}


namespace ComputerGrafik_Game
{

}
