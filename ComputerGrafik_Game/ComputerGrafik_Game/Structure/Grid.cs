using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace ComputerGrafik_Game.Structure
{
    /// <summary>
    /// Describes the Grid of the Game
    /// </summary>
    class Grid
    {
        int xTiles;
        int yTiles;
        ArrayList tileList = new ArrayList();

        /// <summary>
        /// Creates a Grid on the whole window with its Tiles in size of tileSize
        /// </summary>
        /// <param name="windowWidth">Width of the Window</param>
        /// <param name="windowHeight">Height of the Window</param>
        /// <param name="tileSize">Size of a tile</param>
        public Grid(int windowWidth, int windowHeight, int tileSize)
        {
            this.xTiles = windowWidth / tileSize;
            this.yTiles = windowHeight / tileSize;

            for(int i=0;i<xTiles;i++)
            {
                for(int j=0;j<yTiles;j++)
                {
                    tileList.Add(new Tile(tileSize * i, tileSize * j, tileSize, i, j));
                }
            }
        }

        // GridTesting
        public void drawGrid()
        {
            foreach(Tile tile in tileList) {
                GL.Begin(PrimitiveType.LineLoop);

            }
        }

    }
}
