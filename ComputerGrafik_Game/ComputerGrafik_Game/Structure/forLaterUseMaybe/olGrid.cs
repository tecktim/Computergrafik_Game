using System;


namespace ComputerGrafik_Game.Structure
{
    /// <summary>
    /// Describes the Grid of the Game
    /// </summary>
    internal class olGrid
    {
        private int xTiles;
        private int yTiles;
        private Tile[,] tileList;

        /// <summary>
        /// Creates a Grid on the whole window with its Tiles in size of tileSize
        /// </summary>
        /// <param name="windowWidth">Width of the Window</param>
        /// <param name="windowHeight">Height of the Window</param>
        /// <param name="tileSize">Size of a tile</param>
        public olGrid(float windowWidth, float windowHeight, float tileSize)
        {
            xTiles = Convert.ToInt32(windowWidth / tileSize);
            yTiles = Convert.ToInt32(windowHeight / tileSize);

            System.Diagnostics.Debug.Print("xTiles: " + xTiles);
            System.Diagnostics.Debug.Print("yTiles: " + yTiles);

            tileList = new Tile[xTiles, yTiles];

            for (int i = 0; i < xTiles; i++)
            {
                for (int j = 0; j < yTiles; j++)
                {
                    Tile tile = new Tile(tileSize * i - windowWidth / 2, -(tileSize * j - windowHeight / 2), tileSize, i, j);
                    tileList[i, j] = tile;
                }
            }
        }

        // GridTesting
        public void drawGrid()
        {
            for (int i = 0; i < xTiles; i++)
            {
                for (int j = 0; j < yTiles; j++)
                {
                    tileList[i, j].DrawTile();
                    System.Diagnostics.Debug.Print("" + "i: " + i + ", j: " + j + " posX: " + tileList[i, j].posX + " posY: " + tileList[i, j].posY);
                }
            }
        }

    }
}
