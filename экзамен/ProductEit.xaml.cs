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
    /// Логика взаимодействия для ProductEit.xaml
    /// </summary>
    public partial class ProductEit : Page
    {
        Product product = new Product();
        public ProductEit(Product MyProduct)
        {
            InitializeComponent();
            DataContext = MyProduct;
            post.ItemsSource = MainWindow.context.Provider.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            product.ProductCategory = Categ.Text;
            MainWindow.context.SaveChanges();
            Navigator.frame.Navigate(new ProductDataGrid());
        }

        private void comebake_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate(new ProductDataGrid());
        }
    }
}
