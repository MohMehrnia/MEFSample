using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMEF.Interfaces
{
    public interface IMessageSender
    {
        void Send(string message);
    }
}
