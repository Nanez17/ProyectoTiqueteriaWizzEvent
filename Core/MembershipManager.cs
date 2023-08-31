using DataAccess;
using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    public class MembershipManager
    {
        public void Create(Memberships membership)
        {
            var mm = new MembershipsCRUDFactory();
            mm.Create(membership);
        }

        public void Update(Memberships membership)
        {
            var mm = new MembershipsCRUDFactory();
            mm.Update(membership);
        }
        public void Delete(Memberships membership)
        {
            var mm = new MembershipsCRUDFactory();
            mm.Delete(membership);
        }
        public void RetrieveAll(Memberships membership) { }
        public List<Memberships> RetrieveAll()
        {
            var mm = new MembershipsCRUDFactory();
            return mm.RetrieveAll<Memberships>();
        }
        public Memberships RetrieveByID(Memberships membership)
        {
            var id = membership.Id;
            var mcrud = new MembershipsCRUDFactory();
            return mcrud.RetrieveById<Memberships>(membership);
        }

    }
}
