using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;

namespace Minesweeper
{
    internal class GameViewModel : INotifyPropertyChanged

    {
        //Private variables
        private int gridRows;
        private int gridColumns;
        private int numberMines;
        private BindingList<GameBoardRow> boardMembers;
        private Game game;
        

        //Constructors
        public GameViewModel()
        {
            GridRows = 9;
            GridColumns = 9;
            NumberMines = 8;
            game = new Game(GridRows, GridColumns, NumberMines, this);
/*            BoardMembers = game.BoardMembers;*/
            ClickRefresh = new RelayCommand(Refresh);
        }

        //Variable setters and binding targets
        

        public int GridRows 
        {
            get { return gridRows; }
            set
            {
                gridRows = value;
                OnPropertyChanged();
            }
        }
        public int GridColumns
        {
            get { return gridColumns; }
            set
            {
                gridColumns = value;
                OnPropertyChanged();
            }
        }

        public int NumberMines
        {
            get { return numberMines; }
            set
            {
                numberMines = value;
                OnPropertyChanged();
            }
        }

        public BindingList<GameBoardRow> BoardMembers
        {
            get { return boardMembers; }
            set
            {
                boardMembers = value;
                OnPropertyChanged();
            }
        }

        //Click Event Handler Methods

        public RelayCommand ClickRefresh { get; }
        public void Refresh()
        {
            game = new Game(gridRows, gridColumns, numberMines, this);
            Debug.WriteLine($"Created new game with {gridRows} rows, {gridColumns} columns, and {numberMines} mines");
/*            BoardMembers = game.BoardMembers;*/
        }



        public void CellClickHandler(int row, int column)
        {
            /*            BoardMembers[row].GameCells[column].ButtonVisible = Visibility.Collapsed;*/
            Debug.Print($"You clicked a cell at co-ordinates x:{column} y:{row}");
            game.CollapseCells(this, row, column);
        }

        public void TriggerLoss()
        {
            Debug.WriteLine("You Lose!");
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "You Lose!";
            dialog.CloseButtonText = "Close";
            dialog.DefaultButton = ContentDialogButton.Close;

/*            var result = await dialog.ShowAsync();*/

        }

        //INotifyPropertyChange handlers
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
