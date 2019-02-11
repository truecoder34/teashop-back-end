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
    public class OrderModelToOrderDtoTranslator : AutomapperTranslator<Order, OrderDto>
    {
        public OrderModelToOrderDtoTranslator(
            IMapperConfigurationExpression configurationExpression,
            Lazy<IMapper> mapper)
            : base(configurationExpression, mapper)
        {
        }

        public override void Configure()
        {
            base.Configure();

            Mapping
                .ForMember(m => m.DateTimeOfOrder,          o => o.MapFrom(m => m.DateTimeProperty))
                .ForMember(m => m.UserGuid,                 o => o.MapFrom(m => m.User.UserId))
                .ForMember(m => m.State,                    o => o.MapFrom(m => m.State))
                .ForMember(m => m.ItemsList,                o => o.MapFrom(m => m.Items));
        }
    }
}