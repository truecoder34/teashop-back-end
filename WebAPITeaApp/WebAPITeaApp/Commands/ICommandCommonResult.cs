using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITeaApp.Commands
{
    public interface ICommandCommonResult
    {
        bool Result { get; set; }
        string Message { get; set; }
    }
}
