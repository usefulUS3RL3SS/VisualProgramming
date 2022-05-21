using System;

public class RomanNumber : ICloneable, IComparable
{
    private ushort arabic_value;
    private string roman_value;

    /* Функция конвертации из арабской СС в римскую СС */
    private string convert_arabic_to_roman(ushort n)
    {
        ushort[] roman_numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] arabic_numbers = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        string result = "";

        int i = 0;

        while (n > 0)
        {
            if (roman_numbers[i] <= n)
            {
                n -= roman_numbers[i];
                result += arabic_numbers[i];
            }
            else
            {
                i++;
            }

        }

        return result;
    }

    /* Конструктор получает число n, которое должен представлять объект класса */
    public RomanNumber(ushort n)
    {
        if (n <= 0)
        {
            throw new RomanNumberException();
        }

        arabic_value = n;
        roman_value = convert_arabic_to_roman(n);
    }

    /* Сложение */
    public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1.arabic_value == 0 || n2.arabic_value == 0)
        {
            throw new ArgumentNullException();
        }

        ushort result = (ushort)(n1.arabic_value + n2.arabic_value);

        return new RomanNumber(result);
    }

    /* Вычитание */
    public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null)
        {
            throw new ArgumentNullException();
        }

        if (n1.arabic_value <= n2.arabic_value)
        {
            throw new RomanNumberException();
        }

        ushort result = (ushort)(n1.arabic_value - n2.arabic_value);

        return new RomanNumber(result);
    }

    /* Умножение */
    public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1.arabic_value == 0 || n2.arabic_value == 0)
        {
            throw new ArgumentNullException();
        }

        ushort result = (ushort)(n1.arabic_value * n2.arabic_value);

        return new RomanNumber(result);
    }

    /* Целочисленное деление */
    public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1.arabic_value == 0 || n2.arabic_value == 0)
        {
            throw new ArgumentNullException();
        }
        
        if (n2.arabic_value == 0)
        {
            throw new RomanNumberException();
        }

        if ((ushort)(n1.arabic_value / n2.arabic_value) == 0)
        {
            throw new RomanNumberException();
        }

        ushort result = (ushort)(n1.arabic_value / n2.arabic_value);

        return new RomanNumber(result);
    }

    /* Возвращает строковое представление римского числа */
    public override string ToString()
    {
        return roman_value;
    }

    /* Реализация интерфейса IClonable */
    public object Clone()
    {
        return new RomanNumber(arabic_value);
    }

    /* Реализация интерфейса IComparable */
    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }

        RomanNumber obj_dif = obj as RomanNumber;

        return arabic_value.CompareTo(obj_dif.arabic_value);
    }
}