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
    /// Логика взаимодействия для ProductListView.xaml
    /// </summary>
    public partial class ProductListView : Page
    {
        int c = MainWindow.context.Product.Count();
        List<Product> sort = new List<Product>();
        public ProductListView()
        {
            InitializeComponent();
            sort = MainWindow.context.Product.ToList();
            ProductLV.ItemsSource = sort;
            count.Text = sort.Count.ToString() + " из " + c.ToString();
            voz.IsChecked = true;
        }
        bool po = false;
        bool ma = false;
        bool fil = false;

        void SORTIROVKA()
        {
            sort = MainWindow.context.Product.ToList();
            if (po == true)
            {
                var p = sort.Where(s => s.ProductName.ToLower().StartsWith(Poisk.Text) || s.ProductDescription.ToLower().StartsWith(Poisk.Text) ||
                s.ProductManufacturer.ToLower().StartsWith(Poisk.Text) || s.ProductCost.ToString().StartsWith(Poisk.Text)).ToList();
                sort = p;
            }
            if (ma == true)
            {
                var m = sort.Where(s => s.ProductManufacturer == manu.Text).ToList();
                sort = m;
            }
            if (fil == true)
            {
                var v = sort.OrderBy(s => s.ProductCost).ToList();
                sort = v;
            }
            else
            {
                var y = sort.OrderByDescending(s => s.ProductCost).ToList();
                sort = y;
            }
            ProductLV.ItemsSource = sort;
            count.Text = sort.Count.ToString() + " из " + c.ToString();
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Poisk.Text == "") po = false;
            else po = true;
            SORTIROVKA();
        }

        private void yb_Checked(object sender, RoutedEventArgs e)
        {
            fil = false;
            SORTIROVKA();
        }

        private void voz_Checked(object sender, RoutedEventArgs e)
        {
            fil = true;
            SORTIROVKA();
        }

        private void manu_DropDownClosed(object sender, EventArgs e)
        {
            if (manu.Text == "Все производители") ma = false;
            else ma = true;
            SORTIROVKA();
        }
    }
}