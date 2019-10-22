using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Common.Models
{
    public class CarDB
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        public virtual string Model { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual string Class { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual DateTime DateRelease{ get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual string RegistrationNumber { get; set; }

        /// <summary>
        /// Shop+products
        /// </summary>
        public virtual IList<OrderDB> Orders { get; set; }


        public virtual DateTimeOffset? TimeAdd { get; set; }
        public virtual DateTimeOffset? TimeModified { get; set; }
    }
}
