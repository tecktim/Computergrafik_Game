using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGrafik_Game.Structure
{
    /// <summary>
    /// Describes the Tiles of the Game
    /// </summary>
    class Tile
    {
        private float posX;
        private float posY;
        private int size;

        private int X;
        private int Y;

        /// <summary>
        /// Constructor for Tiles
        /// </summary>
        /// <param name="posX">Position X of the Tile</param>
        /// <param name="posY">Position Y of the Tile</param>
        /// <param name="size">Size of a Tile</param>
        /// <param name="i">With this you can get the X. tile vertically</param>
        /// <param name="j">With this you can get the Y. tile horizontally</param>
        public Tile(int posX, int posY, int size, int i, int j)
        {
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.X = i;
            this.Y = j;
            System.Diagnostics.Debug.Print("Tile: x: " + posX + " y: " + posY);
        }

        public float getPosX()
        {
            return this.posX;
        }

        public float getPosY()
        {
            return this.posY;
        }

        public int getX()
        {
            return this.X;
        }
        public int getY()
        {
            return this.Y;
        }
    }
}
