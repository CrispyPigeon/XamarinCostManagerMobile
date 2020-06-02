using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.Base
{
    public class Message
    {
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        public string ReturnMessage { get; set; }
    }

    public class Message<T> : Message
    {
        public T Data { get; set; }
    }
}
