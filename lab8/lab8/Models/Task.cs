using ReactiveUI;
using Avalonia.Media.Imaging;
using System.IO;

namespace lab_8.Models
{
    public class Task : ReactiveObject
    {
        /* компоненты */
        string header;          // заглавие задачи
        string? description;    // описание задачи
        Bitmap? image;          // картинка
        bool is_selected;       // выбранная задача


        /* конструктор */
        public Task()
        {
            header = "New Task";            // заглавие задачи (по умолчанию установлено "New Task")
            Description = "";               // описание (пустое поле)
            Path = "";                      // путь к картинке (пустое поле)
        }

        /* обработчик для заглавия - получение и установка */
        public string Header
        {
            set => this.RaiseAndSetIfChanged(ref header, value);    // установка нового заглавия

            get => header;                                          // получение заголовка
        }

        /* обработчик для описания - получение и установка */
        public string Description
        {
            set => this.RaiseAndSetIfChanged(ref description, value);   // установка нового описания

            get => description;                                         // получение описания
        }

        /* обработчик для картинке - получение и установка */
        public Bitmap? Image
        {
            set => this.RaiseAndSetIfChanged(ref image, value);         // установка новой картинки

            get => image;                                               // получение картинки
        }

        public string Path
        {
            set;        // установка

            get;        // получение
        }

        /* обработчик для выбранной задачи - получение сосотояния и установка нового */
        public bool IsSelected
        {
            set => this.RaiseAndSetIfChanged(ref is_selected, value);   // установка нового значения состояния

            get => is_selected;                                         // получение значения состояния о "выборе задачи"
        }

        /* процедура установки картинки из файла */
        public void setImage(string path)
        {
            if (!File.Exists(path))         // выход если недействительный путь или строка 0 длины
            {
                return;
            }

            Path = path;                    // сохраняем путь
            Image = new Bitmap(path);       // создаем картинку
        }
    }
}
