
using ДвижокНовостейЗМ.Models;

namespace ДвижокНовостейЗМ.DAL
{
    class DBInitalazer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            Tag tag1 = new Tag { Name = "Тег у которого много сообщений" };

            for (int i = 0; i < 10; ++i)
            {

                Message message = new Message
                {
                    Title = "Сообщение номер " + i,
                    Text = "Ехохо и бутылка рома номер " + i
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
            }
            context.Tags.Add(tag1);
            base.Seed(context);
        }
    }
}
