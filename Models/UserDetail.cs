using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class UserDetail
    {
      
        [Key]
        public int Id { get; set; }
        [ForeignKey("IdentityUser")]
        public int UserId { get; set; }
        public IdentityUser Users { get; set; } 
        public string Description { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comment { get; set; }

    }
}
