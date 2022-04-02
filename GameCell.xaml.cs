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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Minesweeper
{
    public sealed partial class GameCell : UserControl
    {
        public string CellContent { get; set; }
        public bool IsMine { get; set; }
        public int cellRow { get; set; }
        public int cellColumn { get; set; }
        public int MineCount { get; set; }
        public string CellName
        {
            get { return $"{cellRow.ToString()}_{cellColumn.ToString()}"; }
        }
               
        public GameCell(int row, int column, string text, bool isMine)
        {

            this.InitializeComponent();
            this.cellRow = row;
            this.cellColumn = column;
            this.CellContent = text;
            this.IsMine = isMine;

        }


     
    }
}
