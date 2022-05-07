using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Logger
{
    public class XmlLayout : Layout
    {
        private const string XmlLayoutFormat = @"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";
        public XmlLayout() 
            : base(XmlLayoutFormat)
        {
        }
    }
}
