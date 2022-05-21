using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab_7.Models
{
    public class Student : ReactiveObject
    {
        /* компоненты */
        string name;                // имя студента
        ISolidColorBrush color;     // цвет ячейки
        string average_mark;        // средняя оценка

        /* конструктор студента */
        public Student()
        {
            /* ФИО */
            name = "";

            /* лист с оценками за КС */
            Marks = new List<Mark> {
                new Mark("ВПиЧМВ"), 
                new Mark("СГМА"),
                new Mark("Сети ЭВМ"),
                new Mark("ООП")
            };

            /* оценки за КС*/
            for (int i = 0; i < Marks.Count; ++i)
            {
                Marks[i].Changed.Subscribe((x) => calculate());
            }

            calculate();
        }

        public Student(string nam) : this()
        {
            name = nam;
        }

        /* установка, получение имени студента */
        public string Name
        {
            set => name = value;

            get => name;
        }

        /* установка, получение оценок за КС*/
        public List<Mark> Marks
        {
            set;

            get;
        }

        /* установка, получение средней оценки за КС*/
        public string AverageMark
        {
            set => this.RaiseAndSetIfChanged(ref average_mark, value);

            get => average_mark;
        }

        /* установка, получение цвета ячейки */
        public ISolidColorBrush Color
        {
            set => this.RaiseAndSetIfChanged(ref color, value);

            get => color;
        }

        /* подсчёт средней оценки за КС */
        void calculate()
        {
            double result = 0;
            
            try
            {
                /* сумма всех оценок */
                foreach (var mark in Marks)
                {
                    result += int.Parse(mark.Value);
                }
            }
            catch (FormatException e)
            {
                /* если не удалось посчитать */
                AverageMark = "#ERROR";
                Color = Brushes.White;
                return;
            }

            result /= Marks.Count;  // вычисление средней оценки 

            if (result < 1)                         // когда Ср. КС < 1
            {
                Color = Brushes.Red;
            }
            else if (result >= 1 && result < 1.5)   // когда 1 <= Ср. КС < 1.5
            {
                Color = Brushes.Yellow;
            }
            else                                    // когда Ср. КС >= 1.5
            {
                Color = Brushes.Green;
            }

            AverageMark = result.ToString();
        }

        public bool IsChecked
        {
            set;

            get;
        }
    }
}
