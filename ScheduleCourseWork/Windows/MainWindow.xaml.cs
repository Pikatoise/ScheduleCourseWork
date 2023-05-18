using Microsoft.EntityFrameworkCore;
using ScheduleCourseWork.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;

namespace ScheduleCourseWork.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!App.CanConnect)
                BlockInterface(true);
        }

        bool isSchedulestandartActionsEnabled = false;
        bool isSchedulechangesActionsEnabled = false;
        bool isPrintEnabled = false;

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (e.Source is TabControl)
                RefreshData(TControlMain.SelectedItem as TabItem);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (TControlMain.SelectedItem != null)
            {
                AddItem();

                RefreshData(TControlMain.SelectedItem as TabItem);
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (TControlMain.SelectedItem != null)
            {
                RemoveItem();

                RefreshData(TControlMain.SelectedItem as TabItem);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (TControlMain.SelectedItem != null)
            {
                EditItem();

                RefreshData(TControlMain.SelectedItem as TabItem);
            }
        }

        private void DGridWeekdays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (DGridWeekdays.SelectedItem != null)
            {
                if (!isSchedulestandartActionsEnabled)
                {
                    isSchedulestandartActionsEnabled = true;

                    ButtonAddSchedulestandart.IsEnabled = true;
                    ButtonRemoveSchedulestandart.IsEnabled = true;
                    ButtonEditSchedulestandart.IsEnabled = true;

                    TBoxStudygroup.IsEnabled = true;
                    CBoxSequencenumber.IsEnabled = true;
                }

                Weekday selected = DGridWeekdays.SelectedItem as Weekday;

                LoadScheduleStandartData(selected);

                DGridSchedulestandarts.Items.Refresh();
            }
        }

        private void TBoxStudygroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (DGridWeekdays.SelectedItem != null)
            {
                LoadScheduleStandartFilteredData(DGridWeekdays.SelectedItem as Weekday);

                RefreshData(TControlMain.SelectedItem as TabItem);
            }
        }

        private void CBoxSequencenumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (DGridWeekdays.SelectedItem != null)
            {
                LoadScheduleStandartFilteredData(DGridWeekdays.SelectedItem as Weekday);

                RefreshData(TControlMain.SelectedItem as TabItem);
            }
        }

        private void DGridSchedulecurrents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (DGridSchedulecurrents.SelectedItem != null)
            {
                if (!isPrintEnabled)
                {
                    isPrintEnabled = true;

                    ButtonPrint.IsEnabled = true;
                }

                Schedulecurrent selected = DGridSchedulecurrents.SelectedItem as Schedulecurrent;

                DGridScheduleChangesSelected.ItemsSource = App.DbSchedule.Schedulechangeds
                    .Where(s => s.Schedulecurrent == selected.Id)
                    .Include(s => s.CabinetNavigation)
                    .Include(s => s.StudygroupNavigation)
                    .Include(s => s.SubjectNavigation)
                    .Include(s => s.TeacherNavigation)
                    .ToList();

                DGridScheduleChangesSelected.Items.Refresh();
            }
        }

        private void DGridSchedulecurrentsToChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!App.CanConnect)
            {
                BlockInterface(true);
                return;
            }

            if (DGridSchedulecurrentsToChange.SelectedItem != null)
            {
                if (!isSchedulechangesActionsEnabled)
                {
                    isSchedulechangesActionsEnabled = true;

                    ButtonAddSchedulechange.IsEnabled = true;
                    ButtonRemoveSchedulechange.IsEnabled = true;
                    ButtonEditSchedulechange.IsEnabled = true;
                }

                Schedulecurrent selected = DGridSchedulecurrentsToChange.SelectedItem as Schedulecurrent;

                DGridScheduleChanges.ItemsSource = App.DbSchedule.Schedulechangeds
                    .Where(s => s.Schedulecurrent == selected.Id)
                    .Include(s => s.CabinetNavigation)
                    .Include(s => s.StudygroupNavigation)
                    .Include(s => s.SubjectNavigation)
                    .Include(s => s.TeacherNavigation)
                    .ToList();

                DGridScheduleChanges.Items.Refresh();
            }
        }

        private void ButtonTryConnect_Click(object sender, RoutedEventArgs e)
        {
            if (App.CanConnect)
            {
                BlockInterface(false);
            }
            else
                MessageBox.Show("Неудача\nПопробуйте позже");
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            /*SaveFileDialog fd = new SaveFileDialog()
            {
                DefaultExt = "docx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Сохранить расписание",
                Filter = "Документ Word (*.docx)|*.docx",
                FilterIndex = 0,
            };
            if ((bool)fd.ShowDialog())
                MakeDocument(fd.FileName);*/

            MessageBox.Show("Данная функция доступна по подписке.\nДля оформления переведите 500 рублей куда нибуть","Деньги закончились",MessageBoxButton.OK,MessageBoxImage.Hand);
        }

        void RefreshData(TabItem? selected)
        {
            if (selected != null)
            {
                switch (selected.Tag as string) 
                {
                    case "Печать":
                        object selectedCurrent = DGridSchedulecurrents.SelectedItem;

                        if (selectedCurrent != null)
                        {
                            DGridScheduleChangesSelected.ItemsSource = App.DbSchedule.Schedulechangeds
                                .Where(s => s.Schedulecurrent == (selectedCurrent as Schedulecurrent).Id)
                                .Include(s => s.CabinetNavigation)
                                .Include(s => s.StudygroupNavigation)
                                .Include(s => s.SubjectNavigation)
                                .Include(s => s.TeacherNavigation)
                                .ToList();
                        }
                        else
                            DGridScheduleChangesSelected.ItemsSource = null;

                        DGridScheduleChangesSelected.Items.Refresh();

                        DGridSchedulecurrents.ItemsSource = App.DbSchedule.Schedulecurrents
                            .Include(s => s.WeekdayNavigation)
                            .ToList();

                        DGridSchedulecurrents.Items.Refresh();
                        break;
                    case "Изменения":
                        object selectedCurrentToChange = DGridSchedulecurrentsToChange.SelectedItem;

                        if (selectedCurrentToChange != null)
                        {
                            DGridScheduleChanges.ItemsSource = App.DbSchedule.Schedulechangeds
                                .Where(s => s.Schedulecurrent == (selectedCurrentToChange as Schedulecurrent).Id)
                                .Include(s => s.CabinetNavigation)
                                .Include(s => s.StudygroupNavigation)
                                .Include(s => s.SubjectNavigation)
                                .Include(s => s.TeacherNavigation)
                                .ToList();
                        }
                        else
                            DGridScheduleChanges.ItemsSource = null;

                        DGridScheduleChanges.Items.Refresh();

                        DGridSchedulecurrentsToChange.ItemsSource = App.DbSchedule.Schedulecurrents
                            .Include(s => s.WeekdayNavigation)
                            .ToList();

                        DGridSchedulecurrentsToChange.Items.Refresh();
                        break;
                    case "Стандартное":
                        object selectedWeekday = DGridWeekdays.SelectedItem;

                        if (selectedWeekday != null)
                        {
                            LoadScheduleStandartFilteredData(selectedWeekday as Weekday);
                        }
                        else
                            DGridSchedulestandarts.ItemsSource = null;

                        DGridSchedulestandarts.Items.Refresh();

                        DGridWeekdays.ItemsSource = App.DbSchedule.Weekdays.ToList();
                        DGridWeekdays.Items.Refresh();
                        break;
                    case "Кабинеты":
                        DGridCabinets.ItemsSource = App.DbSchedule.Cabinets.ToList();
                        DGridCabinets.Items.Refresh();
                        break;
                    case "Преподаватели":
                        DGridTeachers.ItemsSource = App.DbSchedule.Teachers.ToList();
                        DGridTeachers.Items.Refresh();
                        break;
                    case "Группы":
                        DGridStudyGroups.ItemsSource = App.DbSchedule.Studygroups.ToList();
                        DGridStudyGroups.Items.Refresh();
                        break;
                    case "Дисциплины":
                        DGridSubjects.ItemsSource = App.DbSchedule.Subjects.ToList();
                        DGridSubjects.Items.Refresh();
                        break;
                }
            }
        }

        void AddItem()
        {
            string currentTab = (TControlMain.SelectedItem as TabItem).Tag as string;

            switch (currentTab)
            {
                case "Печать":
                    ScheduleCurrentWindow scw = new ScheduleCurrentWindow();

                    scw.ShowDialog();

                    if (scw.isApply)
                        App.DbSchedule.Schedulecurrents.Add(scw.currentSchedulecurrent);

                    break;
                case "Изменения":
                    ScheduleChangeWindow schw = new ScheduleChangeWindow();

                    schw.ShowDialog();

                    schw.currentSchedulechanged.SchedulecurrentNavigation = DGridSchedulecurrentsToChange.SelectedItem as Schedulecurrent;

                    if (schw.isApply)
                        App.DbSchedule.Schedulechangeds.Add(schw.currentSchedulechanged);

                    break;
                case "Стандартное":
                    ScheduleStandartWindow ssw = new ScheduleStandartWindow();

                    ssw.ShowDialog();

                    ssw.currentSchedulestandart.WeekdayNavigation = DGridWeekdays.SelectedItem as Weekday;

                    if (ssw.isApply)
                        App.DbSchedule.Schedulestandarts.Add(ssw.currentSchedulestandart);

                    break;
                case "Кабинеты":
                    CabinetWindow cw = new CabinetWindow();

                    cw.ShowDialog();

                    if (cw.isApply)
                        App.DbSchedule.Cabinets.Add(cw.currentCabinet);

                    break;
                case "Преподаватели":
                    TeacherWindow tw = new TeacherWindow();

                    tw.ShowDialog();

                    if (tw.isApply)
                        App.DbSchedule.Teachers.Add(tw.currentTeacher);

                    break;
                case "Группы":
                    StudyGroupWindow sgw = new StudyGroupWindow();

                    sgw.ShowDialog();

                    if (sgw.isApply)
                        App.DbSchedule.Studygroups.Add(sgw.currentGroup);

                    break;
                case "Дисциплины":
                    SubjectWindow sw = new SubjectWindow();

                    sw.ShowDialog();

                    if (sw.isApply)
                        App.DbSchedule.Subjects.Add(sw.currentSubject);

                    break;
            }

            App.DbSchedule.SaveChanges();
        }

        void RemoveItem()
        {
            string currentTab = (TControlMain.SelectedItem as TabItem).Tag as string;
            Object selected;

            switch (currentTab)
            {
                case "Печать":
                    selected = DGridSchedulecurrents.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Schedulecurrents.Remove(selected as Schedulecurrent);
                    else
                        MessageBox.Show("Выберите расписание!");

                    break;
                case "Изменения":
                    selected = DGridScheduleChanges.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Schedulechangeds.Remove(selected as Schedulechanged);
                    else
                        MessageBox.Show("Выберите изменение!");

                    break;
                case "Стандартное":
                    selected = DGridSchedulestandarts.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Schedulestandarts.Remove(selected as Schedulestandart);
                    else
                        MessageBox.Show("Выберите расписание!");

                    break;
                case "Кабинеты":
                    selected = DGridCabinets.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Cabinets.Remove(selected as Cabinet);
                    else
                        MessageBox.Show("Выберите кабинет!");

                    break;
                case "Преподаватели":
                    selected = DGridTeachers.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Teachers.Remove(selected as Teacher);
                    else
                        MessageBox.Show("Выберите преподавателя!");

                    break;
                case "Группы":
                    selected = DGridStudyGroups.SelectedItem;

                    if (selected != null)
                        App.DbSchedule.Studygroups.Remove(selected as Studygroup);
                    else
                        MessageBox.Show("Выберите группу!");

                    break;
                case "Дисциплины":
                    selected = DGridSubjects.SelectedItem;
                    
                    if (selected != null)
                        App.DbSchedule.Subjects.Remove(selected as Subject);
                    else 
                        MessageBox.Show("Выберите дисциплину!");

                    break;
                
            }

            App.DbSchedule.SaveChanges();
        }

        void EditItem()
        {
            string currentTab = (TControlMain.SelectedItem as TabItem).Tag as string;
            object selected;

            switch (currentTab)
            {
                case "Печать":
                    selected = DGridSchedulecurrents.SelectedItem;

                    if (selected != null)
                    {
                        ScheduleCurrentWindow scw = new ScheduleCurrentWindow(selected as Schedulecurrent);

                        scw.ShowDialog();

                        if (scw.isApply)
                            DGridSchedulecurrents.SelectedItem = scw.currentSchedulecurrent;
                    }
                    else
                        MessageBox.Show("Выберите расписание!");

                    break;
                case "Изменения":
                    selected = DGridScheduleChanges.SelectedItem;

                    if (selected != null)
                    {
                        ScheduleChangeWindow schw = new ScheduleChangeWindow(selected as Schedulechanged);

                        schw.ShowDialog();

                        if (schw.isApply)
                            DGridScheduleChanges.SelectedItem = schw.currentSchedulechanged;
                    }
                    else
                        MessageBox.Show("Выберите изменение!");

                    break;
                case "Стандартное":
                    selected = DGridSchedulestandarts.SelectedItem;

                    if (selected != null)
                    {
                        ScheduleStandartWindow ssw = new ScheduleStandartWindow(selected as Schedulestandart);

                        ssw.ShowDialog();

                        if (ssw.isApply)
                            DGridSchedulestandarts.SelectedItem = ssw.currentSchedulestandart;
                    }
                    else
                        MessageBox.Show("Выберите расписание!");

                    break;
                case "Кабинеты":
                    selected = DGridCabinets.SelectedItem;

                    if (selected != null)
                    {
                        CabinetWindow cw = new CabinetWindow(selected as Cabinet);

                        cw.ShowDialog();

                        if (cw.isApply)
                            DGridCabinets.SelectedItem = cw.currentCabinet;
                    }
                    else
                        MessageBox.Show("Выберите кабинет!");

                    break;
                case "Преподаватели":
                    selected = DGridTeachers.SelectedItem;

                    if (selected != null)
                    {
                        TeacherWindow tw = new TeacherWindow(selected as Teacher);

                        tw.ShowDialog();

                        if (tw.isApply)
                            DGridTeachers.SelectedItem = tw.currentTeacher;
                    }
                    else
                        MessageBox.Show("Выберите преподавателя!");

                    break;
                case "Группы":
                    selected = DGridStudyGroups.SelectedItem;

                    if (selected != null)
                    {
                        StudyGroupWindow sw = new StudyGroupWindow(selected as Studygroup);

                        sw.ShowDialog();

                        if (sw.isApply)
                            DGridStudyGroups.SelectedItem = sw.currentGroup;
                    }
                    else
                        MessageBox.Show("Выберите группу!");

                    break;
                case "Дисциплины":
                    selected = DGridSubjects.SelectedItem;

                    if (selected != null)
                    {
                        SubjectWindow sw = new SubjectWindow(selected as Subject);

                        sw.ShowDialog();

                        if (sw.isApply)
                            DGridSubjects.SelectedItem = sw.currentSubject;
                    }
                    else
                        MessageBox.Show("Выберите дисциплину!");

                    break;
            }

            App.DbSchedule.SaveChanges();
        }

        void LoadScheduleStandartData(Weekday selectedWeekday)
        {
            DGridSchedulestandarts.ItemsSource = App.DbSchedule.Schedulestandarts
                .Where(s => s.Weekday == selectedWeekday.Id)
                .Include(s => s.CabinetNavigation)
                .Include(s => s.StudygroupNavigation)
                .Include(s => s.SubjectNavigation)
                .Include(s => s.TeacherNavigation)
                .ToList();
        }

        void LoadScheduleStandartFilteredData(Weekday selectedWeekday)
        {
            if (string.IsNullOrWhiteSpace(TBoxStudygroup.Text))
            {
                if (DGridWeekdays.SelectedItem != null)
                {
                    Weekday selected = DGridWeekdays.SelectedItem as Weekday;

                    if ((CBoxSequencenumber.SelectedItem as ComboBoxItem).Tag.ToString().Equals("Все"))
                        LoadScheduleStandartData(selected);
                    else
                    {
                        DGridSchedulestandarts.ItemsSource = App.DbSchedule.Schedulestandarts
                            .Where(s => s.Weekday == selectedWeekday.Id)
                            .Where(s => s.Sequencenumber == Convert.ToInt32((CBoxSequencenumber.SelectedItem as ComboBoxItem).Tag))
                            .Include(s => s.CabinetNavigation)
                            .Include(s => s.StudygroupNavigation)
                            .Include(s => s.SubjectNavigation)
                            .Include(s => s.TeacherNavigation)
                            .ToList();
                    }
                }
            }
            else
            {
                if (DGridWeekdays.SelectedItem != null)
                {
                    Weekday selected = DGridWeekdays.SelectedItem as Weekday;

                    if ((CBoxSequencenumber.SelectedItem as ComboBoxItem).Tag.ToString().Equals("Все"))
                    {
                        DGridSchedulestandarts.ItemsSource = App.DbSchedule.Schedulestandarts
                            .Where(s => s.Weekday == selectedWeekday.Id)
                            .Where(s => s.StudygroupNavigation.Name.ToLower().Contains(TBoxStudygroup.Text.ToLower()))
                            .Include(s => s.CabinetNavigation)
                            .Include(s => s.StudygroupNavigation)
                            .Include(s => s.SubjectNavigation)
                            .Include(s => s.TeacherNavigation)
                            .ToList();
                    }
                    else
                    {
                        DGridSchedulestandarts.ItemsSource = App.DbSchedule.Schedulestandarts
                            .Where(s => s.Weekday == selectedWeekday.Id)
                            .Where(s => s.Sequencenumber == Convert.ToInt32((CBoxSequencenumber.SelectedItem as ComboBoxItem).Tag))
                            .Where(s => s.StudygroupNavigation.Name.ToLower().Contains(TBoxStudygroup.Text.ToLower()))
                            .Include(s => s.CabinetNavigation)
                            .Include(s => s.StudygroupNavigation)
                            .Include(s => s.SubjectNavigation)
                            .Include(s => s.TeacherNavigation)
                            .ToList();
                    }
                }
            }
        }

        void BlockInterface(bool isBlock)
        {
            if (isBlock)
            {
                TControlMain.IsEnabled = false;

                TControlMainBlurEffect.Radius = 6;

                GridBlocked.Visibility = Visibility.Visible;
            }
            else
            {
                TControlMain.IsEnabled = true;

                TControlMainBlurEffect.Radius = 0;

                RefreshData(TControlMain.SelectedItem as TabItem);

                GridBlocked.Visibility = Visibility.Collapsed;
            }
        }

        void MakeDocument(string path)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new Document();

                Run run = mainPart.Document
                    .AppendChild(new Body())
                    .AppendChild(new Paragraph())
                    .AppendChild(new Run());

                run.AppendChild(TableGenerator.Generate());

                run.AppendChild(new Text("Зам. Директора по УР___________О.А.Кузниченко"));
                wordDocument.Save();
            }

            if (File.Exists(path))
                Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
            else
                MessageBox.Show("Ошибка создания документа");
        }
    }
}