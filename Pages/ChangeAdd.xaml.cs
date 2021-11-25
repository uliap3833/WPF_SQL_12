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
    /// Логика взаимодействия для ChageAdd.xaml
    /// </summary>
    public partial class ChangeAdd : Page
    {
        Record RecordObj = new Record();
        bool Save;
        public ChangeAdd()
        {
            InitializeComponent();
            Save = true;

            CBuser.ItemsSource = Const.BD.Users.ToList();
            CBuser.SelectedValuePath = "user_id";
            CBuser.DisplayMemberPath = "FIO";

            CBage_group.ItemsSource = Const.BD.Age_group.ToList();
            CBage_group.SelectedValuePath = "id";
            CBage_group.DisplayMemberPath = "AGE";

            CBparties.ItemsSource = Const.BD.Parties.ToList();
            CBparties.SelectedValuePath = "id";
            CBparties.DisplayMemberPath = "name";
        }

        public ChangeAdd(Record Update)
        {
            InitializeComponent();
            RecordObj = Update;
            Save = false;

            CBuser.ItemsSource = Const.BD.Users.ToList();
            CBuser.SelectedValuePath = "user_id";
            CBuser.DisplayMemberPath = "FIO";

            CBage_group.ItemsSource = Const.BD.Age_group.ToList();
            CBage_group.SelectedValuePath = "id";
            CBage_group.DisplayMemberPath = "AGE";

            CBparties.ItemsSource = Const.BD.Parties.ToList();
            CBparties.SelectedValuePath = "id";
            CBparties.DisplayMemberPath = "name";

            DPdate.SelectedDate = Update.party_date;
            CBage_group.SelectedIndex = Update.age_group_id - 1;
            CBparties.SelectedIndex = Update.parties_id - 1;
            CBuser.SelectedIndex = Update.user_id - 1;

        }

        private void Breg_Click(object sender, RoutedEventArgs e)
        {
            RecordObj.party_date = DPdate.DisplayDate.Date;
            RecordObj.parties_id = CBparties.SelectedIndex + 1;
            RecordObj.age_group_id = CBage_group.SelectedIndex + 1;
            RecordObj.user_id = CBuser.SelectedIndex + 1;
            if (Save)
            {
                Const.BD.Record.Add(RecordObj);
            }
            Const.BD.SaveChanges();
            MessageBox.Show("Данные записаны", "", MessageBoxButton.OK);
            DPdate.SelectedDate = null;
            CBage_group.SelectedItem = null;
            CBparties.SelectedItem = null;
            CBuser.SelectedItem = null;

            Const.BD.SaveChanges();

        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new CelebrationTable());
        }
    }
}
