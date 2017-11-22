using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cell> Cells = new List<Cell>();
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            DrawCells();
            game = new Game(Cells);
        }

        private void DrawCells()
        {

            for (int y = 1; y <= 50; y++)
            {
                for (int x = 1; x <= 50; x++)
                {
                    Cell cell = new Cell(x, y, GameGrid);
                    Cells.Add(cell);
                }
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            game.PlayTurn();
        }


        

    }
}
