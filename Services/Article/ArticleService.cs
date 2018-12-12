using System.Collections.Generic;
using AwesomeApp.Models;
using AwesomeApp.Services.Article;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

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
                //string sql = @"UPDATE Article set name=@name, imagepath=@imagepath, isbn=@isbn, description=@description, url=@url, email=@email, date=@date, price=@price where id=@id";

                //var item = await c.ExecuteAsync(sql, new
                //{
                //    isbn = article.ISBN,
                //    name = article.Name,
                //    description = article.Description,
                //    url = article.Url,
                //    imagepath = article.ImagePath,
                //    email = article.Email,
                //    price = article.Price,
                //    date = article.Date,
                //    id = article.Id,

                //});

                c.Update(new ArticleViewModel {
                    Id = article.Id,
                    ISBN = article.ISBN,
                    Name = article.Name,
                    Description = article.Description,
                    Url = article.Url,
                    ImagePath = article.ImagePath,
                    Email = article.Email,
                    Date = article.Date,
                    Price = article.Price
                });
            }
        }

        public async Task<ArticleViewModel> GetArticle(int id)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                //string sql = @"SELECT * from Article where ID=@id";
                //var item = await c.QuerySingleOrDefaultAsync<ArticleViewModel>(sql, new { id });
                //return item;
                return await c.GetAsync<ArticleViewModel>(id);
            }
        }

        public async Task<IEnumerable<ArticleViewModel>> GetArticles()
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                //string sql = @"SELECT * from Article";
                //var list = await c.QueryAsync<ArticleViewModel>(sql);
                //return list;
                return await c.GetAllAsync<ArticleViewModel>();
            }
        }

        public async Task<long> AddArticle(ArticleViewModel article)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                //string sql = @"insert into Article (isbn, name, email, description, url, imagepath, price, date) VALUES (@isbn, @name, @email, @description, @url, @imagepath, @price, @date)";

                //var item = await c.ExecuteAsync(sql, new
                //{
                //    isbn = article.ISBN,
                //    name = article.Name,
                //    description = article.Description,
                //    url = article.Url,
                //    imagepath = article.ImagePath,
                //    email = article.Email,
                //    date = article.Date,
                //    price = article.Price
                //});

                return await c.InsertAsync(new ArticleViewModel
                {
                    ISBN = article.ISBN,
                    Name = article.Name,
                    Description = article.Description,
                    Url = article.Url,
                    ImagePath = article.ImagePath,
                    Email = article.Email,
                    Date = article.Date,
                    Price = article.Price
                });
            }
        }

        public async Task<bool> DeleteArticle(int id)
        {
            using (var c = _dBConnector.GetIDBConnector())
            {
                var isDeleted = await c.DeleteAsync(new ArticleViewModel { Id = id });
                return isDeleted;
                //string sql = @"DELETE FROM Article WHERE id=@id";
                //var item = await c.ExecuteAsync(sql, new { id });

            }
        }
    }
}