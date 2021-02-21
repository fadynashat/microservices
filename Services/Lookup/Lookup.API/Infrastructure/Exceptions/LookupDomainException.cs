using System;

namespace Lookup.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class LookupDomainException : Exception
    {
        public LookupDomainException()
        { }

        public LookupDomainException(string message)
            : base(message)
        { }

        public LookupDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
