using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Minesweeper
{
    internal class Game
    {
        private int defaultGridRows = 9;
        private int defaultGridColumns = 9;
        private int defaultNumberMines = 5;

        public int GridRows { get; set; }
        public int GridColumns { get; set; }
        public int NumberMines { get; set; }
        public GameCellProfile[,] BoardMembers { get; set; }

        public Game()
        {
            this.GridRows = defaultGridRows;
            this.GridColumns = defaultGridColumns;
            this.NumberMines = defaultNumberMines;
            this.InitializeGameBoard();
            
        }

        public Game(int gridRows, int gridColumns, int numberMines)
        {
            this.GridRows = gridRows;
            this.GridColumns = gridColumns;
            this.NumberMines = numberMines;
            this.InitializeGameBoard();
        }




        public void InitializeGameBoard()
        {
            BoardMembers = new GameCellProfile[GridRows, GridColumns];

            for (int r = 0; r < BoardMembers.GetLength(0); r++)
            {
                for (int c = 0; c < BoardMembers.GetLength(1); c++)
                {
                    BoardMembers[r, c] = new GameCellProfile(r, c, "", false);
/*                    BoardMembers[r, c].SetValue(Grid.RowProperty, r);
                    BoardMembers[r, c].SetValue(Grid.ColumnProperty, c);*/
                }
            }



                    for (int i = 0; i < NumberMines; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, GridRows);
                int c = rnd.Next(0, GridColumns);


                BoardMembers[r, c].Text = "*";
                BoardMembers[r, c].IsMine = true;




            }

            for (int r = 0; r < BoardMembers.GetLength(0); r++)
            {
                for (int c = 0; c < BoardMembers.GetLength(1); c++)
                {

                    if (BoardMembers[r, c].IsMine == true)
                    {
                        continue;
                    }
                    else
                    {

                        try
                        {
                            if (BoardMembers[r + 1, c].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            if (BoardMembers[r + 1, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            if (BoardMembers[r, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r + 1, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        if (BoardMembers[r, c].MineCount == 0)
                        {
                            continue;
                        }
                        else

                        {
                            BoardMembers[r, c].Text = BoardMembers[r, c].MineCount.ToString() ;
                        }
                    }
                }
            }
        }


/*        public void InitializeGameBoard()
        {
            BoardMembers = new GameCellProfile[GridRows, GridColumns];

            for (int r = 0; r < BoardMembers.GetLength(0); r++)
            {
                for (int c = 0; c < BoardMembers.GetLength(1); c++)
                {
                    BoardMembers[r, c] = new GameCellProfile(r, c);
                }
            }



            for (int i = 0; i < NumberMines; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, GridRows);
                int c = rnd.Next(0, GridColumns);


                BoardMembers[r, c].Text = "*";
                BoardMembers[r, c].IsMine = true;
                *//*                while (true)
                                {
                                    if (BoardMembers[r, c] == null)
                                    {
                                        BoardMembers[r, c] = "*";
                                        break;
                                    }
                                }*//*



            }

            for (int r = 0; r < BoardMembers.GetLength(0); r++)
            {
                for (int c = 0; c < BoardMembers.GetLength(1); c++)
                {

                    if (BoardMembers[r, c].IsMine == true)
                    {
                        continue;
                    }
                    else
                    {

                        try
                        {
                            if (BoardMembers[r + 1, c].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            if (BoardMembers[r + 1, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            if (BoardMembers[r, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c + 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r - 1, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (BoardMembers[r + 1, c - 1].IsMine == true)
                            {
                                BoardMembers[r, c].MineCount++;
                            }
                        }
                        catch (Exception) { }

                        if (BoardMembers[r, c].MineCount == 0)
                        {
                            continue;
                        }
                        else

                        {
                            BoardMembers[r, c].Text = BoardMembers[r, c].MineCount.ToString();
                        }
                    }
                }
            }
        }*/


    }
}
