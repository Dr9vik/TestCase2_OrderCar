using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Common.Models
{
    public class UserDB
    {
         /// <summary>
        /// Primary key
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Birthday user
        /// </summary>
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// Number driving license
        /// </summary>
        public virtual string NumberDL { get; set; }

        /// <summary>
        /// Shop+products
        /// </summary>
        public virtual IList<OrderDB> Orders { get; set; }

        public virtual DateTimeOffset? TimeAdd { get; set; }
        public virtual DateTimeOffset? TimeModified { get; set; }
    }
}
