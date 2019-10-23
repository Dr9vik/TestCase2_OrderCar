using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Data_Access_Layer.Common.Models;
using Data_Access_Layer.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<OrderBL> Create(OrderBLCreate item)
        {
            var searchResultOne = await _dataBase.Find<UserDB>(x => x.Id== item.UsertId)
                .ConfigureAwait(false);
            if (!searchResultOne.Any())
                throw new ArgumentException("Юзер отсутствует");

            var searchResultTwo = await _dataBase.Find<CarDB>(x => x.Id == item.CarId)
                .ConfigureAwait(false);
            if (!searchResultOne.Any())
                throw new ArgumentException("Машина отсутствует");

            var order = _mapper.Map<OrderDB>(item);
            _dataBase.Create(order);

            await _dataBase.Save().ConfigureAwait(false);

            return _mapper.Map<OrderBL>(order);
        }

        public async Task<OrderBL> Update(OrderBLUpdate item)
        {
            var searchResultOne = await _dataBase.GetWithThenInclude<OrderDB>(x => x.Where(y=>y.Id == item.Id 
            && y.UsertId== item.UsertId 
            && y.CarId==item.CarId)
            .Include(y=>y.Car)
            .Include(y=>y.User))
                .ConfigureAwait(false);
            if (!searchResultOne.Any())
                throw new ArgumentException("Заказ отсутствует");

            var order = _mapper.Map<OrderDB>(item);
            _dataBase.Update(order);

            await _dataBase.Save().ConfigureAwait(false);

            return _mapper.Map<OrderBL>(order);
        }

        public async Task<string> Delete(Guid id)
        {
            var searchResult = await _dataBase.Find<OrderDB>(
                x => x.Id == id).ConfigureAwait(false);
            if (!searchResult.Any())
                throw new ArgumentException("Заказ отсутствует");

            var model = searchResult.FirstOrDefault();

            _dataBase.Delete(model);
            await _dataBase.Save().ConfigureAwait(false);

            return "ok";
        }
        public async Task<IList<OrderBL>> FindAll()
        {
            return await _dataBase.GetWithInclude<OrderDB>(x=>x.Car, z=>z.User)
                .ContinueWith(result => _mapper.Map<IList<OrderBL>>(result))
                .ConfigureAwait(false);
        }
        public async Task<IList<OrderBL>> FindAll(DateTime? start, DateTime? end, string nameUser, string nameCar, string modelCar)
        {
            var result = await _dataBase.GetWithInclude<OrderDB>(x => x.Car, z => z.User)
                .ConfigureAwait(false);

            Expression<Func<OrderDB, bool>> quary1 = y => y.TimeAdd >= start;
            result = result.Where(quary1);
            Expression<Func<OrderDB, bool>> quary2 = y => y.TimeEnd <= end;
            result = result.Where(quary2);
            Expression<Func<OrderDB, bool>> quary3 = y => y.User.FirstName.Contains(nameUser, StringComparison.CurrentCultureIgnoreCase);
            result = result.Where(quary3);

            return _mapper.Map<IList<OrderBL>>(result);
        }
    }
}
