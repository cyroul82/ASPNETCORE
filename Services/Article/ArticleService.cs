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
                string sql = @"UPDATE Article set name=@name, imagepath=@imagepath, isbn=@isbn, description=@description, url=@url, email=@email, date=@date, price=@price where id=@id";
                
                var item = await c.ExecuteAsync(sql, new { 
                    isbn = article.ISBN, 
                    name = article.Name, 
                    description = article.Description, 
                    url = article.Url, 
                    imagepath = article.ImagePath,
                    email = article.Email,
                    price = article.Price,
                    date = article.Date,
                    id = article.Id,

                    });
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

        public async Task AddArticle(ArticleViewModel article)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                string sql = @"insert into Article (isbn, name, email, description, url, imagepath, price, date) VALUES (@isbn, @name, @email, @description, @url, @imagepath, @price, @date)";
                // var t = await c.Database.Insert(new ArticleViewModel { 
                //     ISBN = article.ISBN, 
                //     Name = article.Name, 
                //     Description = article.Description, 
                //     Url = article.Url, 
                //     ImagePath = article.ImagePath,
                //     Email = article.Email,
                //     Price = article.Price,
                //     Date = article.Date,

                //     });
                var item = await c.ExecuteAsync(sql, new { 
                    isbn = article.ISBN, 
                    name = article.Name, 
                    description = article.Description,  
                    url = article.Url, 
                    imagepath = article.ImagePath,
                    email = article.Email,
                    date = article.Date,
                    price = article.Price
                    });
            }
        }
    }
}