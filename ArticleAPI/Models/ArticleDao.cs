using DB;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
            if (String.IsNullOrEmpty(model_name))
                return null;

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
            if(Id < 1) return null;
            try
            {
                data.Query("SELECT A.Id as Id, A.Model as Model,A.Description as Description, A.Url_Img as Url_Image, A.Nro_Model as Nro_Model, B.Id as Id_Brand, B.Name as Brand_Name, C.Id as Cat_Id, C.Name as Cat_Name, G.Id as Id_Gama, G.Name as Gama_Name FROM Article_Table A JOIN Brand_Table B ON A.Id_Brand = B.Id JOIN Category_Table C ON A.Id_Category = C.Id JOIN Gama_Table G ON A.Id_Gama = G.Id where A.Id = " + Id + ";");
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
        public bool update_Article(Article article)
        {
            try
            {
                data.Query("UPDATE Article_Table SET Model = @Model, Nro_Model = @Nro_Model, Id_Brand = @Id_Brand, Id_Category = @Id_Cat, Description = @Description, Url_Img = @Url_Img, Id_Gama = @Id_Gama WHERE Id = @Id;");
                data.Parameters("@Model", article.Model);
                data.Parameters("@Nro_Model", article.nro_Model);
                data.Parameters("@Id_Brand", article.brand.Id);
                data.Parameters("@Id_Cat", article.category.Id);
                data.Parameters("@Description", article.description);
                data.Parameters("@Url_Img", article.url_Image);
                data.Parameters("@Id_Gama", article.gama.Id);
                data.Parameters("@Id", article.id);
                data.Execute();
                return true;
            }catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }
        public bool create_Article(Article article)
        {
            try
            {
                data.Query("INSERT INTO Article_Table VALUES(@Model, @Nro_Model, @Brand_Id, @Id_Cat, @Description, @Url_Image, @Id_Gama)");
                data.Parameters("@Model", article.Model);
                data.Parameters("@Nro_Model", article.nro_Model);
                data.Parameters("@Brand_Id", article.brand.Id);
                data.Parameters("@Id_Cat", article.category.Id);
                data.Parameters("@Description", article.description);
                data.Parameters("@Url_Image", article.url_Image);
                data.Parameters("@Id_Gama", article.gama.Id);
                data.Execute();
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }

        public bool delete_Article(int Id)
        {
            try
            {
                data.Query("DELETE Article_Table WHERE Id = @Id");
                data.Parameters("@Id", Id);
                data.Execute();
                return true;
            }catch(Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}