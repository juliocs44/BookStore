using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIBookStore.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository bookRepo;

        public HomeController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            bookRepo = new BookRepository(connStr);
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView(bookRepo.GetBooks());
        }
    }
}