using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ComputerGrafik_Game;
using ComputerGrafik_Game.Structure;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections;

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
Enemy enemyTest1 = new Enemy(100.0, 0.1f, 0.01f, 100, new Vector2(-1.05f, -0.5f), globalVariables);
Enemy enemyTest2 = new Enemy(100.0, 0.1f, 0.01f, 100, new Vector2(-1.1f, -0.5f), globalVariables);
Enemy enemyTest3 = new Enemy(100.0, 0.1f, 0.01f, 100, new Vector2(-1.15f, -0.5f), globalVariables);
Enemy enemyTest4 = new Enemy(100.0, 0.1f, 0.01f, 100, new Vector2(-1.2f, -0.5f), globalVariables);

Map way1 = new Map(enemyTest.a, new Vector2(0.1f, -0.5f));
Map way2 = new Map(new Vector2(0.1f, -0.5f), new Vector2(0.1f, 0.5f));
Map way3 = new Map(new Vector2(0.1f, 0.5f), new Vector2(0.75f, 0.5f));
Map way4 = new Map(new Vector2(0.75f, 0.5f), new Vector2(0.75f, -1.0f));
List<Map> wayPointList = new List<Map>();
wayPointList.Add(way1);
wayPointList.Add(way2);
wayPointList.Add(way3);
wayPointList.Add(way4);

GL.ClearColor(Color4.Brown);

KeyboardState input = window.KeyboardState;

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();



void Update(float time)
{
    System.Diagnostics.Debug.Print("Time: " + time);
    enemyTest.update(wayPointList);
    enemyTest1.update(wayPointList);
    enemyTest2.update(wayPointList);
    enemyTest3.update(wayPointList);
    enemyTest4.update(wayPointList);




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
    enemyTest1.draw();
    enemyTest2.draw();
    enemyTest3.draw();
    enemyTest4.draw();

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
