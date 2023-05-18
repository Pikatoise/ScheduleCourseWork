using ScheduleCourseWork.Models;
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
using System.Windows.Shapes;

namespace ScheduleCourseWork.Windows
{
    public partial class ScheduleCurrentWindow : Window
    {
        public Schedulecurrent currentSchedulecurrent = new Schedulecurrent();
        public bool isApply = false;

        List<ComboBoxItem> daytypes = new List<ComboBoxItem>()
        {
            new ComboBoxItem() { Content = "Числитель" },
            new ComboBoxItem() { Content = "Знаменатель" }
        };

        public ScheduleCurrentWindow()
        {
            InitializeComponent();

            DPickerDate.SelectedDate = DateTime.Now;
            CBoxDaytype.ItemsSource = daytypes;
            CBoxWeekday.ItemsSource = App.DbSchedule.Weekdays.ToList();

            TBlockTitle.Text = "Добавление текущего расписания";
        }

        public ScheduleCurrentWindow(Schedulecurrent schedulecurrentToChange)
        {
            InitializeComponent();

            currentSchedulecurrent = schedulecurrentToChange;

            CBoxDaytype.ItemsSource = daytypes;
            CBoxWeekday.ItemsSource = App.DbSchedule.Weekdays.ToList();

            DPickerDate.SelectedDate = schedulecurrentToChange.Currentdate.ToDateTime(new TimeOnly(0));
            CBoxDaytype.SelectedItem = daytypes.Where(d => (d.Content as string).Equals(schedulecurrentToChange.Daytype)).First();
            CBoxWeekday.SelectedItem = schedulecurrentToChange.WeekdayNavigation;

            TBlockTitle.Text = "Изменение текущего расписания";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBoxDaytype.SelectedItem == null)
            {
                MessageBox.Show("Выберите делитель!");
                return;
            }

            if (CBoxWeekday.SelectedItem == null)
            {
                MessageBox.Show("Выберите день недели!");
                return;
            }

            if (DPickerDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!");
                return;
            }

            isApply = true;

            currentSchedulecurrent.Currentdate = DateOnly.FromDateTime((DateTime)DPickerDate.SelectedDate);
            currentSchedulecurrent.WeekdayNavigation = CBoxWeekday.SelectedItem as Weekday;
            currentSchedulecurrent.Daytype = (CBoxDaytype.SelectedItem as ComboBoxItem).Content as string;

            Close();
        }
    }
}
