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
                name = "Чай"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Чайник"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Гайвань"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Пиалка"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Сливник"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Чабань"
            });

            context.Categories.Add(new Models.Category
            {
                name = "Аксесуары"
            });

            context.SaveChanges();

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                name = "TestManufacturer1",
                madeCountry = "TestCountry1"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                name = "TestManufacturer2",
                madeCountry = "TestCountry2"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                name = "TestManufacturer3",
                madeCountry = "TestCountry3"
            });

            context.Manufacters.Add(new Models.DB.Manufacter
            {
                name = "TestManufacturer4",
                madeCountry = "TestCountry4"
            });

            context.SaveChanges();

            User buf1 = new User();
            buf1.name = "testName1";
            buf1.surname = "testSurname1";
            buf1.accessMod = 0;
            buf1.email = "testUser1@mail.ru";
            context.Users.Add(buf1);

            User buf2 = new User();
            buf2.name = "testName2";
            buf2.surname = "testSurname2";
            buf2.accessMod = 0;
            buf2.email = "testUser2@mail.ru";
            context.Users.Add(buf2);

            context.SaveChanges();

            context.Items.Add(new Models.DB.Item
            {
                name = "Да Хун Пао",
                categoryId = 1,
                manufacterId = 1,
                cost = 1000,
                description = "Китайский чай, Темный улун"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Дян Хун",
                categoryId = 1,
                manufacterId = 1,
                cost = 1200,
                description = "Китайский чай, Красный"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Да И 8592",
                categoryId = 1,
                manufacterId = 3,
                cost = 2500,
                description = "Шу Пуэр, Блин 357 грамм. Фабрика: Да И"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Чайник №41",
                categoryId = 2,
                manufacterId = 2,
                cost = 6500,
                description = "Чайник из исинской глины, коричневый"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Чайник №35",
                categoryId = 2,
                manufacterId = 2,
                cost = 30000,
                description = "Чайник из нефрита"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Гайвань №4",
                categoryId = 3,
                manufacterId = 3,
                cost = 1200,
                description = "Гайвань, глазурированая глина"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Гайвань №3",
                categoryId = 3,
                manufacterId = 3,
                cost = 1000,
                description = "Гайвань, белый фарфорб синий узор"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Пиалка №8",
                categoryId = 4,
                manufacterId = 4,
                cost = 1200,
                description = "Пиалка, глина, глазурь"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Сливник №5",
                categoryId = 5,
                manufacterId = 4,
                cost = 500,
                description = "Стекло"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Чабань №6",
                categoryId = 6,
                manufacterId = 4,
                cost = 4500,
                description = "Чабань черная с узором, груша"
            });

            context.Items.Add(new Models.DB.Item
            {
                name = "Фигурка Хотэй",
                categoryId = 7,
                manufacterId = 4,
                cost = 500,
                description = "Чайная фигурка Хотэйя, нефрит"
            });

            context.SaveChanges();


            context.Orders.Add(new Models.DB.Order
            {
                dateTimeProperty = DateTime.Now,
                userId = 1
            });

            context.SaveChanges();

            context.Photos.Add(new Models.DB.Photo
            {
                linkPhoto = "linkToPhoto1",
                itemId = 1
            });

            context.Photos.Add(new Models.DB.Photo
            {
                linkPhoto = "linkToPhoto2",
                itemId = 2
            });

            context.Photos.Add(new Models.DB.Photo
            {
                linkPhoto = "linkToPhoto3",
                itemId = 3
            });
            context.SaveChanges();
        }
    }
}