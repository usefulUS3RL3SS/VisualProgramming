using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using lab_8.Models;
using ReactiveUI;
using System.IO;

namespace lab_8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /* ���������� */
        ObservableCollection<Task> planned;     // ��������������� ������
        ObservableCollection<Task> at_work;     // ������� ������
        ObservableCollection<Task> done;        // ����������� ������

        /* ����������� */
        public MainWindowViewModel()
        {
            Planned = new ObservableCollection<Task>();     // ������������� ������ ��������������� �����
            AtWork = new ObservableCollection<Task>();      // ������������� ������ ������� �����
            Done = new ObservableCollection<Task>();        // ������������� ������ ����������� �����
        }

        /* ���������� ��� ��������� ��������������� ����� - ��������� � ��������� */
        public ObservableCollection<Task> Planned
        {
            set => this.RaiseAndSetIfChanged(ref planned, value);   // ���������

            get => planned;                                         // ���������
        }

        /* ���������� ��� ��������� ������� ����� - ��������� � ��������� */
        public ObservableCollection<Task> AtWork
        {
            set => this.RaiseAndSetIfChanged(ref at_work, value);   // ���������

            get => at_work;                                         // ���������
        }

        /* ���������� ��� ��������� ����������� ����� - ��������� � ��������� */
        public ObservableCollection<Task> Done
        {
            set => this.RaiseAndSetIfChanged(ref done, value);      // ���������

            get => done;                                         // ���������
        }

        /* ��������� ������� Kanban Board */
        public void clear()
        {
            Planned.Clear();    // ������ ��������� ��������������� �����
            AtWork.Clear();     // ������ ��������� ������� �����
            Done.Clear();       // ������ ��������� ����������� �����
        }

        /* ��������� ���������� ����� � ���� */
        public void saveBoardInFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                /* ������ ��������������� ����� */
                sw.WriteLine(Planned.Count);            // ���������� �����
                foreach (var task in Planned)           // ���������� �� ���� ��������������� �������
                {
                    sw.WriteLine(task.Header);                  // ���������� ��������� ������
                    sw.WriteLine(task.Description);             // ���������� �������� ������
                    sw.WriteLine(task.Path);                    // ���� � �������� (���� ��� ����)
                }

                /* ������ ������� ����� */
                sw.WriteLine(AtWork.Count);             // ���������� �����
                foreach (var task in AtWork)            // ���������� �� ���� ��������������� �������
                {
                    sw.WriteLine(task.Header);                  // ���������� ��������� ������
                    sw.WriteLine(task.Description);             // ���������� �������� ������
                    sw.WriteLine(task.Path);                    // ���� � �������� (���� ��� ����)
                }

                /* ������ ����������� ����� */
                sw.WriteLine(Done.Count);             // ���������� �����
                foreach (var task in Done)            // ���������� �� ���� ��������������� �������
                {
                    sw.WriteLine(task.Header);                  // ���������� ��������� ������
                    sw.WriteLine(task.Description);             // ���������� �������� ������
                    sw.WriteLine(task.Path);                    // ���� � �������� (���� ��� ����)
                }
            }
        }

        /* ��������� �������� ����� �� ����� */
        public void loadBoardFromFile(string path)
        {
            if (!File.Exists(path))         // ����� ���� ���������������� ���� ��� ������ 0 �����
            {
                return;
            }

            clear();                        // ������� �����

            using (StreamReader sr = File.OpenText(path))
            {
                /* �������� ��������������� ����� */
                var planned_count = int.Parse(sr.ReadLine());   // ���������� ��������������� �����
                for (int i = 0; i < planned_count; ++i)
                {
                    var header = sr.ReadLine();                 // ��������� ���������
                    var description = sr.ReadLine();            // ��������� ��������
                    var img_path = sr.ReadLine();               // ��������� ���� � ��������

                    var item = new Task();                      // ������� ����� ������ ������

                    item.Header = header;                       // ������ ���������
                    item.Description = description;             // ������ ��������
                    item.setImage(img_path);                    // ������������� ��������

                    Planned.Add(item);                          // ��������� ������ � ��������� ���������������
                }

                /* �������� ������� ����� */
                var at_work_count = int.Parse(sr.ReadLine());   // ���������� ��������������� �����
                for (int i = 0; i < at_work_count; ++i)
                {
                    var header = sr.ReadLine();                 // ��������� ���������
                    var description = sr.ReadLine();            // ��������� ��������
                    var img_path = sr.ReadLine();               // ��������� ���� � ��������

                    var item = new Task();                      // ������� ����� ������ ������

                    item.Header = header;                       // ������ ���������
                    item.Description = description;             // ������ ��������
                    item.setImage(img_path);                    // ������������� ��������

                    AtWork.Add(item);                           // ��������� ������ � ��������� ���������������
                }

                /* �������� ����������� ����� */
                var done_count = int.Parse(sr.ReadLine());      // ���������� ��������������� �����
                for (int i = 0; i < done_count; ++i)
                {
                    var header = sr.ReadLine();                 // ��������� ���������
                    var description = sr.ReadLine();            // ��������� ��������
                    var img_path = sr.ReadLine();               // ��������� ���� � ��������

                    var item = new Task();                      // ������� ����� ������ ������

                    item.Header = header;                       // ������ ���������
                    item.Description = description;             // ������ ��������
                    item.setImage(img_path);                    // ������������� ��������

                    Done.Add(item);                             // ��������� ������ � ��������� ���������������
                }
            }
        }

        /* ��������� �������� ����� ��������������� ������ */
        public void addPlannedTask()
        {
            Planned.Add(new Task());
        }

        /* ��������� �������� ����� ������� ������ */
        public void addAtWorkTask()
        {
            AtWork.Add(new Task());
        }

        /* ��������� �������� ����� ����������� ������ */
        public void addDoneTask()
        {
            Done.Add(new Task());
        }

        /* ��������� �������� ��������������� ������ */
        public void deletePlannedTask(Task task)
        {
            Planned.Remove(task);
        }

        /* ��������� �������� ������� ������ */
        public void deleteAtWorkTask(Task task)
        {
            AtWork.Remove(task);
        }

        /* ��������� �������� ����������� ������ */
        public void deleteDoneTask(Task task)
        {
            Done.Remove(task);
        }
    }
}
