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

        [HttpPost]
        public IActionResult Edit(ArticleViewModel article)
        {
            return View("Detail", article);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}