using System.Windows;
using System.Windows.Controls;

namespace GameOfLife
{
    public class Cell
    {
        private BoardCell boardcell;
        public int X;
        public int Y;
        public bool Resurrect = false;
        public bool Kill = false;

        public Cell(int x, int y, Grid gameGrid)
        {
            X = x;
            Y = y;
            boardcell = new BoardCell(gameGrid);
            boardcell.cellLocation = new Point((X * BoardCell.cellSize) + 3, (Y * BoardCell.cellSize) + 3);
        }

        public void SwitchAliveState()
        {
            boardcell.ToggleX();
        }
    }
}