using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeApp.Models
{
    [Table("Article")]
    public class ArticleViewModel
    {
        private DateTime _date;

        [Key]   
        public int Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3 ,ErrorMessage = "Oye 30 max")]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}[\d|X]$")]
        public string ISBN { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { 
            get{
                var dt = DateTime.MinValue;
                return _date >= dt ? _date : dt;
            } 
            set {
               _date = value.GetValueOrDefault(); 
            }
        }

        [Range(1, 1000)]
        // [DataType(DataType.Currency)]
        public float? Price { get; set; }
    }
}