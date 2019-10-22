using System;

namespace Data_Access_Layer.Common.Models
{
    public class OrderDB
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Secondary key
        /// </summary>
        public virtual Guid CarId { get; set; }
        public virtual CarDB Car { get; set; }

        /// <summary>
        /// Secondary key
        /// </summary>
        public virtual Guid UsertId { get; set; }
        public virtual UserDB User { get; set; }

        /// <summary>
        /// Information
        /// </summary>
        public virtual string Information { get; set; }

        public virtual DateTimeOffset? TimeStart { get; set; }
        public virtual DateTimeOffset? TimeEnd { get; set; }


        public virtual DateTimeOffset? TimeAdd { get; set; }
        public virtual DateTimeOffset? TimeModified { get; set; }
    }
}
