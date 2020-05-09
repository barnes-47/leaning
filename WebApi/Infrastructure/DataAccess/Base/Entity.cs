using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DataAccess.Base
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
