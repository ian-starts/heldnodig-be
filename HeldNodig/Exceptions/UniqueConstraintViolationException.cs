using System;

namespace HeldNodig.Exceptions
{
    public class UniqueConstraintViolationException : ArgumentException
    {
        public UniqueConstraintViolationException(string message)
            : base(message)
        {
        }
    }
}