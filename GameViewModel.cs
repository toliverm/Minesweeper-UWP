using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using System.Threading;
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
        private int timerCount;
        private int timerSetting;
        private int emptyCellCount;
        private int flagCount;
        private bool flagToggle = false;
        private BindingList<GameBoardRow> boardMembers;
        private Game game;
        

        //Constructors
        public GameViewModel()
        {
            GridRows = 9;
            GridColumns = 9;
            NumberMines = 8;
            this.timerSetting = 90;
            game = new Game(GridRows, GridColumns, NumberMines, timerSetting, this);

            ClickRefresh = new RelayCommand(Refresh);
        }

        //Setters and binding targets
        

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

        public int TimerCount
        {
            get { return timerCount; }
            set
            {
                timerCount = value;
                OnPropertyChanged();
            }
        }

        public int TimerSetting
        {
            get { return timerSetting; }
            set
            {
                timerSetting = value;
                OnPropertyChanged();
            }
        }

        public int EmptyCellCount
        {
            get { return emptyCellCount; }
            set
            {
                emptyCellCount = value;
                OnPropertyChanged();
            }
        }

        public bool FlagToggle
        {
            get { return flagToggle; }
            set
            {
                flagToggle = value;
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

        public int FlagCount
        {
            get { return flagCount; }
            set
            {
                flagCount = value;
                OnPropertyChanged();
            }
        }

        //Click Event Handler Methods

        public RelayCommand ClickRefresh { get; }
        public void Refresh()
        {
            game.Cancel();
            game = new Game(GridRows, GridColumns, NumberMines, timerSetting, this);
            Debug.WriteLine($"Created new game with {gridRows} rows, {gridColumns} columns, and {numberMines} mines\n");
        }

 

        public void CellClickHandler(GameCellProfile cell)
        {
            Debug.Print($"You clicked a cell at co-ordinates x:{cell.CellColumn} y:{cell.CellRow}\n");

            if (!flagToggle)
            {
                game.CollapseCells(this, cell.CellRow, cell.CellColumn);
            } 
            else
            {
                game.FlagTriggerHandler(cell.CellRow, cell.CellColumn, cell.Flagged);
            }
            
        }

        public void FlagTapHandler(GameCellProfile cell)
        {
            game.FlagTriggerHandler(cell.CellRow, cell.CellColumn, cell.Flagged);
        }

        //Event Handler Methods
        public void TriggerLoss()
        {
            Debug.WriteLine("You Lose!\n");
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "You Lose!";
            dialog.CloseButtonText = "Close";
            dialog.DefaultButton = ContentDialogButton.Close;
            DisplayLoseDialog();
        }

        public void TriggerWin()
        {
            Debug.WriteLine("You Win!\n");
            int totalTime = TimerSetting - TimerCount;
            DisplayWinDialog(NumberMines, totalTime);
        }

        private async void DisplayLoseDialog()
        {
            ContentDialog loseDialog = new ContentDialog()
            {
                Title = "You Lose!",
                Content = "Click the button below to begin a new game",
                CloseButtonText = "Try again",
                /*CloseButtonCommand = */
            };

            await loseDialog.ShowAsync();
        }

        private async void DisplayWinDialog(int mines, int time)
        {
            ContentDialog loseDialog = new ContentDialog()
            {
                Title = "You Win!",
                Content = $"Congratulations, you found all {mines.ToString()} mines in {time.ToString()} seconds!",
                CloseButtonText = "Reset Game",
                /*CloseButtonCommand = */
            };

            await loseDialog.ShowAsync();
        }


        //INotifyPropertyChange handlers
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
