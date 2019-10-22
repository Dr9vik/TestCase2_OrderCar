using System;
using System.Collections.Generic;

namespace Business_Logic_Layer.Common.Model
{
    public class CarBL
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Model { get; set; }
        public virtual string Class { get; set; }
        public virtual DateTime DateRelease { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual IList<OrderBL> Orders { get; set; }
    }
}
