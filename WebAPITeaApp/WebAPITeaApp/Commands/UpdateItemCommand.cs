using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;
using WebAPITeaApp.Repository;

namespace WebAPITeaApp.Commands
{
    public class UpdateItemCommand<DTO, MODEL> : Command
        where DTO : EntityDto
        where MODEL : class
    {
        public DTO Dto { get; set; }
        public MODEL Model { get; set; }
        public DbRepositorySQL<MODEL> Repository { get; set; }

        public UpdateItemCommand(DTO dto, MODEL model, DbRepositorySQL<MODEL> rep)
        {
            Dto = dto;
            Model = model;
            Repository = rep;
        }

        // execute method realization
        public override ICommandCommonResult Execute()
        {
            ICommandCommonResultData<MODEL> result = new CommandResult<MODEL>();
            // Transform from DTO type to MODEL type
            MODEL itemToCreate = Mapper.Map<DTO, MODEL>(Dto);
            //Repository.
            Repository.Update(itemToCreate);
            Repository.Save();
            return result;
        }
    }
}