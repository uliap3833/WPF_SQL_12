using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_SQL
{
    public partial class Record
    {
        public string FIO
        {
            get
            {
                return Users.last_name + " " + Users.first_name + " " + Users.otc;
            }
        }

        public string AGE
        {
            get
            {
                return Age_group.age_start + " - " + Age_group.age_finish + " лет";
            }
        }

        public SolidColorBrush ColorDate
        {
            get
            {
                switch (Parties.Color.id)
                {
                    case 1: return Brushes.Green;
                    case 2: return Brushes.Yellow;
                    case 3: return Brushes.Pink;
                    case 4: return Brushes.LightBlue;
                    case 5: return Brushes.Blue;
                    case 6: return Brushes.Red;
                    case 7: return Brushes.Orange;
                    default: return Brushes.White;
                }
            }
        }


    }
}
