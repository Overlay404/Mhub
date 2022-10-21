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
        public DBEntities db = new DBEntities();
        public MainWindow()
        {
            InitializeComponent();
            Build();

            var query = from typeProduct in db.TypeProduct
                        from product in typeProduct.Product
                        from material in db.Material
                        from productMaterial in material.ProductMaterial
                        where product.id == productMaterial.idProduct
                        select new
                        {
                            id = product.id,
                            nameProduct = product.Name,
                            typeProduct = typeProduct.Name,
                            nameMaterial = material.Name,
                            price = material.Price

                        };

            foreach(var entity in query)
            {
                MessageBox.Show("" + entity.id + " " + entity.nameProduct + " " + entity.nameMaterial + " " + entity.price);
            }

            

        }

        private void Search_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Search.Clear();
        }


        public void Build()
        {
            StackPanel mainPanel = new StackPanel() {Height = 80, Margin = new Thickness(30, 10, 30, 0), Orientation = Orientation.Horizontal };
            Image image = new Image() { Width = 80, Source = new BitmapImage(new Uri("Resource/picture.png", UriKind.Relative)), Margin = new Thickness(20, 0, 0, 0) };
            StackPanel textPanel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(30, 0, 0, 0) };
            StackPanel typePanel = new StackPanel() { Orientation = Orientation.Horizontal };
            TextBlock typeText = new TextBlock() { Text = "Резина", FontSize=20 };
            TextBlock separator = new TextBlock() { Text = "|", FontSize = 20 };
            TextBlock productText = new TextBlock() { Text = "Огурец", FontSize = 20 };
            TextBlock idText = new TextBlock() { Text = "2" };
            TextBlock nametext = new TextBlock() { Text = "Материалы: Камень, огурец, земля" };
            StackPanel panel = new StackPanel() { Orientation = Orientation.Vertical, Margin = new Thickness(70, 0, 0, 0)};
            TextBlock descriptionText = new TextBlock() { Text = "Стоимость", FontSize = 20 };
            TextBlock countText = new TextBlock() { Text = "21312" };
            mainPanel.MouseEnter += MainPanel_GotFocus;
            mainPanel.MouseLeave += MainPanel_MouseLeave;


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

        private void MainPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            panel.Background = Brushes.Transparent;
        }

        private void MainPanel_GotFocus(object sender, RoutedEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            panel.Background = Brushes.LightGray;
        }
    }
}
