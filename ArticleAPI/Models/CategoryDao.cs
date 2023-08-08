using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleAPI.Models
{
    public class CategoryDao
    {
        public CategoryDao() { data = new DataAccess(); }
        public DataAccess data;
    }
}