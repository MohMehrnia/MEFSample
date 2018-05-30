using SampleMEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace SampleMEF.AddIns
{
    [Export(typeof(IMessageSender))]
    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
