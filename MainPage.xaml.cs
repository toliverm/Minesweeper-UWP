using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Minesweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GameViewModel gameViewModel = new GameViewModel();
        
        public MainPage()
        {
            this.InitializeComponent();


            this.DataContext = gameViewModel;
            Game game = new Game(gameViewModel.GridRows, gameViewModel.GridColumns, gameViewModel.NumberMines);
            gameViewModel.Draw(game, gameContext);


        }

/*
        public void AddCells(Grid grid, string[,] array)
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
        }*/

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(gameViewModel.GridRows, gameViewModel.GridColumns, gameViewModel.NumberMines);
            gameViewModel.Draw(game, gameContext);

        }

        /*        public class PlayGrid
        {
            public Grid playGrid;

            public PlayGrid(int rows, int cols)
            {
                playGrid = new Grid();
                playGrid.Width = cols*23;
                playGrid.Height = rows*23;

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
        }
        
        public Grid InitializeGrid(int columns, int rows)
        {
            Grid grid = new Grid();
            grid.Width = columns * 22;
            grid.Height = rows * 22;

            for (int i = 0; i < rows; i++)
            {
                var myRowDefinition = new RowDefinition();
                grid.RowDefinitions.Add(myRowDefinition);
            }

            for (int i = 0; i < columns; i++)
            {
                var myColumnDefinition = new ColumnDefinition();
                grid.ColumnDefinitions.Add(myColumnDefinition);
            }

            return grid;
        }


        public Border ConstructCell(string text)
        {
            Border border = new Border();
            border.Style = Resources["CellBorder"] as Style;

            TextBlock contentText = new TextBlock();
            contentText.Text = text;
            contentText.Style = Resources["CellText"] as Style;
            border.Child = contentText;



            return border;

        }

*//*        public void AddCells(Grid grid, string[,] array)
        {
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {

                    if (array[r, c] != null)
                    {
                        Border cell = ConstructCell(array[r, c]);
                        cell.SetValue(Grid.RowProperty, r);
                        cell.SetValue(Grid.ColumnProperty, c);
                        grid.Children.Add(cell);
                    }
                    else
                    {
                        Border cell = ConstructCell("");
                        cell.SetValue(Grid.RowProperty, r);
                        cell.SetValue(Grid.ColumnProperty, c);
                        grid.Children.Add(cell);
                    }
                }
            }
        }*/



    }
}
