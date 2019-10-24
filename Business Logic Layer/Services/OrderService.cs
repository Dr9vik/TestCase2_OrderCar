using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Model.ModelFilter;
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
            order.TimeAdd = _dateTime;
            order.TimeModified = _dateTime;
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
            order.TimeModified = _dateTime;
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
        //тут или sql запрос либо через процедуры, но база временная...
        public async Task<IList<OrderBL>> FindAll(OrderBLFilter filter)
        {
            var result = await _dataBase.GetWithInclude<OrderDB>(x => x.Car, z => z.User)
                .ConfigureAwait(false);

            result = result.Where(y => (filter.Start == null || y.TimeAdd >= filter.Start)
            && (filter.End == null ||y.TimeEnd <= filter.End)
            && (String.IsNullOrEmpty(filter.NameUser) || String.IsNullOrWhiteSpace(filter.NameUser) || y.User.FirstName.Contains(filter.NameUser.Trim(), StringComparison.CurrentCultureIgnoreCase))
            && (String.IsNullOrEmpty(filter.NameCar) || String.IsNullOrWhiteSpace(filter.NameCar) || y.Car.Name.Contains(filter.NameCar.Trim(), StringComparison.CurrentCultureIgnoreCase))
            && (String.IsNullOrEmpty(filter.ModelCar) || String.IsNullOrWhiteSpace(filter.ModelCar) || y.Car.Model.Contains(filter.ModelCar.Trim(), StringComparison.CurrentCultureIgnoreCase)));

            return _mapper.Map<IList<OrderBL>>(result);
        }
    }
}
