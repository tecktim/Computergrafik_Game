using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ComputerGrafik_Game.Structure;

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

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();

void Update(float time)
{
    
}

void Draw()
{
    GL.Clear(ClearBufferMask.ColorBufferBit);

    window.SwapBuffers();
}

namespace ComputerGrafik_Game
{

}
