using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Minesweeper
{
    internal class Game
    {
        private readonly int defaultGridRows = 9;
        private readonly int defaultGridColumns = 9;
        private readonly int defaultNumberMines = 5;

        public int GridRows { get; set; }
        public int GridColumns { get; set; }
        public int NumberMines { get; set; }
        public BindingList<GameBoardRow> BoardMembers { get; set; }

        public Game()
        {
            this.GridRows = defaultGridRows;
            this.GridColumns = defaultGridColumns;
            this.NumberMines = defaultNumberMines;
            this.InitializeGameBoard();
            
        }

        public Game(int gridRows, int gridColumns, int numberMines)
        {
            this.GridRows = gridRows;
            this.GridColumns = gridColumns;
            this.NumberMines = numberMines;
            this.InitializeGameBoard();
        }




        // Returns list of int[2]{x,y} co-ordinates for each surrounding cell of position x,y that falls within the grid boundaries of xMax, yMax. Co-ordinates begin at 0,0.
        internal List<int[]> getNearbyCoords(int x, int y, int xMax, int yMax)
        {
            List<int[]> coords = new List<int[]>();

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if ((i >= 0 && i <= xMax) && (j >= 0 && j <= yMax) && !(i == x && j == y))
                    {
                        coords.Add(new int[] { i, j });
                    }
                }
            }

            return coords;
        }

        public void InitializeGameBoard()
        {
            BoardMembers = new BindingList<GameBoardRow>();

            for (int r = 0; r < GridRows; r++)
            {
                BoardMembers.Add(new GameBoardRow(r, GridColumns));
            }


            //Adds a number of mines in random positions based on the "NumberMines" Game class property. Known bug - Currently can produce redundancy in mine locations.
            for (int i = 0; i < NumberMines; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, GridRows);
                int c = rnd.Next(0, GridColumns);


                BoardMembers[r].GameCells[c].Text = "*";
                BoardMembers[r].GameCells[c].IsMine = true;




            }

            //Calculates the number of adjacent mines for each non-mine cell, and then replaces the text in the cell with that number when it is greater than 0.
            foreach(GameBoardRow row in BoardMembers)
            {
                foreach (GameCellProfile cell in row.GameCells)
                {
                    if (cell.IsMine == true)
                    {
                        continue;
                    }
                    else
                    {
                        List<int[]> nearbyCells = getNearbyCoords(cell.cellColumn, cell.cellRow, GridColumns-1, GridRows-1);
                        foreach (int[] nearbyCell in nearbyCells)
                        {
                            if (BoardMembers[nearbyCell[1]].GameCells[nearbyCell[0]].IsMine == true)
                            {
                                cell.MineCount++;
                            }
                        }

                        if(cell.MineCount > 0)
                        {
                            cell.Text = cell.MineCount.ToString();
                        }                        
                    }

                }
            }
        }
    }
}
