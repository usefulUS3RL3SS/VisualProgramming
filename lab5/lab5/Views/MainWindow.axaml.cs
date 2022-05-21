using Avalonia.Controls;
using Avalonia.Interactivity;
using lab_5.ViewModels;

namespace lab_5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFile").Click += async delegate
            {
                var taskPath = new OpenFileDialog().ShowAsync(this);

                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;

                if (path is not null)
                {
                    context.read_file(string.Join("/", path));
                }
            };

            this.FindControl<Button>("SaveFile").Click += async delegate
            {
                var taskPath = new SaveFileDialog().ShowAsync(this);

                string path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;

                if (path is not null)
                {
                    context.save_in_file(path);
                }
            };

        }
        public void ShowRegexWindow(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new RegexWindow();

            dialogWindow.FindControl<TextBox>("RegexInputField").Text = (this.DataContext as MainWindowViewModel).Pattern_Regex;
           
            dialogWindow.ShowDialog(this);
        }
    }
}
