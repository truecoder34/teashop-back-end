using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Commands
{
    public class CreateItemCommand<DTO, MODEL, DB> : Command
    {
        public DTO Dto { get; set; }
        public MODEL Model { get; set; }
        public DB DbContext { get; set; }


        public CreateItemCommand(DTO dto, MODEL model, DB db)
        {
            Dto = dto;
            Model = model;
            DbContext = db;
        }

        // execute method realization
        public override void Execute()
        {
            // Transform from DTO type to MODEL type
            MODEL itemToCreate = Mapper.Map<DTO, MODEL>(Dto);
            DbContext.Add(itemToCreate);
            DbContext.SaveChanges();
        }
    }
}