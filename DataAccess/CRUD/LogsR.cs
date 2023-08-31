using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class LogsR : CrudFactory
    {

        LogsMapper _mapper;

        public LogsR()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new LogsMapper();
        }
        public override void Create(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

       

        public override List<T> RetrieveAll<T>()
        {

            var lstLogs = new List<T>();
            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);
                foreach (var obj in objs)
                {
                    lstLogs.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstLogs;
        }

      

        public override T RetrieveById<T>(BaseDTO dto)
        {

            var log = (Logs)dto;
            var lstMemberships = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByIDStatement(log);

            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                var objs = _mapper.BuildObjects(result);
                foreach (var obj in objs)
                {
                    lstMemberships.Add((T)Convert.ChangeType(obj, typeof(T)));
                }

            }
            if (lstMemberships.Count > 0)
            {
                return lstMemberships[0]; // Return the first element of lstMessages
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
