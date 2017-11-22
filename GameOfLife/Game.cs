using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        private List<Cell> Cells;
        private List<Cell> LivingCells;

        public Game(List<Cell> cells)
        {
            Cells = cells;
            LivingCells = new List<Cell>();
            GenerateGameSeed();
        }

        public void PlayTurn()
        {
            foreach (var livingCell in LivingCells)
            {
                int neighbours = 0;
                for (int x = livingCell.X - 1; x <= livingCell.X + 1; x++)
                {
                    if (x < 1 || x > 50) continue;
                    for (int y = livingCell.Y - 1; y <= livingCell.Y + 1; y++)
                    {
                        if (y < 1 || y > 50 || y == livingCell.Y && x == livingCell.X) continue;
                        if (LivingCells.Exists(p => p.X == x && p.Y == y))
                        {
                            neighbours++;
                        }
                        else
                        {
                            CheckDeadCell(x, y);
                        }
                    }
                }
                if (!CellShouldSurvive(neighbours))
                {
                    livingCell.Kill = true;
                }
            }

            KillAndResurrect();

        }

        private void KillAndResurrect()
        {
            foreach (var Cell in Cells)
            {
                if (Cell.Kill)
                {
                    Cell.Kill = false;
                    Cell.SwitchAliveState();
                    LivingCells.Remove(Cell);
                }
                else if (Cell.Resurrect)
                {
                    Cell.Resurrect = false;
                    Cell.SwitchAliveState();
                    LivingCells.Add(Cell);
                }
            }
        }

        public void CheckDeadCell(int X, int Y)
        {
            int neighbours = 0;
            for (int x = X - 1; x <= X + 1; x++)
            {
                if (x < 1 || x > 50) continue;
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    if (y < 1 || y > 50 || y == Y && x == X) continue;
                    if (LivingCells.Exists(p => p.X == x && p.Y == y))
                    {
                        neighbours++;
                    }
                }
            }
            if (neighbours == 3)
            {
                Cell cell = Cells.Find(p => p.X == X && p.Y == Y);
                cell.Resurrect = true;
            }
        }

        public void GenerateGameSeed()
        {
            Random random = new Random();

            foreach (var cell in Cells)
            {
                if (random.Next(0, 2) == 1)
                {
                    cell.SwitchAliveState();
                    LivingCells.Add(cell);
                }
            }
        }

        public bool CellShouldSurvive(int numNeighbours)
        {
            if (numNeighbours < 2 || numNeighbours > 3)
            {
                return false;
            }
            return true;
        }

    }

}