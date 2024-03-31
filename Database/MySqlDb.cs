using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Database
{
    public class MySqlDb : IDisposable
    {
        private MySqlConnection _conn;
        private readonly string _connectionString;

        private void Connection() 
        {
            _conn = new MySqlConnection(_connectionString);
            try
            {
                _conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void AddParameters(MySqlCommand cmd, SqlParameter[] parameters)
        {
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                }
            }
        }

        public MySqlDb(string connectionString)
        {
            _connectionString = connectionString;
            Connection();
        }

        public IDataReader GetReader(string query)
        {
            return GetReader(query, null);
        }

        public IDataReader GetReader(string query, SqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            AddParameters(cmd, parameters);
            return cmd.ExecuteReader();
        }

        public DataTable GetDataTable(string query)
        {
            return GetDataTable(query, null);
        }

        public DataTable GetDataTable(string query, SqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            AddParameters(cmd, parameters);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public long Execute(string query)
        {
            return Execute(query, null);
        }

        public long Execute(string query, SqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            AddParameters(cmd, parameters);
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public void Dispose()
        {
            _conn?.Close();
            _conn?.Dispose();
            _conn = null;
        }
    }
}
