using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Translators
{
    public static class TranslatorExtension
    {
        public static IReadOnlyCollection<TDestination> TranslateCollection<TSource, TDestination>(this ITranslator<TSource, TDestination> translator, IEnumerable<TSource> source)
        {
            return source
                .Select(translator.Translate)
                .ToArray();
        }

        public static IReadOnlyCollection<object> TranslateCollection(this ITranslator translator, IEnumerable<object> source)
        {
            return source
                .Select(translator.Translate)
                .ToArray();
        }
    }
}