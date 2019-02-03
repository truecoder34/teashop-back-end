using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Translators
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Item, ItemDto>().ReverseMap();
                config.CreateMap<OrderDto, Order>().ReverseMap();
                config.CreateMap<UserInfo, UserInfoDto>().ReverseMap();
                config.CreateMap<UserInfoDto, UserInfo>().ReverseMap();
            });
        }
    }
}