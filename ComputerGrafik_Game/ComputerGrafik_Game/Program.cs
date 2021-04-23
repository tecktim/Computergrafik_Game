using ComputerGrafik_Game;
using ComputerGrafik_Game.Structure;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Collections.Generic;
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


Model model = new Model();
View view = new View();
Control control = new Control(model, view);

windowSetup(window);
GL.ClearColor(Color4.LightBlue);
/*
WaveController waveController = new WaveController(30, 0.1f);
List<Enemy> enemies = waveController.createWave();


MapController mapBuild = new MapController();
List<Map> wayPointList = mapBuild.buildMap();

BulletController bulletController = new BulletController();
List<Bullet> bulletList = bulletController.buildBulletList();

TowerController towerController = new TowerController(enemies, bulletList);
List<Tower> towerList = towerController.towerList();
*/

/*void Update(float time)
{
    if (input.IsKeyDown(Keys.Space))
    {
        waveController.createEnemy(enemies);
    }


    for (int i = 0; i < enemies.Count; i++)
    {
        enemies[i].update(wayPointList, enemies);
    }
}*/

/*void Draw()
{
    GL.Viewport(-1, -1, 1200, 800);
    GL.LoadIdentity();
    GL.Clear(ClearBufferMask.ColorBufferBit);
    for (int i = 0; i < enemies.Count; i++)
    {
        enemies[i].draw();
        enemies[i].hitCollider.DrawCircleCollider();
    }

    for (int i = 0; i < towerList.Count; i++)
    {
        towerList[i].draw();
        towerList[i].rangeCollider.DrawCircleCollider();
    }

    for (int i = 0; i < wayPointList.Count; i++)
    {
        wayPointList[i].draw();
    }

    for (int i = 0; i < bulletList.Count; i++)
    {
        bulletList[i].draw();
    }
    window.SwapBuffers();
}*/

void windowSetup(GameWindow window)
{
    window.RenderFrame += _ => view.Draw(model); // first draw the model
    window.RenderFrame += _ => window.SwapBuffers(); // then wait for next frame and buffer swap
    window.UpdateFrame += args =>
    {
        control.Update((float)args.Time, window.KeyboardState);
        model.Update((float)args.Time);
    }; // call update once each frame
    window.Title = "MyTowerDefense";
    window.Run(); // start the game loop with 60Hz
}