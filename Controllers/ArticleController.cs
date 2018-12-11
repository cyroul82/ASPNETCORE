using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AwesomeApp.Models;
using AwesomeApp.Services.Article;

namespace AwesomeApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetArticles());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _articleService.GetArticle(id);
            if(model != null){
                return View(model);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _articleService.GetArticle(id);
            if(model != null){
                return View(model);
            }
            return NotFound();
        }

        public IActionResult Add()
        {
            return View("Edit", new ArticleViewModel());
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel article)
        {
            if(!ModelState.IsValid){
                return View("Edit", article);
            }

            if(article.Id != 0) {
                _articleService.SaveArticle(article);
            }
            else {
                _articleService.AddArticle(article);
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}