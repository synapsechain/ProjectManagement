using System;

namespace ProjectManagement.Api.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string type, long id)
            : base($"{type} '{id}'")
        {
        }
        
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
