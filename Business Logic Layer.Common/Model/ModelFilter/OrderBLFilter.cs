using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Common.Model.ModelFilter
{
    public class OrderBLFilter
    {
        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual string NameUser { get; set; }
        public virtual string NameCar { get; set; }
        public virtual string ModelCar { get; set; }
    }
}
