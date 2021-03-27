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

Vector2 spawn = new Vector2(-1.0f, -0.5f);
Enemy enemyTest = new Enemy(100.0, 0.1f, 0.01f, 100, spawn, globalVariables);
Map way1 = new Map(enemyTest.a, new Vector2(0.1f, -0.5f));
Map way2 = new Map(new Vector2(0.1f, -0.5f), new Vector2(0.1f, 0.5f));
Map way3 = new Map(new Vector2(0.1f, 0.5f), new Vector2(0.75f, 0.5f));
Map way4 = new Map(new Vector2(0.75f, 0.5f), new Vector2(0.75f, -1.0f));
int way = 0;

GL.ClearColor(Color4.Brown);
float x = 0f;

KeyboardState input = window.KeyboardState;

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();



void Update(float time)
{
    if (way == 0)
    {
        if (enemyTest.a.X <= way1.point2.X)
        {
            enemyTest.moveRight();
        }
        if (enemyTest.a.X >= way1.point2.X)
        {
            enemyTest.moveLeft();
        }
        if (enemyTest.a.Y <= way1.point2.Y)
        {
            enemyTest.moveUp();
        }
        if (enemyTest.a.Y >= way1.point2.Y)
        {
            enemyTest.moveDown();
        }
            if (enemyTest.a.X >= way1.point2.X - 0.00005f && enemyTest.a.Y >= way1.point2.Y - 0.00005f)
            {
                way++;
            }
        }

    System.Diagnostics.Debug.Print("" + way);
    System.Diagnostics.Debug.Print("enemyX" + enemyTest.a + " way: " + way1.point2);

    if (way == 1)
    {
        if (enemyTest.a.X <= way2.point2.X)
        {
            enemyTest.moveRight();
        }
        if (enemyTest.a.X >= way2.point2.X)
        {
            enemyTest.moveLeft();
        }
        if (enemyTest.a.Y <= way2.point2.Y)
        {
            enemyTest.moveUp();
        }
        if (enemyTest.a.Y >= way2.point2.Y)
        {
            enemyTest.moveDown();
        }
        if (enemyTest.a.X >= way2.point2.X - 0.00005f && enemyTest.a.Y >= way2.point2.Y - 0.00005f)
        {
            way++;
        }
    }
    System.Diagnostics.Debug.Print("" + way);
    System.Diagnostics.Debug.Print("enemyX" + enemyTest.a + " way: " + way2.point2);
    if (way == 2)
    {
        if (enemyTest.a.X <= way3.point2.X)
        {
            enemyTest.moveRight();
        }
        if (enemyTest.a.X >= way3.point2.X)
        {
            enemyTest.moveLeft();
        }
        if (enemyTest.a.Y <= way3.point2.Y)
        {
            enemyTest.moveUp();
        }
        if (enemyTest.a.Y >= way3.point2.Y)
        {
            enemyTest.moveDown();
        }
        if (enemyTest.a.X >= way3.point2.X - 0.0005f && enemyTest.a.Y >= way3.point2.Y - 0.0005f)
        {
            way++;
        }
    }
    System.Diagnostics.Debug.Print("" + way);
    System.Diagnostics.Debug.Print("enemyX" + enemyTest.a + " way: " + way3.point2);
    if (way == 3)
    {
        if (enemyTest.a.X <= way4.point2.X)
        {
            enemyTest.moveRight();
        }
        if (enemyTest.a.X >= way4.point2.X)
        {
            enemyTest.moveLeft();
        }
        if (enemyTest.a.Y <= way4.point2.Y)
        {
            enemyTest.moveUp();
        }
        if (enemyTest.a.Y >= way4.point2.Y)
        {
            enemyTest.moveDown();
        }
        if (enemyTest.a.X >= way4.point2.X - 0.00005f && enemyTest.a.Y <= way4.point2.Y - 0.00005f)
        {
            way++;
        }
    }
    System.Diagnostics.Debug.Print("" + way);
    System.Diagnostics.Debug.Print("enemyX" + enemyTest.a + " way: " + way4.point2);

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
    way1.draw();
    way2.draw();
    way3.draw();
    way4.draw();
    window.SwapBuffers();
    System.Diagnostics.Debug.Print("Drawing dono");
}


namespace ComputerGrafik_Game
{

}
