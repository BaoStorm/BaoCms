using System;

namespace Identity.Domain.Exceptions
{
    /// <summary>
    /// Identity领域异常
    /// </summary>
    public class IdentityDomainException : Exception
    {
        public IdentityDomainException()
        { }

        public IdentityDomainException(string message)
            : base(message)
        { }

        public IdentityDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
