using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? CreatedBy { get; set; }
        protected EntityBase()
        {
        }
    }
}