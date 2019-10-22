using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Data_Access_Layer.Common.Models;
using Data_Access_Layer.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class OrderService : IOrderService
    {
        private IRepository _dataBase;
        private readonly IMapper _mapper;
        private DateTime _dateTime;

        public OrderService(IRepository dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
            _dateTime = DateTime.Now;
        }

        public async Task<ShopSPBL> AddProduct(ShopSPBL item)
        {
            var searchResult = await _dataBase.GetWithThenInclude<CarDB>(x => x.Where(y=>y.Id==item.Id).Include(q=>q.StoreProducts))
                .ConfigureAwait(false);
            if (!searchResult.Any())
                throw new ArgumentException($"{item.Name} - магазин отсутствует");

            var itemShop = searchResult.FirstOrDefault();

            var resultEqual = EqualRep(itemShop.StoreProducts, item.Products, "Id", "Id");
            if (!resultEqual.Any())
                throw new ArgumentException($"Товары отсутствуют");

            OrderDB storeProductDB = new OrderDB();
            foreach (var product in resultEqual)
            {
                storeProductDB.ProductId = product.Id;
                storeProductDB.ShopId = item.Id;
                storeProductDB.Modified = _dateTime;
                storeProductDB.TimeAdd = _dateTime;
                _dataBase.Create(storeProductDB);
                product.StoreProductId = storeProductDB.Id;
            }
            await _dataBase.Save();

            return item;
        }

        public Task<ShopSPBL> Update(ShopSPBL item)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Delete(Guid id)
        {
            var searchResult = await _dataBase.Find<OrderDB>(
                x => x.Id == id).ConfigureAwait(false);
            if (!searchResult.Any())
                throw new ArgumentException("Продукт в магазине отсутствует");

            var model = searchResult.FirstOrDefault();

            _dataBase.Delete(model);
            await _dataBase.Save().ConfigureAwait(false);

            return "ok";
        }

        public async Task<ShopSPBL> FindAllProductInShop(Guid id)
        {
            return (await _dataBase.GetWithThenInclude<CarDB>(x => x.Where(y => y.Id == id)
            .Include(z => z.StoreProducts)
            .ThenInclude(z => z.Shop))
            .ContinueWith(result => result.Result)
            .ConfigureAwait(false))
            .Select(u => new ShopSPBL()
            {
                Id = u.Id,
                Name = u.Name,
                Products = u.StoreProducts.Select(q => new ProductSPBL()
                {
                    Id = q.ProductId,
                    StoreProductId = q.Id,
                    Name = q.Product.Name,
                }).ToList()
            }).FirstOrDefault();
        }

        public async Task<ShopSPBL> FindAllProductNotInShop(Guid id)
        {
            var shop = await _dataBase.Find<CarDB>(x=>x.Id == id).ConfigureAwait(false);
            if (!shop.Any())
                throw new ArgumentException($"Магазин отсутствует");

            var products = (await _dataBase.GetWithThenInclude<UserDB>(x=>x.Include(z => z.StoreProducts))
                .ContinueWith(result => _mapper.Map<IList<UserBL>>(result.Result))
                .ConfigureAwait(false)).ToList();
            for(int i=0;i < products.Count;i++)
            {
                if(products[i].StoreProducts.Where(y => y.ShopId == id).Any())
                {
                    products.RemoveAt(i);
                    i--;
                }
            }
            return  new ShopSPBL()
            {
                Id = id,
                Name = shop.FirstOrDefault().Name,
                Products = products.Select(r => new ProductSPBL
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList()
            };
        }

        private IList<U> EqualRep<T, U>(IList<T> primary, IList<U> secondary, string fieldOne, string fieldTwo) where T : class where U : class
        {
            for (int i = 0; i < primary.Count(); i++)
            {
                for (int q = 0; q < secondary.Count(); q++)
                {
                    var a = typeof(T).GetProperty(fieldOne).GetValue(primary[i]).GetHashCode();
                    var b = typeof(U).GetProperty(fieldTwo).GetValue(secondary[q]).GetHashCode();
                    if (a == b)
                    {
                        secondary.RemoveAt(q);
                        q--;
                        i--;
                        break;
                    }
                }
            }
            return secondary;
        }
    }
}
