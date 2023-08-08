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
        public List<Category> get_Categories()
        {
            List<Category> list = new List<Category>();
            try
            {
                data.Query("SELECT Id, Name FROM Category_Table;");
                data.Read();
                while (data.readerProp.Read())
                {
                    Category aux_Category = new Category();
                    aux_Category.Id = (int)data.readerProp["Id"];
                    aux_Category.Name = (string)data.readerProp["Name"];
                    list.Add(aux_Category);
                }
                return list;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}