using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleAPI.Models
{
    public class GamaDao
    {
        public GamaDao() { data = new DataAccess(); }
        public DataAccess data;
    }
}