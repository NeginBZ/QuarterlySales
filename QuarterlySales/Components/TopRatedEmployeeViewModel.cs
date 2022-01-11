using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;

namespace QuarterlySales.Components
{
    public class TopRatedEmployeeViewModel
    {
        public List<Sales> users { get; set; }

        public int LowestRating { get; set; }

        public int numberOfUsersToDisplay { get; set; }

      
    }
}
