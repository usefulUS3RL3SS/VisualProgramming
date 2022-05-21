using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab_7.Models
{
    public class Mark : ReactiveObject
    {
        /* компоненты */
        ISolidColorBrush color;     // цвет ячейки
        string mark;                // оценка

        /* конструктор оценки */
        public Mark(string name_subject)
        {
            Value = "0";
            Name_subject = name_subject;
        }

        /* установка, получение цвета ячейки */
        public ISolidColorBrush Color
        {
            set => this.RaiseAndSetIfChanged(ref color, value);

            get => color;
        }

        /* установка, получение имени студента */
        public string Name_subject
        {
            set;

            get;
        }

        /*установка и получение оценки */
        public string Value
        {
            get => mark;

            set
            {
                try
                {
                    int value_mark = int.Parse(value);      // получаем int значение оценки

                    if (value_mark < 0 || value_mark > 2)   // когда оценка за КС не валидна
                    {
                        value = "#ERROR";
                        Color = Brushes.White;
                    }
                    else                                    // когда оценка за КС валидна
                    {
                        if (value_mark == 0)                // КС = 0
                        {
                            Color = Brushes.Red;
                        }
                        else if (value_mark == 1)           // КС = 1
                        {
                            Color = Brushes.Yellow;
                        }
                        else                                // КС = 2 
                        {
                            Color = Brushes.Green;
                        }
                    }
                }
                catch (FormatException e)
                {
                    value = "#ERROR";
                }

                this.RaiseAndSetIfChanged(ref mark, value);
            }
        }
    }
}
