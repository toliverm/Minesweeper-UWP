﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    //Class used to populate GameBoardRow lists, and provide data binding targets for each gmae cell.
    internal class GameCellProfile : INotifyPropertyChanged
    {
        private Visibility buttonVisible = Visibility.Visible;
        private bool flagged = false;
        private Visibility flagVisible = Visibility.Collapsed;
        public string text = "";

        public bool IsMine { get; set; }
        public int CellRow { get; set; }
        public int CellColumn { get; set; }
        public int MineCount { get; set; }
        

        private GameViewModel ViewModel { get; set; }

        public RelayCommand CellClicked { get; }
        public RelayCommand FlagTap { get; }

        public GameCellProfile()
        {
            this.Text = "";
            this.IsMine = false;
            CellClicked = new RelayCommand(OnCellClicked);
            FlagTap = new RelayCommand(TriggerFlagTap);

        }

        public GameCellProfile(int row, int column)
        {
            this.Text = "";
            this.IsMine = false;
            this.CellRow = row;
            this.CellColumn = column;
            CellClicked = new RelayCommand(OnCellClicked);
            FlagTap = new RelayCommand(TriggerFlagTap);
        }

        public GameCellProfile(int row, int column, GameViewModel viewModel)
        {
            this.Text = "";
            this.IsMine = false;
            this.CellRow = row;
            this.CellColumn = column;
            this.ViewModel = viewModel;
            CellClicked = new RelayCommand(OnCellClicked);
            FlagTap = new RelayCommand(TriggerFlagTap);
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

        public bool Flagged
        {
            get { return flagged; }
            set
            {
                flagged = value;
                OnPropertyChanged();
                if (value) { FlagVisible = Visibility.Visible; } else { FlagVisible = Visibility.Collapsed; }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public Visibility FlagVisible
        {
            get { return flagVisible; }
            set
            {
                flagVisible = value;
                OnPropertyChanged();
            }
        }

        private void OnCellClicked()
        {
            ViewModel.CellClickHandler(this);
        }

        private void TriggerFlagTap()
        {
            ViewModel.FlagTapHandler(this);
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
