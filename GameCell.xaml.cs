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
using System.Diagnostics;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Minesweeper
{
    [System.ComponentModel.DefaultBindingProperty("GameCell")]
    public sealed partial class GameCell : UserControl
    {
        public GameCell()
        {
            this.InitializeComponent();
/*            this.IsMine = false;
            this.CellContent = "";*/
        }
/*
        public GameCell(int row, int column, string text, bool isMine)
        {

            this.InitializeComponent();
            this.CellRow = row;
            this.CellColumn = column;
            this.CellContent = text;
            this.IsMine = isMine;

        }

        public static DependencyProperty CellContentProperty = DependencyProperty.Register("CellContent", typeof(string), typeof(GameCell), new PropertyMetadata(""));

        public string CellContent
        {
            get
            {
                return (string)GetValue(CellContentProperty);
            }
            set
            {
                SetValue(CellContentProperty, value);
            }
        }

        public static DependencyProperty ButtonVisibleProperty = DependencyProperty.Register("ButtonVisible", typeof(Visibility), typeof(GameCell), new PropertyMetadata(true));
        public Visibility ButtonVisible
        {
            get
            {
                return (Visibility)GetValue(ButtonVisibleProperty);
            }
            set
            {
                SetValue(ButtonVisibleProperty, value);
            }
        }

        public static DependencyProperty CellRowProperty = DependencyProperty.Register("CellRow", typeof(int), typeof(GameCell), new PropertyMetadata(0));
        public int CellRow
        {
            get
            {
                return (int)GetValue(CellRowProperty);
            }
            set
            {
                SetValue(CellRowProperty, value);
            }
        }

        public static DependencyProperty CellColumnProperty = DependencyProperty.Register("CellColumn", typeof(int), typeof(GameCell), new PropertyMetadata(0));
        public int CellColumn
        {
            get
            {
                return (int)GetValue(CellColumnProperty);
            }
            set
            {
                SetValue(CellColumnProperty, value);
            }
        }

        public bool IsMine { get; set; }
        public int MineCount { get; set; }
        public string CellName
        {
            get { return $"{CellRow.ToString()}_{CellColumn.ToString()}"; }
        }

        private void Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Debug.WriteLine("Button Right Tapped");

        }*/
    }
}
