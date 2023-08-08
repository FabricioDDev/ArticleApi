using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB;

namespace ArticleAPI.Models
{
    public class BrandDao
    {
        public BrandDao() { data = new DataAccess(); }
        public DataAccess data;

    }
}