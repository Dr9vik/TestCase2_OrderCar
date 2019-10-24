using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Common.Model
{
    public class OrderBL
    {
        public virtual Guid Id { get; set; }
        public virtual Guid CarId { get; set; }
        public virtual CarBLCL Car { get; set; }
        public virtual Guid UsertId { get; set; }
        public virtual UserBLCL User { get; set; }
        public virtual string Information { get; set; }

        public virtual DateTimeOffset? TimeStart { get; set; }
        public virtual DateTimeOffset? TimeEnd { get; set; }
    }
    public class OrderBLCreate
    {
        public virtual Guid CarId { get; set; }
        public virtual Guid UsertId { get; set; }
        public virtual string Information { get; set; }

        public virtual DateTimeOffset? TimeStart { get; set; }
        public virtual DateTimeOffset? TimeEnd { get; set; }
    }
    public class OrderBLUpdate
    {
        public virtual Guid Id { get; set; }
        public virtual Guid CarId { get; set; }
        public virtual Guid UsertId { get; set; }
        public virtual string Information { get; set; }

        public virtual DateTimeOffset? TimeStart { get; set; }
        public virtual DateTimeOffset? TimeEnd { get; set; }
    }
}
