using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleAPI.Models
{
    public class Article
    {
        public Article() { 
            brand= new Brand();
            category= new Category();
            gama = new Gama();
        }
        public int id { get; set; }
        public string Model { get; set; }
        public Brand brand { get; set; }
        public string nro_Model { get; set; }
        public Category category { get; set; }
        public string description { get; set; }
        public string url_Image { get; set; }
        public Gama gama { get; set; }
    }
}