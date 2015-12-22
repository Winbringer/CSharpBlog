
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using ДвижокНовостейЗМ.Models;
using ДвижокНовостейЗМ.Models.Identity;

namespace ДвижокНовостейЗМ.DAL
{
    class DBInitalazer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            Tag tag1 = new Tag { Name = "Тег у которого много сообщений" };

            for (int i = 0; i < 100; ++i)
            {

                Message message = new Message
                {
                    Title = "Сообщение номер " + i,
                    Text = "Ехохо и бутылка рома номер " + i,
                    PubDate=DateTime.Now
                };
                Tag tag = new Tag
                {
                    Name = "Тег номер " + i
                };
                if (i % 2 == 0)
                {
                    message.Tags.Add(tag1);
                    tag.Messages.Add(message);
                }                
                context.Messages.Add(message);
                context.Tags.Add(tag);
                Reply reply = new Reply
                {
                    Text = "Все хуйня Миша, давай по новой " + i,
                    Date = DateTime.Now,
                    Message= message
                };
                context.Replys.Add(reply);
            }
            context.Tags.Add(tag1);
            var userManager = new ApplicationManager(new UserStore<ApplicationUser>(context));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            // создаем две роли
            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "Admin", FIO="Admin", Sex=Sex.Мужской, Year=20 };
            string password = "123456";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}
