using Business_Logic_Layer.Common.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Common.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">Object</param>
        Task<OrderBL> Create(OrderBL item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">Object</param>
        Task<OrderBL> Update(OrderBL item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Primary key</param>
        Task<string> Delete(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Object</returns>
        Task<OrderBL> FindById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns></returns>
        Task<OrderBL> FindByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IList<Object></returns>
        Task<IList<OrderBL>> FindAll();
    }
}
