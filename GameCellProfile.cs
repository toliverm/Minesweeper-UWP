using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    //Class used to populate GameBoardRow lists, and provide data binding targets for each gmae cell.
    internal class GameCellProfile : INotifyPropertyChanged
    {
        private Visibility buttonVisible;
        public bool IsMine { get; set; }
        public string Text { get; set; }
        public int CellRow { get; set; }
        public int CellColumn { get; set; }
        public int MineCount { get; set; }

        private GameViewModel ViewModel { get; set; }

        public RelayCommand<GameCell> CellClicked { get; private set; }

        public GameCellProfile()
        {
            this.Text = "";
            this.IsMine = false;
            this.ButtonVisible = Visibility.Visible;
            CellClicked = new RelayCommand<GameCell>(OnCellClicked);
        }

        public GameCellProfile(int row, int column)
        {
            this.Text = "";
            this.IsMine = false;
            this.CellRow = row;
            this.CellColumn = column;
            this.ButtonVisible = Visibility.Visible;
            CellClicked = new RelayCommand<GameCell>(OnCellClicked);
        }

        public GameCellProfile(int row, int column, GameViewModel viewModel)
        {
            this.Text = "";
            this.IsMine = false;
            this.CellRow = row;
            this.CellColumn = column;
            this.ButtonVisible = Visibility.Visible;
            this.ViewModel = viewModel;
            CellClicked = new RelayCommand<GameCell>(OnCellClicked);
        }
        public Visibility ButtonVisible
        {
            get { return buttonVisible; }
            set 
            { 
                buttonVisible = value;
                OnPropertyChanged();
            }
        }
        private void OnCellClicked(GameCell gamecell)
        {
            /*BoardMembers[gamecell.CellRow].GameCells[gamecell.CellColumn].ButtonVisible = false;*/
            ViewModel.CellClickHandler(CellRow,CellColumn);
/*            this.ButtonVisible= Visibility.Collapsed;*/
        }

        public string Name
        {
            get { return $"{CellRow.ToString()}_{CellColumn.ToString()}"; }
        }

        //INotifyPropertyChange handlers
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
