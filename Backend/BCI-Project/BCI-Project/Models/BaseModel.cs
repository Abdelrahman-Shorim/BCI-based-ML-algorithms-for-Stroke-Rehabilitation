using System;
using System.ComponentModel.DataAnnotations;

namespace BCI_Project.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
