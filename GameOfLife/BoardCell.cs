using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameOfLife
{
    public class BoardCell
    {
        public static int cellSize = 20;
        private static Brush backgroundBrush = new SolidColorBrush(Color.FromArgb(100, 236, 236, 236));
        private static Brush borderBrush = new SolidColorBrush(Color.FromArgb(100, 195, 184, 184));

        private Border border;
        private TextBlock textBlock;

        public string cellText
        {
            get { return textBlock.Text; }
            set => textBlock.Text = value;
        }

        public Point cellLocation
        {
            get => new Point(border.Margin.Left, border.Margin.Bottom);
            set => border.Margin = new Thickness(value.X, value.Y, 0, 0);
        }

        public BoardCell(Grid gameGrid)
        {
            border = new Border();
            border.Background = backgroundBrush;
            border.BorderBrush = borderBrush;
            border.Height = border.Width = cellSize;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            border.Child = textBlock;
            gameGrid.Children.Add(border);
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.VerticalAlignment = VerticalAlignment.Top;
        }

        public void ToggleX()
        {
            if (string.IsNullOrWhiteSpace(textBlock.Text))
            {
                textBlock.Text = "X";
            }
            else
            {
                textBlock.Text = string.Empty;
            }
        }

    }
}