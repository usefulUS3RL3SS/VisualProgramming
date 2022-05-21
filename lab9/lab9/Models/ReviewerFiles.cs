using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Models
{
    public class ReviewerFiles : ReactiveObject
    {
        /* компоненты */
        ObservableCollection<ReviewerFiles>? files;     // коллекция с файлами
        public bool is_directory;                       // активна ли директория

        /* конструктор */
        public ReviewerFiles(string path)
        {
            files = null;
            this.Path = path;
            var file = new FileInfo(path);
            is_directory = file.Attributes.HasFlag(FileAttributes.Directory);

            if (file.Name.Length == 0)
            {
                TitlePath = path;
            }
            else
            {
                TitlePath = file.Name;
            }
        }

        public ObservableCollection<ReviewerFiles>? Files
        {
            get
            {
                if (files == null && is_directory)      // если коллекция с файлами пустая и активна новая директория 
                {
                    files = new ObservableCollection<ReviewerFiles>(); // создаем новую коллекцию для директории

                    string[] current_path;

                    try
                    {
                        current_path = Directory.GetDirectories(Path);  // получаем все файлы директории

                        foreach (string file in current_path)           // проходимся по всем файлам
                        {
                            files.Add(new ReviewerFiles(file));         // добавляем в коллекцию
                        }
                    }
                    catch (UnauthorizedAccessException) { }

                    try
                    {
                        current_path = Directory.GetFiles(Path);        // получаем информацию о файле

                        foreach (string file in current_path)
                        {
                            FileInfo file_info = new FileInfo(file);
                            string extension = file_info.Extension; // расширение файлов

                            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")  // отбор картинок
                            {
                                files.Add(new ReviewerFiles(file));     // добавляем
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                }

                return files;
            }
        }

        /* обработчик заголовков пути файлов */
        public string TitlePath
        {
            set;

            get;
        }

        /* обработчик пути до файлов */
        public string Path
        {
            private set;

            get;
        }
    }
}
