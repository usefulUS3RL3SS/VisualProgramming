using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AvaloniaApplication1.ViewModels
{
    public static class RomanNumberCalculator
    {
        private static string[] separate_input(string input)
        {
            char[] separators = { '+', '-', '*', '/' };
            return input.Split(separators);
        }
        public static Models.RomanNumberExtend Calculate(string input)
        {
            var splitted_input_by_operands = Regex.Split(input, @"([*()\/]|(?<!E)[\+\-])");

            string output = "";

            foreach (var element in splitted_input_by_operands)
            {
                if (element != "+" && element != "-" && element != "*" && element != "/")
                {
                    output += (new Models.RomanNumberExtend(element)).UshortValue().ToString();
                }
                else
                {
                    output += element;
                }

            }

            DataTable dt = new DataTable();

            return new Models.RomanNumberExtend(Convert.ToUInt16(dt.Compute(output, "")));
        }
    }
}
