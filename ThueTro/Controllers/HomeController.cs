using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThueTro.Models;
using ThueTro.ViewModel;

namespace ThueTro.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbcontext;
        public HomeController()
        {
            dbcontext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var viewModel = new ModelQuan
            {
                DiaDiems = dbcontext.DiaDiems.ToList(),

                ListHomePage = dbcontext.NhaTros
                .Take(6).ToList()

                
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}