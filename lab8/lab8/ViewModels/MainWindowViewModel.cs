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
        /* компоненты */
        ObservableCollection<Task> planned;     // запланированные задачи
        ObservableCollection<Task> at_work;     // текущие задачи
        ObservableCollection<Task> done;        // выполненные задачи

        /* конструктор */
        public MainWindowViewModel()
        {
            Planned = new ObservableCollection<Task>();     // инициализация списка запланированных задач
            AtWork = new ObservableCollection<Task>();      // инициализация списка текущих задач
            Done = new ObservableCollection<Task>();        // инициализация списка выполненных задач
        }

        /* обработчик для коллекции запланированных задач - получение и установка */
        public ObservableCollection<Task> Planned
        {
            set => this.RaiseAndSetIfChanged(ref planned, value);   // установка

            get => planned;                                         // получение
        }

        /* обработчик для коллекции текущих задач - получение и установка */
        public ObservableCollection<Task> AtWork
        {
            set => this.RaiseAndSetIfChanged(ref at_work, value);   // установка

            get => at_work;                                         // получение
        }

        /* обработчик для коллекции выполненных задач - получение и установка */
        public ObservableCollection<Task> Done
        {
            set => this.RaiseAndSetIfChanged(ref done, value);      // установка

            get => done;                                         // получение
        }

        /* процедура очистки Kanban Board */
        public void clear()
        {
            Planned.Clear();    // очиска коллекции запланированных задач
            AtWork.Clear();     // очиска коллекции текущих задач
            Done.Clear();       // очиска коллекции выполненных задач
        }

        /* процедура сохранения доски в файл */
        public void saveBoardInFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                /* запись запланированных задач */
                sw.WriteLine(Planned.Count);            // количество задач
                foreach (var task in Planned)           // проходимся по всем запланированным задачам
                {
                    sw.WriteLine(task.Header);                  // записываем заголовок задачи
                    sw.WriteLine(task.Description);             // записываем описание задачи
                    sw.WriteLine(task.Path);                    // путь к картинке (если она есть)
                }

                /* запись текущих задач */
                sw.WriteLine(AtWork.Count);             // количество задач
                foreach (var task in AtWork)            // проходимся по всем запланированным задачам
                {
                    sw.WriteLine(task.Header);                  // записываем заголовок задачи
                    sw.WriteLine(task.Description);             // записываем описание задачи
                    sw.WriteLine(task.Path);                    // путь к картинке (если она есть)
                }

                /* запись выполненных задач */
                sw.WriteLine(Done.Count);             // количество задач
                foreach (var task in Done)            // проходимся по всем запланированным задачам
                {
                    sw.WriteLine(task.Header);                  // записываем заголовок задачи
                    sw.WriteLine(task.Description);             // записываем описание задачи
                    sw.WriteLine(task.Path);                    // путь к картинке (если она есть)
                }
            }
        }

        /* процедура загрузки доски из файла */
        public void loadBoardFromFile(string path)
        {
            if (!File.Exists(path))         // выход если недействительный путь или строка 0 длины
            {
                return;
            }

            clear();                        // очистка доски

            using (StreamReader sr = File.OpenText(path))
            {
                /* загрузка запланированных задач */
                var planned_count = int.Parse(sr.ReadLine());   // количество запланированных задач
                for (int i = 0; i < planned_count; ++i)
                {
                    var header = sr.ReadLine();                 // считываем заголовок
                    var description = sr.ReadLine();            // считываем описание
                    var img_path = sr.ReadLine();               // считываем путь к картинке

                    var item = new Task();                      // создаем новую пустую задачу

                    item.Header = header;                       // задаем заголовок
                    item.Description = description;             // задаем описание
                    item.setImage(img_path);                    // устанавливаем картинку

                    Planned.Add(item);                          // добавляем задачу в коллекцию запланированных
                }

                /* загрузка текущих задач */
                var at_work_count = int.Parse(sr.ReadLine());   // количество запланированных задач
                for (int i = 0; i < at_work_count; ++i)
                {
                    var header = sr.ReadLine();                 // считываем заголовок
                    var description = sr.ReadLine();            // считываем описание
                    var img_path = sr.ReadLine();               // считываем путь к картинке

                    var item = new Task();                      // создаем новую пустую задачу

                    item.Header = header;                       // задаем заголовок
                    item.Description = description;             // задаем описание
                    item.setImage(img_path);                    // устанавливаем картинку

                    AtWork.Add(item);                           // добавляем задачу в коллекцию запланированных
                }

                /* загрузка выполненных задач */
                var done_count = int.Parse(sr.ReadLine());      // количество запланированных задач
                for (int i = 0; i < done_count; ++i)
                {
                    var header = sr.ReadLine();                 // считываем заголовок
                    var description = sr.ReadLine();            // считываем описание
                    var img_path = sr.ReadLine();               // считываем путь к картинке

                    var item = new Task();                      // создаем новую пустую задачу

                    item.Header = header;                       // задаем заголовок
                    item.Description = description;             // задаем описание
                    item.setImage(img_path);                    // устанавливаем картинку

                    Done.Add(item);                             // добавляем задачу в коллекцию запланированных
                }
            }
        }

        /* процедура создания новой запланированной задачи */
        public void addPlannedTask()
        {
            Planned.Add(new Task());
        }

        /* процедура создания новой текущей задачи */
        public void addAtWorkTask()
        {
            AtWork.Add(new Task());
        }

        /* процедура создания новой выполненной задачи */
        public void addDoneTask()
        {
            Done.Add(new Task());
        }

        /* процедура удаления запланированной задачи */
        public void deletePlannedTask(Task task)
        {
            Planned.Remove(task);
        }

        /* процедура удаления текущей задачи */
        public void deleteAtWorkTask(Task task)
        {
            AtWork.Remove(task);
        }

        /* процедура удаления выполненной задачи */
        public void deleteDoneTask(Task task)
        {
            Done.Remove(task);
        }
    }
}
