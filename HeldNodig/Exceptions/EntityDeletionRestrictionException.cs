using System;

namespace HeldNodig.Exceptions
{
    public class EntityDeletionRestrictionException : ArgumentException
    {
        public EntityDeletionRestrictionException(string message)
            : base(message)
        {
        }
    }
}