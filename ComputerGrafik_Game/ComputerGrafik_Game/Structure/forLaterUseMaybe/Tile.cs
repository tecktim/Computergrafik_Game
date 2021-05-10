using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

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
            X = i;
            Y = j;
            //System.Diagnostics.Debug.Print("Tile: x: " + posX + " y: " + posY);
        }

        public void DrawTile()
        {

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Gray);
            GL.Vertex2(new Vector2(posX / 1280f, posY / 800f));
            GL.Vertex2(new Vector2(posX + size / 1280f, posY / 800f));
            GL.Vertex2(new Vector2(posX + size / 1280f, posY + size / 800f));
            GL.Vertex2(new Vector2(posX / 1280f, posY + size / 800f));
            GL.End();
        }
    }
}
