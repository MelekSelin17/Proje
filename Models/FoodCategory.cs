using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class FoodCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}
