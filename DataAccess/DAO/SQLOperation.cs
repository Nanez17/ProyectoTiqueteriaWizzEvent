using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SQLOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SQLOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));

        }

        public void AddIntParam(string paramName, int paramValue)
        {

            Parameters.Add(new SqlParameter(paramName, paramValue));

        }

        public void AddPictureParam(string paramName, byte[] paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddFloatParam(string paramName, float paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

    }
}
