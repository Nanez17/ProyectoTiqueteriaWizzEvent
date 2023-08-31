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
    public class RolesCRUD : CrudFactory
    {

        RolesMapper _mapper;

        public RolesCRUD()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new RolesMapper();
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
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            var role = (Roles)dto;
            var lstUsers = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByIDStatement(role);

            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                var objs = _mapper.BuildObjects(result);
                foreach (var obj in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            if (lstUsers.Count > 0)
            {
                return lstUsers[0];
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
