using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace QuarterlySales.Models
{
    public class User : IdentityUser
    {
        //
        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
   
}
