using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafik_Game
{
    internal class Camera
    {
        public Camera() { }

        public Matrix4 CameraMatrix => cameraMatrix;

        public Matrix4 InvViewportMatrix { get; private set; }
        public void Draw()
        {
            GL.LoadMatrix(ref cameraMatrix);
        }

        private Matrix4 cameraMatrix = Matrix4.Identity;
        private float _scale = 1f;
        private float _windowAspectRatio = 1f;

        private Vector2 _center;
        private float _rotation;
    }
}
