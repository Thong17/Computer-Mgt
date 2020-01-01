using ComMgt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerMgt.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Photo, Product product)
        {
            var filename = Path.GetFileName(Photo.FileName);

            var path = "~/App_Data/Uploads/" + product.Model;

            var rootPath = Server.MapPath(path);

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            

            string uploadPath = Path.Combine(rootPath, filename);

            Photo.SaveAs(uploadPath);

            return View("Index");
        }
    }
}