
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeApp.Models;

namespace AwesomeApp.Services.Article
{
    public interface IArticleService
    {
         Task<IEnumerable<ArticleViewModel>> GetArticles();
        Task<ArticleViewModel> GetArticle(int id);

         void EditArticle(ArticleViewModel id);
    }
}