using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Minesweeper
{
    
    //Game board row object used to populate the GameBoard list, and provides nesting of cells within each row.
    internal class GameBoardRow
    {
        public int RowID { get; set; }
        public BindingList<GameCellProfile> GameCells { get; set; }
        private GameViewModel ViewModel { get; set; }

        public GameBoardRow(int rowID)
        {
            RowID = rowID;
            GameCells = new BindingList<GameCellProfile>();
        }

        public GameBoardRow(int rowID, int columnCount, GameViewModel viewModel)
        {
            RowID = rowID;
            GameCells = new BindingList<GameCellProfile>();
            ViewModel = viewModel;
            for (int i = 0; i < columnCount; i++)
            {
                GameCells.Add(new GameCellProfile(rowID, i, ViewModel));
            }
        }
    }

}
