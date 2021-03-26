using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ComputerGrafik_Game.Structure;

GameWindow window = new GameWindow(GameWindowSettings.Default, new NativeWindowSettings { Profile = ContextProfile.Compatability });

int windowWidth = 1280;
int windowHeight = 720;
int tileSize = 80;

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
    GL.Begin(PrimitiveType.Quads);
    GL.Vertex2(x + 0f, 0f);
    GL.Vertex2(x + 10f, 0f);
    GL.Vertex2(x + 10f, 1f);
    GL.Vertex2(x + 0f, 1f);
    GL.End();
    window.SwapBuffers();
}

namespace ComputerGrafik_Game
{

}
