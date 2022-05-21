using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public ushort UshortValue() => this.arabic_value;
        public RomanNumberExtend(string number) : base(convert_roman_to_arabic(number)) { }
        public RomanNumberExtend(ushort n) : base(n) { }
        private static ushort convert_symbol_to_arabic_value(char symbol)
        {
            if (symbol == 'I')
            {
                return 1;
            }
                
            if (symbol == 'V')
            {
                return 5;
            }
                
            if (symbol == 'X')
            {
                return 10;
            }
                
            if (symbol == 'L')
            {
                return 50;
            }
                
            if (symbol == 'C')
            {
                return 100;
            }
                
            if (symbol == 'D')
            {
                return 500;
            }
                
            if (symbol == 'M')
            {
                return 1000;
            }
                
            throw new RomanNumberException();
        }

        private static ushort convert_roman_to_arabic(string number)
        {
            ushort result = 0;
            for (int i = 0; i < number.Length; ++i)
            {
                ushort num_1 = convert_symbol_to_arabic_value(number[i]);
                if (i + 1 < number.Length)
                {
                    ushort num_2 = convert_symbol_to_arabic_value(number[i + 1]);
                    if (num_1 >= num_2)
                    {
                        result = (ushort)(result + num_1);
                    }
                    else
                    {
                        result = (ushort)(result - num_1);
                    }
                }

                else
                {
                    result = (ushort)(result + num_1);
                }
            }

            return result;
        }
    }
}
