using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB
{
    public class DataAccess
    {
        public DataAccess()
        {
            connection = new SqlConnection("server= DESKTOP-J1JBL3C\\SQLEXPRESS; database=Articles_DB; integrated security = true");
            command = new SqlCommand();
        }
        //Attributes
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        //Properties
        public SqlDataReader readerProp
        {
            get { return reader; }
        }
        //Methods
        public void Query(string query)
        {
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query;
            }
            catch (Exception ex) { throw ex; }
        }
        public void Read()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex) { throw ex; }

        }
        public void Parameters(string parameter, object value)
        {
            try
            {

                command.Parameters.AddWithValue(parameter, value);
            }
            catch (Exception ex) { throw ex; }
        }
        public void clearParameter()
        {
            command.Parameters.Clear();
        }
        public void Execute()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }
        public void SP(string SP)
        {
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = SP;
            }
            catch (Exception ex) { throw ex; }
        }
        public void Close()
        {
            try
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
