using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Telephony
{
    public interface ICallable
    {
        public string Call(string number);
    }
}
