using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    public class notEnoughMoneyException : DomainException
    {
        public notEnoughMoneyException()
        : base() { }

        public notEnoughMoneyException(string message1,string message2)
        : base(String.Format("can't open room, because wallet balance {0} lower than buy in policy: {1}",message1,message2)) { }

    }
}