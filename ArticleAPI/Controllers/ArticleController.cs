using ArticleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArticleAPI.Controllers
{
    public class ArticleController : ApiController
    {
        public ArticleController() { articleDao = new ArticleDao(); }
        public ArticleDao articleDao;

        // GET api/article
        public HttpResponseMessage Get()
        {
            List<Article> source = articleDao.get_Articles();
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
        // GET api/article/search_byName
        public HttpResponseMessage Get([FromBody] Article art, string n = "")
        {
            List<Article> source = articleDao.get_Articles_ByName(art.Model);
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
        // GET api/article/search_byId
        public HttpResponseMessage Get([FromBody] Article art, int x = 0)
        {
            Article source = articleDao.get_Article_ById(art.id);
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
    }
}