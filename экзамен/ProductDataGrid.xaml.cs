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

namespace экзамен
{
    /// <summary>
    /// Логика взаимодействия для ProductDataGrid.xaml
    /// </summary>
    public partial class ProductDataGrid : Page
    {
        public ProductDataGrid()
        {
            InitializeComponent();
            DataContext = MainWindow.context.Product.ToList();
        }

        private void ProdAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate( new ProductAdd());
        }

        private void ProdUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate(new ProductEit((sender as Button).DataContext as Product));
        }

        private void ProdDrop_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить продукт?","Удаление товара",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;
            try
            {
                MainWindow.context.Product.Remove((sender as Button).DataContext as Product);
                MainWindow.context.SaveChanges();
                MessageBox.Show("Товар удален");
                Navigator.frame.Navigate(new ProductDataGrid());
            }
            catch
            {
                MessageBox.Show("Данные удалить нельзя");
            }
        }
    }
}
