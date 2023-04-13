using System;

namespace deloitte_feladat
{
    public class WrongInputException : Exception
    {
        public WrongInputException() { }

        public WrongInputException(string message) : base(message) { }
    }
}
