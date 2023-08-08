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
        public List<Brand> get_Brands()
        {
            List<Brand> list = new List<Brand>();
            try
            {
                data.Query("SELECT Id, Name FROM Brand_Table;");
                data.Read();
                while (data.readerProp.Read())
                {
                    Brand aux_Brand= new Brand();
                    aux_Brand.Id = (int)data.readerProp["Id"];
                    aux_Brand.Name = (string)data.readerProp["Name"];
                    list.Add(aux_Brand);
                }
                return list;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}