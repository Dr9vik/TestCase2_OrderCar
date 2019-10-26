using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Model.ModelFilter;
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
        Task<OrderBLCL> Create(OrderBLCreate item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">Object</param>
        Task<OrderBLCL> Update(OrderBLUpdate item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Primary key</param>
        Task<string> Delete(Guid id);


        /// <summary>
        /// 
        /// </summary>
        /// <returns>IList<Object></returns>
        Task<IList<OrderBLCL>> FindAll();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IList<Object></returns>
        Task<IList<OrderBLCL>> FindAll(OrderBLFilter filter);
    }
}
