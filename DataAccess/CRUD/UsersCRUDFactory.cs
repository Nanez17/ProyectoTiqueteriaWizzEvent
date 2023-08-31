using DataAccess.CRUD;
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
    public class UserCRUDFactory : CrudFactory
    {
        UserMapper _mapper;

        public UserCRUDFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new UserMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var sqlOperation = _mapper.GetCreateStatement(dto);
            _dao.ExecuteQueryProcedure(sqlOperation);
        }
        public void CreateGE(BaseDTO dto)
        {
            var sqlOperation = _mapper.GetCreateGEStatement(dto);
            _dao.ExecuteQueryProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            var sqlOperation = _mapper.GetDeleteStatement(dto);
            _dao.ExecuteProcedure(sqlOperation);
        }


        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();
            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);
                foreach (var obj in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstUsers;
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            var user = (User)dto;
            var lstUsers = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByIDStatement(user);

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
            var sqlOperation = _mapper.GetUpdateStatement(dto);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public T RetrieveByEmailAndPassword<T>(BaseDTO dto)
        {
            var user = (User)dto;
            var lstUsers = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByEmailAndPassword(user);

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

        public T RetrieveByEmail<T>(string email)
        {
           
            var lstUsers = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByEmail(email);

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

        public void UpdatePassword(string email, string password)
        {
            var sqlOperation = _mapper.GetUpdatePasswordStatement(email, password);
            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}
