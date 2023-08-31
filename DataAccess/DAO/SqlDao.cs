using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

    /*
     * Clase que se encarga de comunicarse con la bd y ejecuta las sentencias
     * o Store Procedures, unica clase con esta habilidad.
     * Utiliza el patron del Singleton
     */
    public class SqlDao
    {
        private static SqlDao _instance;

        private string _connectionString = "";

        private SqlDao()
        {
            _connectionString = "Data Source=srv-db-rquirosar.database.windows.net;Initial Catalog=srv-db-eventwizz;Persist Security Info=True;User ID=sysman;Password=Cenfotec123!";
        }

        public static SqlDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlDao();
            }
            return _instance;
        }

        public void ExecuteProcedure(SQLOperation sqlOperation)
        {

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    foreach (var param in sqlOperation.Parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }
    
    

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SQLOperation sqlOperation)
        {

            var lstResult = new List<Dictionary<string, object>>();


            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    foreach (var param in sqlOperation.Parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    conn.Open();
                    //proceso de extraccion de la data
                    var reader = cmd.ExecuteReader();

                    //validamos que retorne resultados
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for(var index=0; index<reader.FieldCount; index++)
                            {

                                var key = reader.GetName(index);
                                var value = reader.GetValue(index);
                                row[key] = value;
 
                            }

                            lstResult.Add(row);
                        }
                    }
                }

            }

            return lstResult;


        }
    }
}


