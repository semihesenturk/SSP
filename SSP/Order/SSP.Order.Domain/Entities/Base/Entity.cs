using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSP.Order.Domain.Entities.Base
{
    public abstract class Entity : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int UpdatedUserId { get; set; }
        public bool IsActive { get; set; }

        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }

        public Entity()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
