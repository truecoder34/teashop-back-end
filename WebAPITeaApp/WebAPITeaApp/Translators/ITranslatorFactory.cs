using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITeaApp.Translators
{
    public interface ITranslatorFactory
    {
        void Initialize();

        ITranslator<TSource, TDestination> GetTranslator<TSource, TDestination>();
        ITranslator GetTranslator(Type sourceType, Type destinationType);
    }
}
