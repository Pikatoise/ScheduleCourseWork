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
    public partial class SubjectWindow : Window
    {
        public Subject currentSubject = new Subject();
        public bool isApply = false;

        public SubjectWindow()
        {
            InitializeComponent();

            TBlockTitle.Text = "Добавление дисциплины";
        }

        public SubjectWindow(Subject subjectToChange)
        {
            InitializeComponent();

            currentSubject = subjectToChange;

            TBoxName.Text = subjectToChange.Name;

            TBlockTitle.Text = "Изменение дисциплины";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBoxName.Text))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            isApply = true;

            currentSubject.Name = TBoxName.Text;

            Close();
        }
    }
}
