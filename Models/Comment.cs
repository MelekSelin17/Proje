using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
