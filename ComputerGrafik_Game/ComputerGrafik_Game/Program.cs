using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

GameWindow window = new GameWindow(GameWindowSettings.Default, new NativeWindowSettings { Profile = ContextProfile.Compatability });
GL.ClearColor(Color4.Brown);
float x = 0f;

window.UpdateFrame += args => Update((float)args.Time);
window.RenderFrame += _ => Draw();
window.Run();

void Update(float time)
{
    x += time * 0.1f;
    window.KeyboardState.IsKeyDown(Keys.Left);
}

void Draw()
{
    GL.Clear(ClearBufferMask.ColorBufferBit);
    GL.Begin(PrimitiveType.Quads);
    GL.Vertex2(x + 0f, 0f);
    GL.Vertex2(x + 10f, 0f);
    GL.Vertex2(x + 1f, 1f);
    GL.Vertex2(x + 0f, 1f);
    GL.End();
    window.SwapBuffers();
}

namespace ComputerGrafik_Game
{

}
