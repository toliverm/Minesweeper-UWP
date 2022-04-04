using Windows.UI.Xaml.Controls;

// Individual cell component for minesweeper gameboard

namespace Minesweeper
{
    [System.ComponentModel.DefaultBindingProperty("GameCell")]
    public sealed partial class GameCell : UserControl
    {
        public GameCell()
        {
            this.InitializeComponent();
        }
    }
}
