using System;

namespace SSP.Order.Domain.Entities.Base
{
    public interface IEntityBase
    {
        public int Id { get; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int UpdatedUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
