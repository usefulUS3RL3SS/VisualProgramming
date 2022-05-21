using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using lab_5.Models;

namespace lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input = "";
        string output = "";
        string pattern_regex = "";
        RegexFinder finder = new RegexFinder();

        public MainWindowViewModel()
        {

        }

        public string Input
        {
            set
            {
                this.RaiseAndSetIfChanged(ref input, value);
                this.change_output();
            }
            get
            {
                return this.input;
            }
        }

        public string Output
        {
            set
            {
                this.RaiseAndSetIfChanged(ref output, value);
            }
            get
            {
                return this.output;
            }
        }

        public string Pattern_Regex
        {
            set
            {
                this.RaiseAndSetIfChanged(ref pattern_regex, value);
                this.change_output();
            }
            get
            {
                return this.pattern_regex;
            }
        }

        public void change_output()
        {
            string result = "";

            // String outString = "";

            var matches = finder.get_matches(Pattern_Regex, Input);

            foreach (string match in matches)
            {
                if (match.Length > 0)
                    result += match + "\n";
            }

            this.Output = result;
        }

        public void save_in_file(string path)
        {
            var file = new FileController();
            file.write(this.Output, path);
        }

        public void read_file(string path)
        {
            var file = new FileController();
            this.Input = file.read(path);
        }
    }
}
