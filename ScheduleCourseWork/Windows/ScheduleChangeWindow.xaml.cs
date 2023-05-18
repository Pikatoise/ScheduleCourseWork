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
    public partial class ScheduleChangeWindow : Window
    {
        public Schedulechanged currentSchedulechanged = new Schedulechanged();
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

        public ScheduleChangeWindow()
        {
            InitializeComponent();

            LoadData();

            TBlockTitle.Text = "Добавление изменения в расписание";
        }

        public ScheduleChangeWindow(Schedulechanged schedulechangedToChange)
        {
            InitializeComponent();

            currentSchedulechanged = schedulechangedToChange;

            LoadData();

            CBoxStudygroup.SelectedItem = schedulechangedToChange.StudygroupNavigation;
            CBoxDivision.SelectedItem = divisions.Where(d => (d.Content as string).Equals(schedulechangedToChange.Division)).First();
            CBoxSubject.SelectedItem = schedulechangedToChange.SubjectNavigation;
            CBoxTeacher.SelectedItem = schedulechangedToChange.TeacherNavigation;
            CBoxSequencenumber.SelectedItem = sequencenumbers.Where(s => (int)s.Content == schedulechangedToChange.Sequencenumber).First();
            CBoxCabinet.SelectedItem = schedulechangedToChange.CabinetNavigation;
            CBoxIsremote.IsChecked = schedulechangedToChange.isremote;


            TBlockTitle.Text = "Изменение изменения(😁) в расписании";
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

            isApply = true;

            currentSchedulechanged.StudygroupNavigation = CBoxStudygroup.SelectedItem as Studygroup;
            currentSchedulechanged.Division = (CBoxDivision.SelectedItem as ComboBoxItem).Content as string;
            currentSchedulechanged.SubjectNavigation = CBoxSubject.SelectedItem as Subject;
            currentSchedulechanged.TeacherNavigation = CBoxTeacher.SelectedItem as Teacher;
            currentSchedulechanged.Sequencenumber = Convert.ToInt32((CBoxSequencenumber.SelectedItem as ComboBoxItem).Content);
            currentSchedulechanged.CabinetNavigation = CBoxCabinet.SelectedItem as Cabinet;
            currentSchedulechanged.isremote = (bool)CBoxIsremote.IsChecked;

            Close();
        }

        void LoadData()
        {
            CBoxSequencenumber.ItemsSource = sequencenumbers;
            CBoxDivision.ItemsSource = divisions;
            CBoxStudygroup.ItemsSource = App.DbSchedule.Studygroups.ToList();
            CBoxSubject.ItemsSource = App.DbSchedule.Subjects.ToList();
            CBoxTeacher.ItemsSource = App.DbSchedule.Teachers.ToList();
            CBoxCabinet.ItemsSource = App.DbSchedule.Cabinets.ToList();
        }
    }
}
