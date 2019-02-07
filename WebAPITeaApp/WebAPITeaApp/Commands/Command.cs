using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Commands
{
    abstract public class Command
    {
       public abstract void Execute();
    }
}