
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeApp.Models;

namespace AwesomeApp.Services.Article
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> GetArticles();
        Task<ArticleViewModel> GetArticle(int id);
        Task SaveArticle(ArticleViewModel article);
        Task<long> AddArticle(ArticleViewModel article);
        Task<bool> DeleteArticle(int id);
    }
}