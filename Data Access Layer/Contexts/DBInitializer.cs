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
            if (context.Shops.Any() && context.Products.Any())
            {
                return; // DB has been seeded
            }

            await CreateDefaultUserAndRoleForApplication(context);
        }

        private static async Task CreateDefaultUserAndRoleForApplication(ApplicationDbContext context)
        {
            IList<CarDB> shopDBs = new List<CarDB>()
            {
                new CarDB(){  Name = "Магазина 1", Address="Улица 1", WorkingMode="Работает", Modified=DateTimeOffset.Now, TimeAdd =DateTimeOffset.Now   },
                new CarDB(){  Name = "Магазина 2", Address="Улица 2", WorkingMode="Работает", Modified=DateTimeOffset.Now, TimeAdd =DateTimeOffset.Now  },
                new CarDB(){  Name = "Магазина 3", Address="Улица 3", WorkingMode="Работает", Modified=DateTimeOffset.Now, TimeAdd =DateTimeOffset.Now  },
                new CarDB(){  Name = "Магазина 4", Address="Улица 3", WorkingMode="Работает", Modified=DateTimeOffset.Now, TimeAdd =DateTimeOffset.Now  }
            };
            IList<UserDB> productDBs = new List<UserDB>()
            {
                new UserDB(){  Name = "Товар 1", Information="Хороший", Modified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new UserDB(){  Name = "Товар 2", Information="Очень хороший", Modified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  },
                new UserDB(){  Name = "Товар 3", Information="Замечательный", Modified=DateTimeOffset.Now, TimeAdd = DateTimeOffset.Now  }
            };

            await Create(context, shopDBs);
            await Create(context, productDBs);
            OrderDB st = new OrderDB()
            {
                ProductId = productDBs[0].Id,
                ShopId = shopDBs[0].Id,
                Modified = DateTimeOffset.Now,
                TimeAdd = DateTimeOffset.Now
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
