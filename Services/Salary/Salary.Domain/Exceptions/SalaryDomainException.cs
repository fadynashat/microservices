using System;
using System.Collections.Generic;
using System.Text;

namespace FADY.Services.Salary.Dmoain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class SalaryDomainException : Exception
    {
        public SalaryDomainException()
        { }

        public SalaryDomainException(string message)
            : base(message)
        { }

        public SalaryDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
