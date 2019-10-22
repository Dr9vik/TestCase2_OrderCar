using AutoMapper;
using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Data_Access_Layer.Common.Models;
using Data_Access_Layer.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class CarService : ICarService
    {
        private IRepository _dataBase;
        private readonly IMapper _mapper;

        public CarService(IRepository dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public async Task<IList<CarBL>> FindAll()
        {
            return await _dataBase.GetAll<CarDB>()
                .ContinueWith(result => _mapper.Map<IList<CarBL>>(result.Result))
                .ConfigureAwait(false);
        }

        public async Task<CarBL> FindById(Guid id)
        {
            return await _dataBase.Find<CarDB>(x => x.Id == id)
                .ContinueWith(result => _mapper.Map<CarBL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false);
        }

        public async Task<CarBL> FindByName(string name)
        {
            return await _dataBase.Find<CarDB>(x => x.Name == name)
                .ContinueWith(result => _mapper.Map<CarBL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false);
        }
    }
}
