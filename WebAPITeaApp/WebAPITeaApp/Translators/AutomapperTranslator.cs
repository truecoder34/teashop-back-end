using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Translators
{
    public class AutomapperTranslator<TSourse, TDestination> : ITranslator<TSourse, TDestination>
    {
        private readonly Lazy<IMapper> _mapper;

        protected IMappingExpression<TSourse, TDestination> Mapping;
        protected IMapper Mapper => _mapper.Value;

        public AutomapperTranslator(IMapperConfigurationExpression configurationExpression, Lazy<IMapper> mapper)
        {
            _mapper = mapper;
            Mapping = configurationExpression.CreateMap<TSourse, TDestination>();
        }

        public virtual void Configure()
        {
            Mapping
                .BeforeMap(BeforeMap)
                .AfterMap(AfterMap);
        }

        public TDestination Translate(TSourse source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public void Update(TSourse source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }

        public object Translate(object source)
        {
            return Translate((TSourse)source);
        }

        public void Update(object source, object destination)
        {
            Mapper.Map((TSourse)source, (TDestination)destination);
        }

        protected virtual void BeforeMap(TSourse source, TDestination destintion)
        {

        }

        protected virtual void AfterMap(TSourse source, TDestination destination)
        {
        }
    }
}