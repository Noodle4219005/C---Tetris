namespace Tetris
{
    public class GameState
    {

        private Block currentBlock;
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public GameGrid GameGrid { get; }

        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetandUpdate();
        }

        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.isEmpty(p.Row, p.Column)) return false;
            }
            return true;
        }

        private void BlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits()) CurrentBlock.RotateCCW();
        }

        private void BlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits()) CurrentBlock.RotateCW();
        }

        private void BlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits()) CurrentBlock.Move(0, 1);
        }
        private void BlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits()) CurrentBlock.Move(0, -1);
        }

        private bool isGameOver()
        {
            return !(GameGrid.isRowEmpty(0) && GameGrid.isRowEmpty(1));
        }

        private void placeBlock()
        {
            foreach (Position p in currentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRow();
            if (isGameOver())
            {
                GameOver = true;
            }
            else
            {
                currentBlock = BlockQueue.GetandUpdate();
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(-1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(1, 0);
                placeBlock();
            }
        }
    }
}
