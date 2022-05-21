using System;

internal class RomanNumberException : Exception
{
    public RomanNumberException() : base() { }
    public RomanNumberException(string message) : base(message) { }
}