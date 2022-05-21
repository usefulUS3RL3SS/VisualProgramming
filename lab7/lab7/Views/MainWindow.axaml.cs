using Avalonia.Controls;
using lab_7.ViewModels;

namespace lab_7.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* ���������� � ���� */
            this.FindControl<MenuItem>("SaveBtn").Click += async delegate
            {
                var svf = new SaveFileDialog()
                {
                    Title = "Save file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;

                string? path = await svf;

                if (path != null)
                {
                    context.save_file(path);
                }
            };

            /* �������� �� ����� */
            this.FindControl<MenuItem>("OpenBtn").Click += async delegate
            {
                var svf = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;

                string[]? path = await svf;

                if (path != null)
                {
                    context.load_file(path[0]);
                }
            };


            /* ������ About */
            this.FindControl<MenuItem>("AboutBtn").Click += async delegate
            {
                var svf = new AboutWindow();

                await svf.ShowDialog((Window)this.VisualRoot);
            };

            /* ����� */
            this.Find<MenuItem>("ExitBtn").Click += delegate
            {
                Close();
            };
        }
    }
}
