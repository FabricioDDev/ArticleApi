using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ArticleAPI.Models
{
    public class ArticleDao
    {
        public ArticleDao() {  }
        public DataAccess data = new DataAccess();

        public List<Article> get_Articles()
        {
            List<Article> list = new List<Article>();
            try
            {
                data.Query("SELECT A.Id as Id, A.Model as Model, A.Description as Description, A.Url_Img as Url_Image, A.Nro_Model as Nro_Model, B.Id as Id_Brand, B.Name as Brand_Name, C.Id as Cat_Id, C.Name as Cat_Name, G.Id as Id_Gama, G.Name as Gama_Name FROM Article_Table A JOIN Brand_Table B ON A.Id_Brand = B.Id JOIN Category_Table C ON A.Id_Category = C.Id JOIN Gama_Table G ON A.Id_Gama = G.Id;\r\n");
                data.Read();
                while (data.readerProp.Read())
                {
                    Article aux_Article = new Article();
                    aux_Article.id = (int)data.readerProp["Id"];
                    aux_Article.Model = (string)data.readerProp["Model"];
                    aux_Article.nro_Model = (string)data.readerProp["Nro_Model"];
                    aux_Article.brand.Id = (int)data.readerProp["Id_Brand"];
                    aux_Article.brand.Name = (string)data.readerProp["Brand_Name"];
                    aux_Article.gama.Id = (int)data.readerProp["Id_Gama"];
                    aux_Article.gama.Name = (string)data.readerProp["Gama_Name"];
                    aux_Article.url_Image = (string)data.readerProp["Url_Image"];
                    aux_Article.category.Id = (int)data.readerProp["Cat_Id"];
                    aux_Article.category.Name = (string)data.readerProp["Cat_Name"];
                    aux_Article.description = (string)data.readerProp["Description"];
                    list.Add(aux_Article);
                }
                return list;
            }catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }
        public List<Article> get_Articles_ByName(string model_name)
        {
            List<Article> list = new List<Article>();
            try
            {
                data.Query("SELECT A.Id as Id, A.Model as Model,A.Description as Description, A.Url_Img as Url_Image, A.Nro_Model as Nro_Model, B.Id as Id_Brand, B.Name as Brand_Name, C.Id as Cat_Id, C.Name as Cat_Name, G.Id as Id_Gama, G.Name as Gama_Name FROM Article_Table A JOIN Brand_Table B ON A.Id_Brand = B.Id JOIN Category_Table C ON A.Id_Category = C.Id JOIN Gama_Table G ON A.Id_Gama = G.Id where A.Model LIKE '%" + model_name + "%';");
                data.Read();
                while (data.readerProp.Read())
                {
                    Article aux_Article = new Article();
                    aux_Article.id = (int)data.readerProp["Id"];
                    aux_Article.Model = (string)data.readerProp["Model"];
                    aux_Article.nro_Model = (string)data.readerProp["Nro_Model"];
                    aux_Article.brand.Id = (int)data.readerProp["Id_Brand"];
                    aux_Article.brand.Name = (string)data.readerProp["Brand_Name"];
                    aux_Article.gama.Id = (int)data.readerProp["Id_Gama"];
                    aux_Article.gama.Name = (string)data.readerProp["Gama_Name"];
                    aux_Article.url_Image = (string)data.readerProp["Url_Image"];
                    aux_Article.category.Id = (int)data.readerProp["Cat_Id"];
                    aux_Article.category.Name = (string)data.readerProp["Cat_Name"];
                    aux_Article.description = (string)data.readerProp["Description"];
                    list.Add(aux_Article);
                }
                return list;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
        public Article get_Article_ById(int Id)
        {
            Article article = new Article();
            try
            {
                data.Query("SELECT A.Id as Id, A.Model as Model,A.Description as Description, A.Url_Img as Url_Image, A.Nro_Model as Nro_Model, B.Id as Id_Brand, B.Name as Brand_Name, C.Id as Cat_Id, C.Name as Cat_Name, G.Id as Id_Gama, G.Name as Gama_Name FROM Article_Table A JOIN Brand_Table B ON A.Id_Brand = B.Id JOIN Category_Table C ON A.Id_Category = C.Id JOIN Gama_Table G ON A.Id_Gama = G.Id where A.Id LIKE '%" + Id + "%';");
                data.Read();
                if (data.readerProp.Read())
                {
                    Article aux_Article = new Article();
                    aux_Article.id = (int)data.readerProp["Id"];
                    aux_Article.Model = (string)data.readerProp["Model"];
                    aux_Article.nro_Model = (string)data.readerProp["Nro_Model"];
                    aux_Article.brand.Id = (int)data.readerProp["Id_Brand"];
                    aux_Article.brand.Name = (string)data.readerProp["Brand_Name"];
                    aux_Article.gama.Id = (int)data.readerProp["Id_Gama"];
                    aux_Article.gama.Name = (string)data.readerProp["Gama_Name"];
                    aux_Article.url_Image = (string)data.readerProp["Url_Image"];
                    aux_Article.category.Id = (int)data.readerProp["Cat_Id"];
                    aux_Article.category.Name = (string)data.readerProp["Cat_Name"];
                    aux_Article.description = (string)data.readerProp["Description"];
                    return aux_Article;
                }
                return null;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}