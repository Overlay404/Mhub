using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mhub
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Build();
            
        }

        private void Search_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Search.Clear();
        }


        public void Build()
        {
            StackPanel mainPanel = new StackPanel() { Height = 80, Margin = new Thickness(30, 10, 10, 10), Orientation = Orientation.Horizontal };
            Image image = new Image() { Width = 80, Source = new BitmapImage(new Uri("Resource/picture.png", UriKind.Relative)) };
            StackPanel textPanel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(30, 10, 0, 0) };
            StackPanel typePanel = new StackPanel() { Orientation = Orientation.Horizontal };
            TextBlock typeText = new TextBlock() { Text = "Резина" };
            TextBlock separator = new TextBlock() { Text = "|" };
            TextBlock productText = new TextBlock() { Text = "Огурец" };
            TextBlock idText = new TextBlock() { Text = "2" };
            TextBlock nametext = new TextBlock() { Text = "Материалы: Камень, огурец, земля" };
            StackPanel panel = new StackPanel() { Orientation = Orientation.Vertical };
            TextBlock descriptionText = new TextBlock() { Text = "Стоимость" };
            TextBlock countText = new TextBlock() { Text = "21312" };

            mainArea.Children.Add(mainPanel);
            mainPanel.Children.Add(image);
            mainPanel.Children.Add(textPanel);
            textPanel.Children.Add(typePanel);
            typePanel.Children.Add(typeText);
            typePanel.Children.Add(separator);
            typePanel.Children.Add(productText);
            textPanel.Children.Add(idText);
            textPanel.Children.Add(nametext);
            mainPanel.Children.Add(panel);
            panel.Children.Add(descriptionText);
            panel.Children.Add(countText);
        }
    }
}
