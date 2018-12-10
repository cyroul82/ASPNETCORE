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
            var list = new List<ArticleViewModel>();
            var model = new ArticleViewModel {
                 Id = 1,
              Name = "DevOps" 
            };
            list.Add(model);
            model = new ArticleViewModel {
                 Id = 2,
              Name = "Agilité" 
            };
            list.Add(model);
            model = new ArticleViewModel {
                Id = 3,
                Name = "Scrum" 
            };
            list.Add(model);
            return View(list);
        }

        [HttpGet]
        public IActionResult Detail(int id){
            var model = new ArticleViewModel{
              Id = 1,
              Name = "DevOps"  
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id){
            var model = new ArticleViewModel{
              Id = 1,
              Name = "DevOps"  
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel article) {
            return View("Detail", article);
        }
    }
}