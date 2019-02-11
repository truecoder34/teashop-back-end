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
    public class CreateItemCommand<DTO, MODEL> : Command
        where DTO : EntityDto
        // Заменить на Entity
        where MODEL : class
        //where DbSet : class
    {
        public DTO Dto { get; set; }
        public MODEL Model { get; set; }
        public DbRepositorySQL<MODEL> Repository { get; set; }
        

        public CreateItemCommand(DTO dto, MODEL model, DbRepositorySQL<MODEL> rep)
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
            try
            {
                Repository.Create(itemToCreate);
                Repository.Save();
                result.Result = true;
                result.Message = "DB: Item created successfully";
                result.Data = itemToCreate;
                // возращать гуид
            }
            catch
            {
                result.Result = false;
                result.Message = "DB: Item creation Error";
            }
            

            return result;
        }       
    }
}