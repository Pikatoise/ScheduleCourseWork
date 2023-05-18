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
    public partial class ScheduleStandartWindow : Window
    {
        public Schedulestandart currentSchedulestandart = new Schedulestandart();
        public bool isApply = false;

        List<ComboBoxItem> sequencenumbers = new List<ComboBoxItem>()
        {
            new ComboBoxItem() { Content = 1 },
            new ComboBoxItem() { Content = 2 },
            new ComboBoxItem() { Content = 3 },
            new ComboBoxItem() { Content = 4 },
            new ComboBoxItem() { Content = 5 },
            new ComboBoxItem() { Content = 6 }
        };

        List<ComboBoxItem> divisions = new List<ComboBoxItem>()
        {
            new ComboBoxItem() { Content = "Общая" },
            new ComboBoxItem() { Content = "Первая" },
            new ComboBoxItem() { Content = "Вторая" }
        };

        List<ComboBoxItem> daytypes = new List<ComboBoxItem>()
        {
            new ComboBoxItem() { Content = "Числитель" },
            new ComboBoxItem() { Content = "Знаменатель" }
        };

        public ScheduleStandartWindow()
        {
            InitializeComponent();

            LoadData();

            TBlockTitle.Text = "Добавление стандартного расписания";
        }

        public ScheduleStandartWindow(Schedulestandart schedulestandartToChange)
        {
            InitializeComponent();

            currentSchedulestandart = schedulestandartToChange;

            LoadData();

            CBoxStudygroup.SelectedItem = schedulestandartToChange.StudygroupNavigation;
            CBoxDivision.SelectedItem = divisions.Where(d => (d.Content as string).Equals(schedulestandartToChange.Division)).First();
            CBoxSubject.SelectedItem = schedulestandartToChange.SubjectNavigation;
            CBoxTeacher.SelectedItem = schedulestandartToChange.TeacherNavigation;
            CBoxSequencenumber.SelectedItem = sequencenumbers.Where(s => (int)s.Content == schedulestandartToChange.Sequencenumber).First();
            CBoxCabinet.SelectedItem = schedulestandartToChange.CabinetNavigation;
            CBoxIsremote.IsChecked = schedulestandartToChange.isremote;
            CBoxDaytype.SelectedItem = daytypes.Where(d => (d.Content as string).Equals(schedulestandartToChange.Daytype)).First();


            TBlockTitle.Text = "Изменение стандартного расписания";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBoxStudygroup.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу!");
                return;
            }

            if (CBoxDivision.SelectedItem == null)
            {
                MessageBox.Show("Выберите подгруппу!");
                return;
            }

            if (CBoxSubject.SelectedItem == null)
            {
                MessageBox.Show("Выберите дисциплину!");
                return;
            }

            if (CBoxTeacher.SelectedItem == null)
            {
                MessageBox.Show("Выберите преподавателя!");
                return;
            }

            if (CBoxSequencenumber.SelectedItem == null)
            {
                MessageBox.Show("Выберите пару!");
                return;
            }

            if (CBoxCabinet.SelectedItem == null)
            {
                MessageBox.Show("Выберите кабинет!");
                return;
            }

            if (CBoxDaytype.SelectedItem == null)
            {
                MessageBox.Show("Выберите делитель!");
                return;
            }

            isApply = true;

            currentSchedulestandart.StudygroupNavigation = CBoxStudygroup.SelectedItem as Studygroup;
            currentSchedulestandart.Division = (CBoxDivision.SelectedItem as ComboBoxItem).Content as string;
            currentSchedulestandart.SubjectNavigation = CBoxSubject.SelectedItem as Subject;
            currentSchedulestandart.TeacherNavigation = CBoxTeacher.SelectedItem as Teacher;
            currentSchedulestandart.Sequencenumber = Convert.ToInt32((CBoxSequencenumber.SelectedItem as ComboBoxItem).Content);
            currentSchedulestandart.CabinetNavigation = CBoxCabinet.SelectedItem as Cabinet;
            currentSchedulestandart.isremote = (bool)CBoxIsremote.IsChecked;
            currentSchedulestandart.Daytype = (CBoxDaytype.SelectedItem as ComboBoxItem).Content as string;

            Close();
        }

        void LoadData()
        {
            CBoxSequencenumber.ItemsSource = sequencenumbers;
            CBoxDivision.ItemsSource = divisions;
            CBoxDaytype.ItemsSource = daytypes;
            CBoxStudygroup.ItemsSource = App.DbSchedule.Studygroups.ToList();
            CBoxSubject.ItemsSource = App.DbSchedule.Subjects.ToList();
            CBoxTeacher.ItemsSource = App.DbSchedule.Teachers.ToList();
            CBoxCabinet.ItemsSource = App.DbSchedule.Cabinets.ToList();
        }
    }
}
