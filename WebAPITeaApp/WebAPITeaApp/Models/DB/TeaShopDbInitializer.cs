using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPITeaApp.Models.DB
{
    public class TeaShopDbInitializer : DropCreateDatabaseIfModelChanges<TeaShopContext>
    {
        protected override void Seed(TeaShopContext context)
        {
            base.Seed(context);

            Category bufCat1 = new Category();
            bufCat1.Name = "Чай";
            context.Categories.Add(bufCat1);

            Category bufCat2 = new Category();
            bufCat2.Name = "Чайник";
            context.Categories.Add(bufCat2);

            Category bufCat3 = new Category();
            bufCat3.Name = "Гайвань";
            context.Categories.Add(bufCat3);

            Category bufCat4 = new Category();
            bufCat4.Name = "Пиалка";
            context.Categories.Add(bufCat4);

            Category bufCat5 = new Category();
            bufCat5.Name = "Сливник";
            context.Categories.Add(bufCat5);

            Category bufCat6 = new Category();
            bufCat6.Name = "Чабань";
            context.Categories.Add(bufCat6);

            Category bufCat7 = new Category();
            bufCat7.Name = "Аксесуары";
            context.Categories.Add(bufCat7);



            context.SaveChanges();

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                Name = "TestManufacturer1",
                MadeCountry = "TestCountry1"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                Name = "TestManufacturer2",
                MadeCountry = "TestCountry2"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                Name = "TestManufacturer3",
                MadeCountry = "TestCountry3"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                Name = "TestManufacturer4",
                MadeCountry = "TestCountry4"
            });

            context.SaveChanges();

            User buf1 = new User();
            buf1.UserId = new Guid("4e05432d-0d0c-445a-bc06-c31e828d18c5");
            buf1.Name = "romanguschin@mail.ru";
            buf1.Surname = "romanguschin@mail.ru";
            buf1.AccessMod = 1;
            buf1.Email = "romanguschin@mail.ru";
            context.Users.Add(buf1);

            //User buf2 = new User();
            //buf2.UserId = new Guid("17962d7b-40e5-48ab-b39f-b20aa8c595db");
            //buf2.Name = "fffffffffffffffffffff@mail.ru";
            //buf2.Surname = "fffffffffffffffffffff@mail.ru";
            //buf2.AccessMod = 0;
            //buf2.Email = "fffffffffffffffffffff@mail.ru@mail.ru";
            //context.Users.Add(buf2);

            //User buf3 = new User();
            //buf3.UserId = new Guid("81a1ed9e-d964-4247-9676-48f242904a40");
            //buf3.Name = "kesha_gaz2@mail.ru";
            //buf3.Surname = "kesha_gaz2@mail.ru";
            //buf3.AccessMod = 0;
            //buf3.Email = "kesha_gaz2@mail.ru@mail.ru";
            //context.Users.Add(buf3);

            context.SaveChanges();

            UserInfo bufUserInfo1 = new UserInfo();
            bufUserInfo1.UserId = new Guid("4e05432d-0d0c-445a-bc06-c31e828d18c5");
            bufUserInfo1.Name = "Roman";
            bufUserInfo1.Surname = "Gushin";
            bufUserInfo1.Email = "romanguschin@mail.ru";
            bufUserInfo1.Address = "Mira street 10, Volgograd";
            context.UsersInfo.Add(bufUserInfo1);

            //UserInfo bufUserInfo2 = new UserInfo();
            //bufUserInfo2.UserId = new Guid("17962d7b-40e5-48ab-b39f-b20aa8c595db");
            //bufUserInfo2.Name = "Ferz";
            //bufUserInfo2.Surname = "Ferzov";
            //bufUserInfo2.Email = "fffffffffffffffffffff@mail.ru@mail.ru";
            //bufUserInfo2.Address = "Rap street, Moscow";
            //context.UsersInfo.Add(bufUserInfo2);

            UserInfo bufUserInfo3 = new UserInfo();
            bufUserInfo3.UserId = new Guid("81a1ed9e-d964-4247-9676-48f242904a40");
            bufUserInfo3.Name = "Kesha";
            bufUserInfo3.Surname = "Gazinskiy";
            bufUserInfo3.Email = "kesha_gaz2@mail.ru@mail.ru";
            bufUserInfo3.Address = "Volgograd, Krasnoznamenskaya street 10";
            context.UsersInfo.Add(bufUserInfo3);

            Item bufItem1 = new Item();
            bufItem1.GuidId = Guid.NewGuid();
            bufItem1.Name = "Да Хун Пао";
            bufItem1.Cost = 1000;
            bufItem1.Description = "Китайский чай, Темный улун";
            bufItem1.ImageLink = "................";
            bufItem1.Manufacter = context.Manufacters.Where(b => b.ManufacterId == 1).First();
            bufItem1.Category = context.Categories.Where(b => b.CategoryId == 1).First();

            context.Items.Add(bufItem1);

            Item bufItem2 = new Item();
            bufItem2.GuidId = Guid.NewGuid();
            bufItem2.Name = "Дян Хун";
            bufItem2.Cost = 1200;
            bufItem2.Description = "Китайский чай, Красный";
            bufItem2.ImageLink = "................";
            bufItem2.Manufacter = context.Manufacters.Where(b => b.ManufacterId == 3).First();
            bufItem2.Category = context.Categories.Where(b => b.CategoryId == 1).First();

            context.Items.Add(bufItem2);

            Item bufItem3 = new Item();
            bufItem3.GuidId = Guid.NewGuid();
            bufItem3.Name = "Да И 8592";
            bufItem3.Cost = 2500;
            bufItem3.Description = "Шу Пуэр, Блин 357 грамм. Фабрика: Да И";
            bufItem3.ImageLink = "................";
            bufItem3.Manufacter = context.Manufacters.Where(b => b.ManufacterId == 2).First();
            bufItem3.Category = context.Categories.Where(b => b.CategoryId == 1).First();

            context.Items.Add(bufItem3);

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Чайник №41",
                Cost = 6500,
                Description = "Чайник из исинской глины, коричневый",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 4).First(),
                Category = context.Categories.Where(b => b.CategoryId == 2).First()

        });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Чайник №35",
                Cost = 30000,
                Description = "Чайник из нефрита",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 4).First(),
                Category = context.Categories.Where(b => b.CategoryId == 2).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Гайвань №4",
                Cost = 1200, 
                Description = "Гайвань, глазурированая глина",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 3).First(),
                Category = context.Categories.Where(b => b.CategoryId == 3).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Гайвань №3",
                Cost = 1000,
                Description = "Гайвань, белый фарфорб синий узор",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 1).First(),
                Category = context.Categories.Where(b => b.CategoryId == 3).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Пиалка №8",
                Cost = 1200,
                Description = "Пиалка, глина, глазурь",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 4).First(),
                Category = context.Categories.Where(b => b.CategoryId == 4).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Сливник №5",
                Cost = 500,
                Description = "Стекло",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 4).First(),
                Category = context.Categories.Where(b => b.CategoryId == 5).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Чабань №6",
                Cost = 4500,
                Description = "Чабань черная с узором, груша",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 1).First(),
                Category = context.Categories.Where(b => b.CategoryId == 6).First()
            });

            context.Items.Add(new Models.DB.Item
            {
                GuidId = Guid.NewGuid(),
                Name = "Фигурка Хотэй",
                Cost = 500,
                Description = "Чайная фигурка Хотэйя, нефрит",
                ImageLink = "................",
                Manufacter = context.Manufacters.Where(b => b.ManufacterId == 2).First(),
                Category = context.Categories.Where(b => b.CategoryId == 7).First()
            });

            context.SaveChanges();


            context.Orders.Add(new Models.DB.Order
            {
                OrderId = Guid.NewGuid(),
                DateTimeProperty = DateTime.Now,
                //UserId = buf1.UserId
                User = context.Users.Where(b => b.UserId == buf1.UserId).First(),
                Items = context.Items.Where(b => b.Manufacter.ManufacterId == 2).ToList()
            });

            // FOR DEBUG
            //List<Item> bufItems = context.Items.Where(b => b.Manufacter.ManufacterId == 2).ToList();
            context.SaveChanges();

            context.Photos.Add(new Models.DB.Photo
            {
                PhotoId = Guid.NewGuid(),
                LinkPhoto = "linkToPhoto1",
                GuidId = bufItem1.GuidId
            });

            context.Photos.Add(new Models.DB.Photo
            {
                PhotoId = Guid.NewGuid(),
                LinkPhoto = "linkToPhoto2",
                GuidId = bufItem2.GuidId
            });

            context.Photos.Add(new Models.DB.Photo
            {
                PhotoId = Guid.NewGuid(),
                LinkPhoto = "linkToPhoto3",
                GuidId = bufItem3.GuidId
            });
            context.SaveChanges();
        }
    }
}