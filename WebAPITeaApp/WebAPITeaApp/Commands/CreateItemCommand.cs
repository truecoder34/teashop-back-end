using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Commands
{
    public class CreateItemCommand : Command
    {
        EntityDto DTO { get; set; }
        Entity Model { get; set; }
        TeaShopContext Context { get; set; }


        public CreateItemCommand(EntityDto dto, TeaShopContext db, Entity model)
        {
            DTO = dto;
            Model = model;
            Context = db;
        }

        // execute method realization
        public override void Execute()
        {
            //Item recievedFromAdminItem = Mapper.Map<ItemDto, Item>(dto);
        }
    }
}