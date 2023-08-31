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
    public class UserManager
    {
        public void Create(User user)
        {
            var mm = new UserCRUDFactory();
            mm.Create(user);
        }
        public void CreateGE(User user)
        {
            var mm = new UserCRUDFactory();
            mm.CreateGE(user);
        }

        public void Update(User user)
        {
            var mm = new UserCRUDFactory();
            mm.Update(user);
        }

        public void UpdatePassword(string email,string password)
        {
            var mm = new UserCRUDFactory();
            mm.UpdatePassword(email,password);
        }

        public void Delete(User user)
        {
            var mm = new UserCRUDFactory();
            mm.Delete(user);
        }

        public List<User> RetrieveAll()
        {
            var mm = new UserCRUDFactory();
            return mm.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            var ucrud = new UserCRUDFactory();
            return ucrud.RetrieveById<User>(user);
        }

        public User RetrieveByEmailAndPassword(string email, string password)
        {
            var user = new User { Email = email, Password = password };
            var ucrud = new UserCRUDFactory();
            return ucrud.RetrieveByEmailAndPassword<User>(user);
        }
        public User RetrieveByEmail(string email)
        {
           
            var ucrud = new UserCRUDFactory();
            return ucrud.RetrieveByEmail<User>(email);
        }
    }


}