using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    /// <summary>
    /// Describes the Tiles of the Game
    /// </summary>
    public class Tile
    {
        public float posX;
        public float posY;
        public float size;

        public int X;
        public int Y;

        /// <summary>
        /// Constructor for Tiles
        /// </summary>
        /// <param name="posX">Position X of the Tile</param>
        /// <param name="posY">Position Y of the Tile</param>
        /// <param name="size">Size of a Tile</param>
        /// <param name="i">With this you can get the X. tile vertically</param>
        /// <param name="j">With this you can get the Y. tile horizontally</param>
        public Tile(float posX, float posY, float size, int i, int j)
        {
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.X = i;
            this.Y = j;
           //System.Diagnostics.Debug.Print("Tile: x: " + posX + " y: " + posY);
        }

        public void drawTile()
        {
            
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Gray);
            /*
            GL.Vertex2(this.posX, this.posY);
            GL.Vertex2(this.posX + this.size, this.posY);
            GL.Vertex2(this.posX + this.size, this.posY + this.size);
            GL.Vertex2(this.posX, this.posY + this.size);
            */
            /*
            GL.Vertex2(new Vector2(this.posX * 1f / 1280f,this.posY * 1f / 720f));
            GL.Vertex2(new Vector2(this.posX + this.size * 1f / 1280f, this.posY * 1f / 720f));
            GL.Vertex2(new Vector2(this.posX + this.size * 1f / 1280f, this.posY + this.size * 1f / 720f));
            GL.Vertex2(new Vector2(this.posX * 1f / 1280f, this.posY + this.size * 1f / 720f));
            */
            GL.Vertex2(new Vector2(this.posX / 1280f, this.posY / 800f));
            GL.Vertex2(new Vector2(this.posX + this.size/ 1280f, this.posY / 800f));
            GL.Vertex2(new Vector2(this.posX + this.size / 1280f, this.posY + this.size / 800f));
            GL.Vertex2(new Vector2(this.posX / 1280f, this.posY + this.size / 800f));
            GL.End();
        }
    }
}
