using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Exceptions
{
    public class MessageException : Exception
    {
        public int Code { get; set; }
        public string TextMessage { get; set; }
    }
}