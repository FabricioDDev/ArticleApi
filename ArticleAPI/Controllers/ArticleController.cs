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

        // GET api/article/all
        [HttpGet]
        [Route("api/article/all")]
        public HttpResponseMessage Get_Articles()
        {
            List<Article> source = articleDao.get_Articles();
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
        // GET api/article/search_article_by_name
        [HttpGet]
        [Route("api/article/search_article_by_name")]
        public HttpResponseMessage Search_ByName([FromUri] string name)
        {
            List<Article> source = articleDao.get_Articles_ByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }
        // GET api/article/search_by_Id
        [HttpGet]
        [Route("api/article/search_by_Id")]
        public HttpResponseMessage Search_ById([FromUri] int id)
        {
            Article source = articleDao.get_Article_ById(id);
            return Request.CreateResponse(HttpStatusCode.OK, source);
        }

        // PUT api/article/update
        [HttpPut]
        [Route("api/article/update")]
        public HttpResponseMessage update([FromBody] Article article)
        {
            bool answer = articleDao.update_Article(article);
            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }

        // POST api/article/create
        [HttpPost]
        [Route("api/article/create")]
        public HttpResponseMessage Create([FromBody] Article article)
        {
            bool answer = articleDao.create_Article(article);
            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }
        // DELETE api/article/delete
        [HttpDelete]
        [Route("api/article/delete")]
        public HttpResponseMessage delete([FromUri] int id)
        {
            bool answer = articleDao.delete_Article(id);
            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }
    }
}