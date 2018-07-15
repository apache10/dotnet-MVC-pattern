using System;
using ExploreCali.Models;
using Microsoft.AspNetCore.Mvc;
namespace ExploreCali.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialViewComponent :ViewComponent
    {
        private readonly SpecialDataContext _special;
        public MonthlySpecialViewComponent(SpecialDataContext special){
            _special = special;
        }
        public IViewComponentResult Invoke()
        {
            var special = _special.GetMonthlySpecial();
            return View(special);
        }
    }
}
