using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSaleRepository.Persistance.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreateDate = DateTime.UtcNow;
            IsActive = true;
            IsDelete = false;
            Id = 0;
            IdNo = Guid.NewGuid();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0)]
        public virtual long Id { get; set; }

        [Column("IdNo", Order = 1)]
        public virtual Guid IdNo { get; set; }

        public virtual string CreatedAt { get; set; }

        public virtual string UpdatedAt { get; set; }

        public virtual string DeletedAt { get; set; }

        public virtual bool IsActive { get; set; }

        [Column("is_deleted", Order = 110)]
        [DefaultValue("false")]
        public virtual bool IsDelete { get; set; }

        public virtual DateTime? DeletedDate { get; set; }

        public virtual string DeletedBy { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual string CreateBy { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        public virtual string UpdateBy { get; set; }
    }
}