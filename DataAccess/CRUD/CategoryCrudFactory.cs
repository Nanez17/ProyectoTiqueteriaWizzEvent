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
    public class CategoryCrudFactory : CrudFactory
    {
        CategoryMapper _mapper;

        public CategoryCrudFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new CategoryMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var category = (Category)dto;

            var sqlOperation = _mapper.GetCreateStatement(category);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            var category = (Category)dto;

            var sqlOperation = _mapper.GetDeleteStatement(category);

            _dao.ExecuteProcedure(sqlOperation);
        }


        public override List<T> RetrieveAll<T>()
        {
            var lstCategories = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstCategories.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstCategories;
        }


        public override T RetrieveById<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            var category = (Category)dto;

            var sqlOperation = _mapper.GetUpdateStatement(category);

            _dao.ExecuteProcedure(sqlOperation);
        }

    }
}
