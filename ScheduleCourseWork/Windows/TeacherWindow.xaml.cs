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
    public partial class TeacherWindow : Window
    {
        public Teacher currentTeacher = new Teacher();
        public bool isApply = false;

        public TeacherWindow()
        {
            InitializeComponent();

            TBlockTitle.Text = "Добавление преподавателя";
        }

        public TeacherWindow(Teacher teacherToChange)
        {
            InitializeComponent();

            currentTeacher = teacherToChange;

            TBoxLastname.Text = teacherToChange.Lastname;

            TBoxFirstname.Text = teacherToChange.Firstname;

            TBoxSurname.Text = teacherToChange.Surname;

            TBlockTitle.Text = "Изменение преподавателя";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBoxLastname.Text))
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            if (string.IsNullOrWhiteSpace(TBoxFirstname.Text))
            {
                MessageBox.Show("Введите имя!");
                return;
            }

            isApply = true;

            currentTeacher.Lastname = TBoxLastname.Text;
            currentTeacher.Firstname = TBoxFirstname.Text;
            currentTeacher.Surname = TBoxSurname.Text;

            Close();
        }
    }
}
