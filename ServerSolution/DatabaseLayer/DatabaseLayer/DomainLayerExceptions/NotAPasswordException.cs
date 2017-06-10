using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    public  class NotAPasswordException : DomainException
    {
        public NotAPasswordException (string password) : base("Invalid password: " + password)
        {         
        }
    }
}
