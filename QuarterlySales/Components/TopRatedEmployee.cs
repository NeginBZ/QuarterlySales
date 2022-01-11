using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Components
{
    public class TopRatedEmployee : ViewComponent
    {
        public TopRatedEmployee(SalesContext saleContext)
        {
            _saleContext = saleContext;
        }

        public IViewComponentResult Invoke(int lowestRating, int numberOfUsersToDisplay)
        {
            // query for Users whose rating is at or above "lowestRating":
            var s = _saleContext.Sales.OrderBy(m => m.Amount).ToList();

            var viewModel = new TopRatedEmployeeViewModel() { users = s, LowestRating = lowestRating, numberOfUsersToDisplay = Math.Min(s.Count, 3) };

            return View(viewModel);
        }

        private SalesContext _saleContext;
    }
}
