using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITeaApp.Commands
{
    public interface ICommandCommonResultData<T> : ICommandCommonResult
    {
        T Data { get; set; }
    }
}
