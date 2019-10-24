using System;
using System.Collections.Generic;

namespace Business_Logic_Layer.Common.Model
{
    public class UserBL
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string NumberDL { get; set; }
        public virtual IList<OrderBL> Orders { get; set; }
    }
    public class UserBLCL
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string NumberDL { get; set; }
    }
}
