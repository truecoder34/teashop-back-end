using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    [Authorize(Roles = "User")]
    public class UserController : ApiController
    {
        TeaShopContext db = new TeaShopContext();
        /*
         GET: api/user/{Guid}
          method to get personal info about user
        */
        [HttpGet]
        [Route("user/{id}")]
        public UserInfoDto GetUserInfo(Guid id)
        {
            UserInfoDto infoAboutUser = new UserInfoDto();
            UserInfo infoFromDb = new UserInfo();
            try
            {
                infoFromDb = db.UsersInfo.Where(b => b.UserId == id).First();
            }
            catch
            {
                return infoAboutUser;
            }
           
            if (infoFromDb != null)
            {
                infoAboutUser = Mapper.Map<UserInfo, UserInfoDto>(infoFromDb);
            }
            return infoAboutUser;
        }

        /*
         Post api/user
         Add new personal data about user
         On Save btn clicked - ADD NEW
       */
       [HttpPost]
       [Route("user")]
       public HttpResponseMessage PostUserInfo([FromBody] UserInfoDto userInfoDto)
       {
            UserInfo infoToWriteToDb = new UserInfo();
            UserInfo dataFromDb = new UserInfo();
            Guid logGuid;

            //userInfoDto.UserId = Guid.Parse(userInfoDto.UserId.First());
            try
            {
                // ЕСЛИ в БАЗЕ есть  ифна про этого юзера, то ОБНОВЛОЯЕМ
                logGuid = Guid.Parse(userInfoDto.UserId);
                dataFromDb = db.UsersInfo.Where(b => b.UserId == logGuid).First();
            }
            catch
            {
                // ЕСЛИ НЕТ ТО ДОБАВЛЯЕМ
                //infoToWriteToDb = Mapper.Map<UserInfoDto, UserInfo>(userInfoDto);
                //infoToWriteToDb.UserId = Guid.Parse(userInfoDto.UserId);
                infoToWriteToDb.UserId = Guid.Parse(userInfoDto.UserId);
                infoToWriteToDb.Name = userInfoDto.Name;
                infoToWriteToDb.Surname = userInfoDto.Surname;
                infoToWriteToDb.Email = userInfoDto.Email;
                infoToWriteToDb.Address = userInfoDto.Address;

                db.UsersInfo.Add(infoToWriteToDb);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            }

            // ДЕРГАЕМ МЕТОД ПУТ
            //RefreshNoteInDb(userDto);
            //UserInfo dataFromDb = new UserInfo();
            logGuid = Guid.Parse(userInfoDto.UserId);
            dataFromDb = db.UsersInfo.Where(b => b.UserId == logGuid).First();
            Guid guiIdOfNoteToRemove = dataFromDb.GuidId;

            db.UsersInfo.Remove(dataFromDb);

            // Приводим НОВЫЕ ДАНННЫЕ К Виду допустимому к записи в БД
            //UserInfo refreshedData = Mapper.Map<UserInfoDto, UserInfo>(userInfoDto);
            //infoToWriteToDb.UserId = Guid.Parse(userInfoDto.UserId);
            UserInfo refreshedData = new UserInfo();
            refreshedData.UserId = Guid.Parse(userInfoDto.UserId);
            refreshedData.Name = userInfoDto.Name;
            refreshedData.Surname = userInfoDto.Surname;
            refreshedData.Email = userInfoDto.Email;
            refreshedData.Address = userInfoDto.Address;


            refreshedData.GuidId = guiIdOfNoteToRemove;

            db.UsersInfo.Add(refreshedData);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Ok");
       }

       // REFRESH NOTE IN DB
       //public string RefreshNoteInDb(UserDto userDto)
       //{
       //     UserInfo dataFromDb = new UserInfo();
       //     dataFromDb = db.UsersInfo.Where(b => b.UserId == userDto.UserGuid).First();
       //     Guid guiIdOfNoteToRemove = dataFromDb.GuidId;

       //     db.UsersInfo.Remove(dataFromDb);

       //     // Приводим НОВЫЕ ДАНННЫЕ К Виду допустимому к записи в БД
       //     UserInfo refreshedData = Mapper.Map<UserDto, UserInfo>(userDto);

       //     refreshedData.GuidId = guiIdOfNoteToRemove;

       //     db.UsersInfo.Add(refreshedData);


       //     return "Ok";
       //}


    }
}
