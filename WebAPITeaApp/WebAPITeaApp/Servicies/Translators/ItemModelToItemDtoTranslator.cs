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
    public class ItemModelToItemDtoTranslator: AutomapperTranslator<Item, ItemDto>
    {
        public ItemModelToItemDtoTranslator(
            IMapperConfigurationExpression configurationExpression,
            Lazy<IMapper> mapper)
            : base(configurationExpression, mapper)
        {
        }

        public override void Configure()
        {
            base.Configure();

            Mapping
                .ForMember(m => m.GuidIdOfItem,         o => o.MapFrom(m => m.GuidId))
                .ForMember(m => m.Cost,                 o => o.MapFrom(m => m.Cost))
                .ForMember(m => m.Name,                 o => o.MapFrom(m => m.Name))
                .ForMember(m => m.Description,          o => o.MapFrom(m => m.Description))
                .ForMember(m => m.ImageLink,            o => o.MapFrom(m => m.ImageLink))
                .ForMember(m => m.CategoryId,           o => o.MapFrom(m => m.Category.CategoryId))
                .ForMember(m => m.ManufacterId,         o => o.MapFrom(m => m.Manufacter.ManufacterId));

        }
    }
}