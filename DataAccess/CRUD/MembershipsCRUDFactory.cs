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
    public class MembershipsCRUDFactory : CrudFactory
    {
        
        MembershipMapper _mapper;

        public MembershipsCRUDFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new MembershipMapper();
        }

        public override void Create(BaseDTO dto)
        {
          
            var sqlOperation = _mapper.GetCreateStatement(dto);
           _dao.ExecuteQueryProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO dto)
        {
            var sqlOperation = _mapper.GetDeleteStatement(dto);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {

            var lstMemberships = new List<T>();
            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);
                foreach (var obj in objs)
                {
                    lstMemberships.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstMemberships;

        }

        

        public override T RetrieveById<T>(BaseDTO dto)
        {
            var membership = (Memberships)dto;
            var lstMemberships = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByIDStatement(membership);

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
            var sqlOperation = _mapper.GetUpdateStatement(dto);

            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}
