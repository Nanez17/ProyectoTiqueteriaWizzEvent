using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class GroupCrudFactory : CrudFactory
    {
        GroupMapper _mapper;
        
        public GroupCrudFactory() 
        {
            _dao = SqlDao.GetInstance();
            _mapper = new GroupMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var group = (Group)dto;

            var sqlOperation = _mapper.GetCreateStatement(group);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            var group = (Group)dto;

            var sqlOperation = _mapper.GetDeleteStatement(group);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstGroups = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstGroups.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstGroups;
        }

      

        public override T RetrieveById<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            var group = (Group)dto;

            var sqlOperation = _mapper.GetUpdateStatement(group);

            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}
