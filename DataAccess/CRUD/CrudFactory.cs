using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    {
        protected SqlDao _dao;


        // Definicion de los metodos del CRUD.

        public abstract void Create(BaseDTO dto);
        public abstract T RetrieveById<T>(BaseDTO dto);
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseDTO dto);
        public abstract void Delete(BaseDTO dto);
       


    }
}
