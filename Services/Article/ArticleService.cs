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
        private readonly IDBConnector _dBConnector;

        public ArticleService(IDBConnector dBConnector)
        {
            _dBConnector = dBConnector;
        }

        public async Task SaveArticle(ArticleViewModel article)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                string sql = @"UPDATE Article set name=@name, imagepath=@imagepath where id=@id";
                var item = await c.QuerySingleOrDefaultAsync<ArticleViewModel>(sql, new { id=article.Id, name=article.Name, imagepath=article.ImagePath });
                if (item != null)
                {
                    item.Name = article.Name;
                    item.ImagePath = article.ImagePath;
                }
                

            }
        }

        public async Task<ArticleViewModel> GetArticle(int id)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                string sql = @"SELECT * from Article where ID=@id";
                var item = await c.QuerySingleOrDefaultAsync<ArticleViewModel>(sql, new { id });
                return item;
            }
        }

        public async Task<IEnumerable<ArticleViewModel>> GetArticles()
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                string sql = @"SELECT * from Article";
                var list = await c.QueryAsync<ArticleViewModel>(sql);
                return list;
            }
        }
    }
}