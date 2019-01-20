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

            context.Categories.Add(new Models.Category
            {
                Name = "Чай"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Чайник"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Гайвань"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Пиалка"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Сливник"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Чабань"
            });

            context.Categories.Add(new Models.Category
            {
                Name = "Аксесуары"
            });

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
            buf1.Name = "testName1";
            buf1.Surname = "testSurname1";
            buf1.AccessMod = 0;
            buf1.Email = "testUser1@mail.ru";
            context.Users.Add(buf1);

            User buf2 = new User();
            buf2.Name = "testName2";
            buf2.Surname = "testSurname2";
            buf2.AccessMod = 0;
            buf2.Email = "testUser2@mail.ru";
            context.Users.Add(buf2);

            context.SaveChanges();

            context.Items.Add(new Models.DB.Item
            {
                Name = "Да Хун Пао",
                CategoryId = 1,
                ManufacterId = 1,
                Cost = 1000,
                Description = "Китайский чай, Темный улун"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Дян Хун",
                CategoryId = 1,
                ManufacterId = 1,
                Cost = 1200,
                Description = "Китайский чай, Красный"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Да И 8592",
                CategoryId = 1,
                ManufacterId = 3,
                Cost = 2500,
                Description = "Шу Пуэр, Блин 357 грамм. Фабрика: Да И"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Чайник №41",
                CategoryId = 2,
                ManufacterId = 2,
                Cost = 6500,
                Description = "Чайник из исинской глины, коричневый"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Чайник №35",
                CategoryId = 2,
                ManufacterId = 2,
                Cost = 30000,
                Description = "Чайник из нефрита"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Гайвань №4",
                CategoryId = 3,
                ManufacterId = 3,
                Cost = 1200,
                Description = "Гайвань, глазурированая глина"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Гайвань №3",
                CategoryId = 3,
                ManufacterId = 3,
                Cost = 1000,
                Description = "Гайвань, белый фарфорб синий узор"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Пиалка №8",
                CategoryId = 4,
                ManufacterId = 4,
                Cost = 1200,
                Description = "Пиалка, глина, глазурь"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Сливник №5",
                CategoryId = 5,
                ManufacterId = 4,
                Cost = 500,
                Description = "Стекло"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Чабань №6",
                CategoryId = 6,
                ManufacterId = 4,
                Cost = 4500,
                Description = "Чабань черная с узором, груша"
            });

            context.Items.Add(new Models.DB.Item
            {
                Name = "Фигурка Хотэй",
                CategoryId = 7,
                ManufacterId = 4,
                Cost = 500,
                Description = "Чайная фигурка Хотэйя, нефрит"
            });

            context.SaveChanges();


            context.Orders.Add(new Models.DB.Order
            {
                DateTimeProperty = DateTime.Now,
                UserId = 1
            });

            context.SaveChanges();

            context.Photos.Add(new Models.DB.Photo
            {
                LinkPhoto = "linkToPhoto1",
                ItemId = 1
            });

            context.Photos.Add(new Models.DB.Photo
            {
                LinkPhoto = "linkToPhoto2",
                ItemId = 2
            });

            context.Photos.Add(new Models.DB.Photo
            {
                LinkPhoto = "linkToPhoto3",
                ItemId = 3
            });
            context.SaveChanges();
        }
    }
}