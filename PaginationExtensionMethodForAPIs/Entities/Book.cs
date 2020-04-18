using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs.Entities
{
    public class Book
    {   
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(150)]
        public string Author { get; set; }
        [Required]
        [MaxLength(150)]
        public string Publisher { get; set; }
        [Required]
        public int NumberOfPages { get; set; }
    }
}
