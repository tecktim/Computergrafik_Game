using ComputerGrafik_Game;
using ComputerGrafik_Game.Structure;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Collections.Generic;

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
    });

Model model = new Model();
View view = new View();
Control control = new Control(model, view);

WindowSetup(window);

void WindowSetup(GameWindow window)
{
    window.UpdateFrame += args =>
    {
        control.Update((float)args.Time, window.KeyboardState);
        model.Update((float)args.Time);
    }; // call update once each frame
    window.RenderFrame += _ => view.Draw(model); // first draw the model
    window.RenderFrame += _ => window.SwapBuffers(); // then wait for next frame and buffer swap
    window.Title = "MyTowerDefense";
    window.Run(); // start the game loop with 60Hz
}