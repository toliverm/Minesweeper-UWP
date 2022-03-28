using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Minesweeper
{
    internal class GameViewModel
    {
        private int defaultGridRows = 9;
        private int defaultGridColumns = 9;
        private int defaultNumberMines = 5;

        public int GridRows { get; set; }
        public int GridColumns { get; set; }
        public int NumberMines { get; set; }
        public string[,] BoardMembers { get; set; }

        public GameViewModel()
        {
            this.GridRows = defaultGridRows;
            this.GridColumns = defaultGridColumns;
            this.NumberMines = defaultNumberMines;
        }

        public void Draw(Game game, Grid grid)
        {
            PlayGrid playGrid = new PlayGrid(game.GridRows, game.GridColumns);
            playGrid.playGrid.Children.Add(game.BoardMembers)
/*            playGrid.AddCells(playGrid.playGrid, game.BoardMembers);*/
            grid.Children.Clear();
            grid.Children.Add(playGrid.playGrid);
        }

        public class PlayGrid
        {
            public Grid playGrid;

            public PlayGrid(int rows, int cols)
            {
                playGrid = new Grid();
                playGrid.Width = cols * 23;
                playGrid.Height = rows * 23;

                for (int i = 0; i < rows; i++)
                {
                    var myRowDefinition = new RowDefinition();
                    myRowDefinition.Height = new GridLength(22);
                    playGrid.RowDefinitions.Add(myRowDefinition);

                }

                for (int j = 0; j < cols; j++)
                {
                    var myColumnDefinition = new ColumnDefinition();
                    myColumnDefinition.Width = new GridLength(22);
                    playGrid.ColumnDefinitions.Add(myColumnDefinition);
                }
            }


            public void AddCells(Grid grid, GameCellProfile[,] array)
            {
                for (int r = 0; r < array.GetLength(0); r++)
                {
                    for (int c = 0; c < array.GetLength(1); c++)
                    {

                        if (array[r, c] != null)
                        {
                            GameCell cell = new GameCell(r, c, array[r, c].Text, array[r, c].IsMine);
                            cell.SetValue(Grid.RowProperty, r);
                            cell.SetValue(Grid.ColumnProperty, c);
                            grid.Children.Add(cell);
                        }
                        else
                        {
                            GameCell cell = new GameCell(r, c, "", false);
                            cell.SetValue(Grid.RowProperty, r);
                            cell.SetValue(Grid.ColumnProperty, c);
                            grid.Children.Add(cell);
                        }
                    }
                }
            }
        }
    }
}
