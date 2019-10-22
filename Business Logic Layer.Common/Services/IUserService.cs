using Business_Logic_Layer.Common.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Common.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Object</returns>
        Task<UserBL> FindById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns></returns>
        Task<UserBL> FindByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IList<Object></returns>
        Task<IList<UserBL>> FindAll();
    }
}
