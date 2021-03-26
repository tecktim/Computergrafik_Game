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
        Location = new Vector2i(200, 200),
        Size = new Vector2i(1280, 800),
        Profile = ContextProfile.Compatability
    }
    );

Vector2 spawn = new Vector2(0.0f, 0.0f);
Enemy enemyTest = new Enemy(100.0, 0.1f, 0.01f, 100, spawn);

GL.ClearColor(Color4.Brown);
float x = 0f;

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();


void Update(float time)
{
    enemyTest.update();
}

void Draw()
{
    GL.LoadIdentity();
    GL.Clear(ClearBufferMask.ColorBufferBit);
    enemyTest.draw();
    window.SwapBuffers();
    System.Diagnostics.Debug.Print("Drawing dono");
}


namespace ComputerGrafik_Game
{

}
