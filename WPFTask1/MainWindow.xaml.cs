using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random;
        public MainWindow()
        {
            InitializeComponent();

            _random = new Random();
        }

        private SolidColorBrush CreateRandomColor()
        {
            var r = Convert.ToByte(_random.Next(0, 256));
            var g = Convert.ToByte(_random.Next(0, 256));
            var b = Convert.ToByte(_random.Next(0, 256));

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void Button_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    ChangeButtonColor(sender, e);
                    break;
                case MouseButton.Right:
                    ChangeWindowTitle(sender, e);
                    DeleteButton(sender, e);
                    break;
            }
        }

        private void ChangeButtonColor(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            button.Background = CreateRandomColor();
        }

        private void ChangeWindowTitle(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            this.Title = button.Content.ToString();
        }

        private void DeleteButton(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            GridButtons.Children.Remove(button);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (UIElement uiElement in GridButtons.Children)
            {
                if (uiElement is Button button)
                    button.Background = CreateRandomColor();
            }
        }
    }
}
