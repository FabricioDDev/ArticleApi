﻿using ArticleAPI.Models;
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
        // POST api/article/by_name
        public HttpResponseMessage Post([FromBody] Article art)
        {
            Article source = articleDao.get_Article_ByName(art.Model);
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
    }
}