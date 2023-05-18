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
    public partial class CabinetWindow : Window
    {
        public Cabinet currentCabinet = new Cabinet();
        public bool isApply = false;

        public CabinetWindow()
        {
            InitializeComponent();

            TBlockTitle.Text = "Добавление кабинета";
        }

        public CabinetWindow(Cabinet cabinetToChange)
        {
            InitializeComponent();

            currentCabinet = cabinetToChange;

            TBoxName.Text = cabinetToChange.Name;

            TBoxComment.Text = cabinetToChange.Comment;

            TBlockTitle.Text = "Изменение кабинета";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBoxName.Text))
            {
                MessageBox.Show("Введите наименование!");
                return;
            }

            isApply = true;

            currentCabinet.Name = TBoxName.Text;
            currentCabinet.Comment = TBoxComment.Text;

            Close();
        }
    }
}
