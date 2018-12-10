using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AwesomeApp.Models;

namespace AwesomeApp.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id){
            var model = new ArticleViewModel{
              Id = 1,
              Name = "DevOps"  
            };
            return View(model);
        }
    }
}