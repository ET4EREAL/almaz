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
    /// Логика взаимодействия для Avto.xaml
    /// </summary>
    public partial class Avto : Page
    {
        public Avto()
        {
            InitializeComponent();
        }

        int count = 0;
        string capch;

        void AvtoInput()
        {
            try
            {
                var u = MainWindow.context.User.Where(s => s.UserLogin == LoginTB.Text && s.UserPassword == PasswordTB.Password).First();
                if (u.UserRole == 1)
                {
                    Navigator.frame.Navigate(new ProductDataGrid());
                    return;
                }
                if (u.UserRole == 2)
                {
                    Navigator.frame.Navigate(new ProductListView());
                    return;
                }
                if (u.UserRole == 3)
                {
                    Navigator.frame.Navigate(new ProductListView());
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Данные были введены не верно", "", MessageBoxButton.OK);
                count = 1;
                LoginTB.Text = ""; PasswordTB.Password = "";
            }
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {

            //return;

            if (LoginTB.Text == "" || PasswordTB.Password.ToString() == "")
            {
                MessageBox.Show("Вы не ввели данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (LoginTB.Text == "1") Navigator.frame.Navigate(new ProductDataGrid());
                if (LoginTB.Text == "2") Navigator.frame.Navigate(new ProductListView());
            }

            if (count == 0)
            {
                AvtoInput();
                return;
            }
            CaphGrid.Visibility = Visibility.Visible;
            CAPTCHA();
        }

        void CAPTCHA()
        {
            capch = "";
            string sim = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
                capch += sim.Substring(random.Next(0, sim.Length), 1);
            CapchTBlock.Text = capch;
        }

        private void CapchBut_Click(object sender, RoutedEventArgs e)
        {
            CaphGrid.Visibility = Visibility.Hidden;
            if (CapchTBox.Text == capch)
            {
                CapchTBox.Text = "";
                AvtoInput();
                return;
            }
            CapchTBox.Text = "";
            MessageBox.Show("CAPTCHA была введена не верно", "",MessageBoxButton.OK);

        }
    }
}
