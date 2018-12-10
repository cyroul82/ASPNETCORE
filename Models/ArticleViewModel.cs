using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}