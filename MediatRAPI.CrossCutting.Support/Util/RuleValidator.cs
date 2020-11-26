using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatRAPI.CrossCutting.Support.Util
{
    public class RuleValidator
    {
        private readonly List<string> _errorMessages;

        private RuleValidator()
        {
            _errorMessages = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string errorMessage)
        {
            if(hasError)
                _errorMessages.Add(errorMessage);

            return this;
        }

        public RuleValidator CpfIsValid(string cpf, string errorMessage)
        {
            var isvalid = ValidateCpf.IsValid(cpf);

            if (!isvalid)
                _errorMessages.Add(errorMessage);

            return this;
        }

        public void ExceptionIfExist()
        {
            if (_errorMessages.Any())
                throw new ExceptionDomain(_errorMessages);
        }
    }

    public class ExceptionDomain : ArgumentException
    {
        public List<string> ErrorMessage { get; set; }

        public ExceptionDomain(List<string> errorMessages)
        {
            ErrorMessage = errorMessages;
        }
    }
}
