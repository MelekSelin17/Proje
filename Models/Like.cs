using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class Like
    {
        public int Id { get; set; }

        [ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
