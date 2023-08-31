using DataAccess.CRUD;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CategoryManager
    {
        public CategoryManager() { }

        public void CreateCategory(Category category)
        {
            var crud = new CategoryCrudFactory();
            crud.Create(category);
        }

        public void UpdateCategory(Category category)
        {
            var crud = new CategoryCrudFactory();
            crud.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            var crud = new CategoryCrudFactory();
            crud.Delete(category);
        }

        public List<Category> RetrieveAllCategories() 
        {
            var crud = new CategoryCrudFactory();
            return crud.RetrieveAll<Category>();
        }
    }
}
