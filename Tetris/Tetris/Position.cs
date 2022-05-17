namespace Tetris
{
    public class Position
    {
        private int Row { get; set; }
        private int Column { get; set; }
        public Position(int row, int columns) {
            Row = row;
            Column = columns;
            
        }
    }
}
