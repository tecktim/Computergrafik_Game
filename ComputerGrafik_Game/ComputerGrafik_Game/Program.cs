using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ComputerGrafik_Game;
using ComputerGrafik_Game.Structure;
using System.Windows.Input;

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

GlobalVariables globalVariables = new GlobalVariables(window);

Vector2 spawn = new Vector2(0.0f, 0.0f);
Enemy enemyTest = new Enemy(100.0, 0.1f, 0.01f, 100, spawn, globalVariables);
Map mapTest = new Map(-0.5f, -0.5f);

GL.ClearColor(Color4.Brown);
float x = 0f;

KeyboardState input = window.KeyboardState;

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();


void Update(float time)
{
    if (input.IsKeyDown(Keys.Left)) { enemyTest.update("LEFT"); }
    if (input.IsKeyDown(Keys.Right)) { enemyTest.update("RIGHT"); }
    if (input.IsKeyDown(Keys.Up)) { enemyTest.update("UP"); }
    if (input.IsKeyDown(Keys.Down)) { enemyTest.update("DOWN"); }
}

void Draw()
{
    GL.Viewport(-1, -1, 1200, 800);
    GL.LoadIdentity();
    GL.Clear(ClearBufferMask.ColorBufferBit);
    enemyTest.draw();
    mapTest.draw();
    window.SwapBuffers();
    System.Diagnostics.Debug.Print("Drawing dono");
}


namespace ComputerGrafik_Game
{

}
