using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using lab_6.Models;

namespace lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /* Компоненты */
        bool is_editing_existing = false;                               // -- // --
        string title = "";                                              // заголовок
        string description = "";                                        // описание
        Planner current = null;                                         // текущая запись
        DateTimeOffset date = DateTimeOffset.Now.Date;                  // дата
        private Dictionary<DateTimeOffset, List<Planner>> ListsOnDays;  // список заметок на день
        ViewModelBase content;                                          // контент

        /* Конструктор */
        public MainWindowViewModel()
        {
            this.ListsOnDays = new Dictionary<DateTimeOffset, List<Planner>>();
            this.Items = new ObservableCollection<Planner>();
            this.Content = new PlannerMainWindow();
        }

        /* "Обработчик" контента */
        public ViewModelBase Content
        {
            private set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }

        /* Заголовок заметки */
        public String Title
        {
            set
            {
                this.RaiseAndSetIfChanged(ref title, value);
            }
            get
            { 
                return title;
            }
        }

        /* Описание заметки */
        public String Description
        {
            set
            {
                this.RaiseAndSetIfChanged(ref description, value);
            }

            get 
            {
                return description;
            }
        }

        /* Дата заметки */
        public DateTimeOffset Date
        {
            set
            {
                this.RaiseAndSetIfChanged(ref date, value);
                this.ChangeObservableCollection(this.date);
            }

            get
            {
                return this.date;
            }
        }

        /* Записи в планере */
        public ObservableCollection<Planner> Items
        {
            set;
            get;
        }

        /* Инициализация списка заметок */
        private void InitPlannerList()
        {
            var ListsOnDays = new Dictionary<DateTimeOffset, List<Planner>>();
            ListsOnDays.Add(this.date, new List<Planner>());
            this.ListsOnDays = ListsOnDays;
        }

        /* Добавление новой заметки */
        public void AppendNote(DateTimeOffset date, Planner item)
        {
            if (!this.ListsOnDays.ContainsKey(date))
            {
                this.ListsOnDays.Add(date, new List<Planner>());
            }
            this.ListsOnDays[date].Add(item);
            this.ChangeObservableCollection(this.Date);
        }

        /* Смена окон */
        public void ChangeView()
        {
            if (this.Content is PlannerMainWindow)
            {
                this.Content = new NoteWindow();

            }
            else
            {
                this.Title = "";
                this.Description = "";
                this.current = null;
                this.is_editing_existing = false;
                this.Content = new PlannerMainWindow();
            }
        }

        /* Изменение записей */
        public void ChangeObservableCollection(DateTimeOffset date)
        {
            if (!this.ListsOnDays.ContainsKey(date))
            {
                this.Items.Clear();
            }
            else
            {
                this.Items.Clear();
                foreach (var item in this.ListsOnDays[date])
                {
                    this.Items.Add(item);
                }
            }
        }

        /* Сохранение */
        public void Save()
        {
            if (this.Title != "")
            {
                if (this.is_editing_existing)
                {
                    var item = this.ListsOnDays[date].Find(x => x.Equals(this.current));
                    item.Title = this.Title;
                    item.Description = this.Description;
                    this.is_editing_existing = false;
                }
                else
                {
                    this.AppendNote(this.Date, new Planner(this.Title, this.Description));
                }
                this.ChangeView();
            }
        }

        /* Удаление */
        public void Delete(Planner item)
        {
            this.ListsOnDays[date].Remove(item);
            this.ChangeObservableCollection(date);
        }

        /* Подробнее о заметке */
        public void ViewExisting(Planner item)
        {
            this.is_editing_existing = true;
            this.current = item;
            this.Title = current.Title;
            this.Description = current.Description;
            this.ChangeView();
        }
    }
}
