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
    public class UserService : IUserService
    {
        private IRepository _dataBase;
        private readonly IMapper _mapper;

        public UserService(IRepository dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public async Task<IList<UserBL>> FindAll()
        {
            return await _dataBase.GetAll<UserDB>()
                .ContinueWith(result => _mapper.Map<IList<UserBL>>(result.Result))
                .ConfigureAwait(false);
        }

        public async Task<UserBL> FindById(Guid id)
        {
            return await _dataBase.Find<UserDB>(x => x.Id == id)
                .ContinueWith(result => _mapper.Map<UserBL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false);
        }

        public async Task<UserBL> FindByName(string name)
        {
            return await _dataBase.Find<UserDB>(x => x.FirstName == name)
                .ContinueWith(result => _mapper.Map<UserBL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false); ;
        }
    }
}
