using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input = "";
        bool is_print_result = false;
        public MainWindowViewModel()
        {
            ChangeInput = ReactiveCommand.Create((string x) => {
                if (is_print_result)
                {
                    Input = "";
                }

                is_print_result = false;

                return Input += x;
            });

            Calculate = ReactiveCommand.Create(() => {
                try
                {
                    is_print_result = true;
                    Input = RomanNumberCalculator.Calculate(input).ToString();
                }
                catch (Exception ex)
                {
                    Input = "ERROR";
                }
            });
        }
        public string Input
        {
            set
            {
                this.RaiseAndSetIfChanged(ref input, value);
            }

            get
            {
                return this.input;
            }
        }
        public ReactiveCommand<string, string> ChangeInput { get; }
        public ReactiveCommand<Unit, Unit> Calculate { get; }
    }
}
