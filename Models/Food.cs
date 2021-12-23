using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Fiyat { get; set; }



        [ForeignKey("FoodCategory")]
        public int FoodCategoryId { get; set; }
        public  FoodCategory FoodCategory { get; set; }

    }
}
