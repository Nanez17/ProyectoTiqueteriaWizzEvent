using DataAccess.CRUD;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GroupManager
    {
        public GroupManager() { }

        public void CreateGroup (Group group)
        {
            var crud = new GroupCrudFactory();
            crud.Create(group);
        }
        public void DeleteGroup(Group group)
        {
            var crud = new GroupCrudFactory();
            crud.Delete(group);        
        }
        public void UpdateGroup(Group group)
        {
            var crud = new GroupCrudFactory();
            crud.Update(group);
        }
        public List<Group> RetrieveAllGroup()
        {
            var crud = new GroupCrudFactory();
            return crud.RetrieveAll<Group>();
        }


    }
}
