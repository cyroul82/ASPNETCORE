using System.Collections.Generic;
using AwesomeApp.Models;
using AwesomeApp.Services.Article;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace AwesomeApp.Services.Article
{
    public class ArticleService : IArticleService
    {
        private static IEnumerable<ArticleViewModel> list = new List<ArticleViewModel>{
            new ArticleViewModel
            {
                Id = 1,
                Name = "DevOps"
            },
             new ArticleViewModel
            {
                Id = 2,
                Name = "Agilité"
            },
            new ArticleViewModel
            {
                Id = 3,
                Name = "Scrum"
            }
        };
        private readonly IDBConnector _dBConnector;

        public ArticleService(IDBConnector dBConnector)
        {
            _dBConnector = dBConnector;

        }

        public void EditArticle(ArticleViewModel article)
        {
            
            var model = list.SingleOrDefault(x => x.Id == article.Id);
            if (model != null)
            {
                model.Name = article.Name;
            }
        }

        public async Task<ArticleViewModel> GetArticle(int id)
        {
            using (var c = _dBConnector.GetIDBConnector()){
                string sql =  @"SELECT * from Article where ID=@id";
                var item = await c.QuerySingleOrDefaultAsync<ArticleViewModel>(sql, new { id });
                return item;
            }
        }

        public async Task<IEnumerable<ArticleViewModel>> GetArticles()
        {
            using (var c = _dBConnector.GetIDBConnector()){
                string sql = @"SELECT * from Article";
                var list = await c.QueryAsync<ArticleViewModel>(sql);
                return list;
            }
        }
    }
}