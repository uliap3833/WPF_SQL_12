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

namespace WPF_SQL
{
    /// <summary>
    /// Логика взаимодействия для OrderTable.xaml
    /// </summary>
    public partial class CelebrationTable : Page
    {
        public CelebrationTable()
        {
            InitializeComponent();
            LVCelebration.ItemsSource = Const.BD.Record.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Record Delete = Const.BD.Record.FirstOrDefault(y => y.id == ind);
            Const.BD.Record.Remove(Delete);
            Const.BD.SaveChanges();
            Const.frame.Navigate(new CelebrationTable());
            MessageBox.Show("Запись удалена", "", MessageBoxButton.OK);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Record Update = Const.BD.Record.FirstOrDefault(y => y.id == ind);
            Const.frame.Navigate(new ChangeAdd(Update));
        }

        private void Ladd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new ChangeAdd());
        }
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            if (B.Background == Brushes.Black)
            {
                B.Foreground = Brushes.White;
            }
            else if (B.Background == Brushes.White)
            {
                B.Foreground = Brushes.Black;
            }
            else if (B.Background == Brushes.SeaGreen)
            {
                B.Foreground = Brushes.Yellow;
            }
            else
            {
                B.Foreground = Brushes.Black;
            }
        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new AdminCab());
        }
    }
}
