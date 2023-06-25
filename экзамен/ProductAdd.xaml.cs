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
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Page
    {
        Product Product = new Product();
        public ProductAdd()
        {
            InitializeComponent();
            DataContext = Product;
            post.ItemsSource = MainWindow.context.Provider.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Product.ProductCategory = Categ.Text;
            MainWindow.context.Product.Add(Product);
            MainWindow.context.SaveChanges();
            Navigator.frame.Navigate(new ProductDataGrid());
        }

        private void comebake_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate(new ProductDataGrid());
        }
    }
}
