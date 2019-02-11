using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Translators
{
    public class TranslatorInfo
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
        public ITranslator Translator { get; set; }
    }
}