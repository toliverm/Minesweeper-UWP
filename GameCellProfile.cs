using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameCellProfile
    {
        public bool IsMine { get; set; }
        public string Text { get; set; }
        public int cellRow { get; set; }
        public int cellColumn { get; set; }
        public int MineCount { get; set; }

        public GameCellProfile()
        {
            this.Text = "";
            this.IsMine = false;
                    }

        public GameCellProfile(int row, int column)
        {
            this.Text = "";
            this.IsMine = false;
            this.cellRow = row;
            this.cellColumn = column;
        }

            public GameCellProfile(int row, int column, string Text, bool isMine)
        {
            this.Text = Text;
            this.IsMine = isMine;
            this.cellRow = row;
            this.cellColumn = column;
        }

        public string Name
        {
            get { return $"{cellRow.ToString()}_{cellColumn.ToString()}"; }
        }

    }
}
