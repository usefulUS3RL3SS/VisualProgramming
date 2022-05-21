using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab_5.ViewModels;
using System;
using System.Text.RegularExpressions;

namespace lab_5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OK").Click += delegate
            {
                var context = this.Owner.DataContext as MainWindowViewModel;
                var inputField = this.FindControl<TextBox>("RegexInputField");

                try
                {
                    Regex rg = new Regex(inputField.Text);
                    context.Pattern_Regex = inputField.Text;
                    this.CloseWindow();
                }
                catch (Exception ex)
                {
                    inputField.Text = "INVALID REGEX";
                }


            };

            this.FindControl<Button>("Close").Click += delegate
            {
                CloseWindow();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CloseWindow()
        {
            this.Close();
        }
    }
}
