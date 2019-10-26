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

        public async Task<IList<UserBLCL>> FindAll<UserBLCL>()
        {
            return await _dataBase.GetAll<UserDB>()
                .ContinueWith(result => _mapper.Map<IList<UserBLCL>>(result.Result))
                .ConfigureAwait(false);
        }

        public async Task<UserBLCL> FindById<UserBLCL>(Guid id)
        {
            return await _dataBase.Find<UserDB>(x => x.Id == id)
                .ContinueWith(result => _mapper.Map<UserBLCL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false);
        }

        public async Task<UserBLCL> FindByName<UserBLCL>(string name)
        {
            return await _dataBase.Find<UserDB>(x => x.FirstName == name)
                .ContinueWith(result => _mapper.Map<UserBLCL>(result.Result.FirstOrDefault()))
                .ConfigureAwait(false); ;
        }
    }
}
