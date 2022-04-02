using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace Minesweeper
{
    internal class Game
    {
        private readonly int defaultGridRows = 9;
        private readonly int defaultGridColumns = 9;
        private readonly int defaultNumberMines = 8;

        public int GridRows { get; set; }
        public int GridColumns { get; set; }
        public int NumberMines { get; set; }
        public BindingList<GameBoardRow> BoardMembers { get; set; }

        public Game(GameViewModel viewModel)
        {
            this.GridRows = defaultGridRows;
            this.GridColumns = defaultGridColumns;
            this.NumberMines = defaultNumberMines;
            this.InitializeGameBoard(viewModel);
            
        }

        public Game(int gridRows, int gridColumns, int numberMines, GameViewModel viewModel)
        {
            this.GridRows = gridRows;
            this.GridColumns = gridColumns;
            this.NumberMines = numberMines;
            this.InitializeGameBoard(viewModel);
        }

        public void InitializeGameBoard(GameViewModel viewModel)
        {
            viewModel.BoardMembers = new BindingList<GameBoardRow>();

            for (int r = 0; r < GridRows; r++)
            {
                viewModel.BoardMembers.Add(new GameBoardRow(r, GridColumns, viewModel));
            }


            //Adds a number of mines in random positions based on the "NumberMines" Game class property. Known bug - Currently can produce redundancy in mine locations.
            for (int i = 0; i < NumberMines; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, GridRows);
                int c = rnd.Next(0, GridColumns);


                viewModel.BoardMembers[r].GameCells[c].Text = "*";
                viewModel.BoardMembers[r].GameCells[c].IsMine = true;
            }

            //Calculates the number of adjacent mines for each non-mine cell, and then replaces the text in the cell with that number when it is greater than 0.
            foreach(GameBoardRow row in viewModel.BoardMembers)
            {
                foreach (GameCellProfile cell in row.GameCells)
                {
                    if (cell.IsMine == true)
                    {
                        continue;
                    }
                    else
                    {
                        List<int[]> nearbyCells = getNearbyCoords(cell.CellColumn, cell.CellRow, GridColumns-1, GridRows-1);
                        foreach (int[] nearbyCell in nearbyCells)
                        {
                            if (viewModel.BoardMembers[nearbyCell[1]].GameCells[nearbyCell[0]].IsMine == true)
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
        public void CollapseCells(GameViewModel viewModel, int row, int column)
        {
            GameCellProfile baseCell = viewModel.BoardMembers[row].GameCells[column];

            if(baseCell.IsMine == true)
            {
                baseCell.ButtonVisible = Visibility.Collapsed;
                viewModel.TriggerLoss();
            }
            else if (baseCell.MineCount > 0)
            {
                baseCell.ButtonVisible = Visibility.Collapsed;
            }
            else
            {
                baseCell.ButtonVisible = Visibility.Collapsed;
                List<int[]> newIteration = new List<int[]>
                {
                    new int[] { row, column },
                };
                
                while (newIteration.Any())
                {
                    List<int[]> thisIteration = new List<int[]>(newIteration);
                    newIteration.Clear();

                    foreach (int[] coords in thisIteration)
                    {
                        List<int[]> nearbyCells = getNearbyCoords(coords[0], coords[1], GridRows - 1, GridColumns - 1);

                        foreach (int[] nearbyCell in nearbyCells)
                        {
                            GameCellProfile cell = viewModel.BoardMembers[nearbyCell[0]].GameCells[nearbyCell[1]];
                            if (cell.ButtonVisible == Visibility.Collapsed)
                            {
                                continue;
                            }
                            else if(cell.IsMine == true)
                            {
                                continue;
                            }
                            else if (cell.MineCount == 0)
                            {
                                cell.ButtonVisible = Visibility.Collapsed;
                                newIteration.Add(nearbyCell);
                            }
                            else
                            {
                                cell.ButtonVisible = Visibility.Collapsed;
                            }
                        }
                    }

                }
            }
        }

        // Returns list of int[2]{x,y} co-ordinates for each surrounding cell of position x,y that falls within the grid boundaries of xMax, yMax. Co-ordinates begin at 0,0.
        internal List<int[]> getNearbyCoords(int row, int column, int rowMax, int colMax)
        {
            List<int[]> coords = new List<int[]>();

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if ((i >= 0 && i <= rowMax) && (j >= 0 && j <= colMax) && !(i == row && j == column))
                    {
                        coords.Add(new int[] { i, j });
                    }
                }
            }

            return coords;
        }
    }
}
