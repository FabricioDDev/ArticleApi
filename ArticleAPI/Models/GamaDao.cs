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

        public List<Gama> get_Gamas()
        {
            List<Gama> list = new List<Gama>();
            try
            {
                data.Query("SELECT Id, Name FROM Gama_Table;");
                data.Read();
                while (data.readerProp.Read())
                {
                    Gama aux_Gama = new Gama();
                    aux_Gama.Id = (int)data.readerProp["Id"];
                    aux_Gama.Name = (string)data.readerProp["Name"];
                    list.Add(aux_Gama);
                }
                return list;
            }
            catch (Exception ex) { throw ex; }
            finally { data.Close(); }
        }
    }
}