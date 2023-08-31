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
    public class VentaTotalCRUD : CrudFactory
    {


        VentaMapper _mapper;

        public VentaTotalCRUD()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new VentaMapper();
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
            throw new NotImplementedException();
        }
    }
}
