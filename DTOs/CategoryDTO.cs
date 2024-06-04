using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required, MaxLength(20, ErrorMessage = "שם הקטגוריה הוא עד 20 תווים")]

        public string? CategoryName { get; set; } = null!;

        
    }
}
