using Data_Access_Layer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contexts
{
    public class DBInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (context.Users.Any() && context.Cars.Any())
            {
                return; // DB has been seeded
            }

            await CreateDefaultUserAndRoleForApplication(context);
        }

        private static async Task CreateDefaultUserAndRoleForApplication(ApplicationDbContext context)
        {
            ///в машинах не зазбираюсь только в цвете
            IList<CarDB> cars = new List<CarDB>()
            {
                new CarDB(){  Name = "Фольцваген", Model="Большая", Class="C", RegistrationNumber="AA3221", DateRelease=new DateTime(1990,02,01), TimeModified = DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now   },
                new CarDB(){  Name = "Бемве", Model="ОченьБольшая", Class="B", RegistrationNumber="DF2166", DateRelease=new DateTime(2008,03,01), TimeModified = DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new CarDB(){  Name = "Мерс", Model="Малая", Class="B", RegistrationNumber="SS9673", DateRelease=new DateTime(2019,12,01), TimeModified = DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new CarDB(){  Name = "Лянча", Model="Прималая", Class="A", RegistrationNumber="JG5638", DateRelease=new DateTime(2015,02,01), TimeModified = DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  }
            };
            IList<UserDB> users = new List<UserDB>()
            {
                new UserDB(){  FirstName = "Леша", LastName="Фамилия1", Birthday = new DateTime(1990,02,12), NumberDL="REF4433GGGGREEE", TimeModified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new UserDB(){  FirstName = "Саша", LastName="Фамилия2", Birthday = new DateTime(1999,01,11), NumberDL="KFIER834834KKDSFDG", TimeModified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new UserDB(){  FirstName = "Вася", LastName="Фамилия3", Birthday = new DateTime(2000,08,23), NumberDL="85349DDSDGDGFDF", TimeModified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  }
            };

            await Create(context, cars);
            await Create(context, users);
            OrderDB st = new OrderDB()
            {
                UsertId = cars[0].Id,
                CarId = users[0].Id,
                TimeModified = DateTimeOffset.Now,
                TimeAdd = DateTimeOffset.Now,
                Information="красные окна"
            };
            await Create(context, new List<OrderDB>() { st });
        }

        private static async Task Create<T>(ApplicationDbContext context, IList<T> items)where T : class
        {
            foreach (var item in items)
            {
                context.Set<T>().Add(item);
            }
            await context.SaveChangesAsync();
        }
    }
}
