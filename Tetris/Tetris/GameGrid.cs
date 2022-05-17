namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;

        public int Rows { get; }

        public int Columns { get; }

        public int this [int r, int c]
        {
            get => grid [r, c];
            set => grid [r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool isInside(int r, int c)
        {
            if (r > 0 && r < Rows && c > 0 && c < Columns) return true;
            return false;
        }

        public bool isEmpty(int r, int c)
        {
            if (isInside(r, c) && grid[r, c] == 0) return true;
            return false;
        }

        public bool isRowEmpty(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (grid[r, i] != 0) return false;
            }
            return true;
        }

        public bool isRowFull(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (grid[r, i] == 0) return false;
            }
            return true;
        }

        public void ClearRow(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                grid[r, i] = 0;
            }
        }

        public void MoveDown(int r, int n)
        {
            if (n == 0) return;
            for (int i = 0; i < Columns; i++)
            {
                grid[r - n, i] = grid[r, n];
                ClearRow(r);
            }
        }

        public void ClearFullRow()
        {
            int cleared = 0;
            for (int r = 0; r + cleared < Rows; r++)
            {
                if (isRowFull(r + cleared))
                {
                    ClearRow(r);
                    cleared++;
                }
                MoveDown(r + 1, cleared);
            }
        }
    }
}
