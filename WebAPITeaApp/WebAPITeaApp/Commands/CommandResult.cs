using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Commands
{
   
        public class CommandResult : ICommandCommonResult
        {
            public bool Result { get; set; }
            public string Message { get; set; }
        }

        public class CommandResult<T> : ICommandCommonResultData<T>
        {
            public bool Result { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }

}