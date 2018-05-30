using SampleMEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace SampleMEF.Plugins
{
    [Export(typeof(IMessageSender))]
    public class SMSSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine("My Plugins is " + message );
        }
    }
}
