using Avalonia.Controls;
using lab_8.Models;

namespace lab_8.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* создание новой доски*/
            this.FindControl<MenuItem>("NewKanbanBoard").Click += delegate
            {
                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; // получаем все данные с доски
                context.clear();                                                        // очистка доски
            };

            /* сохранение текущей доски в файл*/
            this.FindControl<MenuItem>("SaveKanbanBoard").Click += async delegate
            {
                var dialog_window = new SaveFileDialog().ShowAsync(this.VisualRoot as MainWindow);  // окно сохранения в файл
                
                string path = await dialog_window;  // выбор пути для сохранения

                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; // получаем все данные с доски
                
                if (path != null)
                {
                    context.saveBoardInFile(path);
                }
            };

            /* загрузка доски из файла */
            this.FindControl<MenuItem>("LoadKanbanBoard").Click += async delegate
            {
                var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  // окно загрузки из файла

                string[] path = await dialog_window;        // выбор пути откуда загружать

                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; // получаем все данные с доски
                
                if (path != null)
                {
                    context.loadBoardFromFile(path[0]);
                }
            };

            /* выход из программы */
            this.FindControl<MenuItem>("ExitKanbanBoard").Click += delegate
            {
                this.Close();
            };

            /* об авторе */
            this.FindControl<MenuItem>("WhoDone").Click += async delegate
            {
                await new AboutWindow().ShowDialog(this.VisualRoot as MainWindow);
            };
        }

        /* процедура добавления картинки */
        public async void addImage(Task task)
        {
            var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  // окно выбора картинки
            
            var path = await dialog_window; // выбор пути откуда загружать

            if (path != null)
            {
                task.setImage(path[0]);
            }
        }
    }
}
