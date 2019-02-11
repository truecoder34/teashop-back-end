using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;
using WebAPITeaApp.Translators;

namespace WebAPITeaApp.Servicies.Translators
{
    public class OrderDtoToOrderModelTranlator : AutomapperTranslator<OrderDto,Order>
    {
        public OrderDtoToOrderModelTranlator(
            IMapperConfigurationExpression configurationExpression, Lazy<IMapper> mapper)
            : base(configurationExpression, mapper)
        {
        }

        public override void Configure()
        {
            base.Configure();

            Mapping
                .ForMember(m => m.DateTimeProperty,     o => o.MapFrom(m => m.DateTimeOfOrder))
                .ForMember(m => m.User.UserId,          o => o.MapFrom(m => m.UserGuid))
                .ForMember(m => m.State,                o => o.MapFrom(m => m.State))
                .ForMember(m => m.Items,                o => o.MapFrom(m => m.ItemsList));
        }
    }
}