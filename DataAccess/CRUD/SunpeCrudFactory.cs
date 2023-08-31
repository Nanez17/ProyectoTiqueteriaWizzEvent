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
    public class SunpeCrudFactory : CrudFactory
    {
        SunpeMapper _mapper;

        public SunpeCrudFactory() 
        {
            _dao = SqlDao.GetInstance();
            _mapper = new SunpeMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var sunpe = dto;

            var sqlOperation = _mapper.GetCreateStatement(sunpe);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public T RetrieveIdSunpe<T>(string transactionId)
        {
            var lstIdSunpe = new List<T>();

            var sqlOperation = _mapper.GetRetrieveIdSunpeStatement(transactionId);

            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                var objs = _mapper.BuildObjects(result);
                foreach (var obj in objs)
                {
                    lstIdSunpe.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            if (result.Count > 0)
            {
                return lstIdSunpe[0];
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
