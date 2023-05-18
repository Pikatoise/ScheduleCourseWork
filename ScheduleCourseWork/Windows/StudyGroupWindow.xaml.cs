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
    public partial class StudyGroupWindow : Window
    {
        public Studygroup currentGroup = new Studygroup();
        public bool isApply = false;

        public StudyGroupWindow()
        {
            InitializeComponent();
         
            TBlockTitle.Text = "Добавление группы";
        }

        public StudyGroupWindow(Studygroup groupToChange)
        {
            InitializeComponent();

            currentGroup = groupToChange;

            TBoxName.Text = groupToChange.Name;

            TBoxComment.Text = groupToChange.Comment;

            TBlockTitle.Text = "Изменение группы";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBoxName.Text))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            isApply = true;

            currentGroup.Name = TBoxName.Text;
            currentGroup.Comment = TBoxComment.Text;

            Close();
        }
    }
}
