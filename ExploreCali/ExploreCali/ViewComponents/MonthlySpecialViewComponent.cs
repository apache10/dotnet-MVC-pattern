using System;
using Microsoft.AspNetCore.Mvc;
namespace ExploreCali.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
