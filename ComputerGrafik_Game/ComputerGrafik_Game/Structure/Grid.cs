using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;

namespace ComputerGrafik_Game.Structure
{
    public enum CellType { Empty, Sniper, Rifle };
    class Grid
    {
        public Grid(int row, int column)
        {
            this.rows = row;
            this.columns = column;
            Cells = new CellType[columns * rows];
            Array.Fill(Cells, CellType.Empty);
        }







        public CellType this[int x, int y]
        {
            get { return Cells[x + columns * y]; }
            set { Cells[x + columns * y] = value; }
        }

        public void initialize()
        {
            //make every cell empty

        }

        public void update()
        {
        }

        public void draw()
        {
            DrawGrid(this);
        }

        private void DrawGrid(Grid grid)
        {
            DrawGridLines(grid.columns, grid.rows);

            //Use this to draw the towers

            /* GL.Color4(Color4.Gray);
             * for (int column = 0; column < grid.columns; ++column)
            {
                for (int row = 0; row < grid.rows; ++row)
                {
                    if (CellType.circle == grid[column, row])
                    {
                        DrawCircle(new Vector2(column + 0.5f, row + 0.5f), 0.4f);
                    }
                }
            }*/
        }

        private static void DrawGridLines(int columns, int rows)
        {
            GL.Color4(Color4.White);
            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            for (float x = 0; x < columns + 1; ++x)
            {
                GL.Vertex2(x, 0f);
                GL.Vertex2(x, rows);
            }
            for (float y = 0; y < rows + 1; ++y)
            {
                GL.Vertex2(0f, y);
                GL.Vertex2(columns, y);
            }
            GL.End();
        }

        int rows { get; set; }
        int columns { get; set; }
        public CellType[] Cells;
    }
}
