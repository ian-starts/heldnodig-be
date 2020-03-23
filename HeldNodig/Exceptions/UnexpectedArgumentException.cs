using System;

namespace HeldNodig.Exceptions
{
    /// <summary>
    /// Similar to ArgumentException, except that this is thrown when dealing with user input.
    /// </summary>
    public class UnexpectedArgumentException : ArgumentException
    {
        public UnexpectedArgumentException(string message)
            : base(message)
        {
        }
    }
}