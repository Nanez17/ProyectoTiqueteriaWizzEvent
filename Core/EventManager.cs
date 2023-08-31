using DTOs.Events;
using DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Core
{
    public class EventManager
    {
        public EventManager() { }
        #region"Events"
        public void CreateEvent(Event eevent)
        {
            var crud = new EventCrudFactory();
            crud.Create(eevent);
        }

        public List<Event> RetrieveAllEvent()
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveAll<Event>();
        }

        public Event RetrieveByIdEvent(Event eevent)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveById<Event>(eevent);
        }

        public void UpdateEvent(Event eevent)
        {
            var crud = new EventCrudFactory();
            crud.Update(eevent);
        }

        public void DeleteEvent(Event eevent)
        {
            var crud = new EventCrudFactory();
            crud.Delete(eevent);
        }
        #endregion

        #region"Contacts"
        public void AddContactToEvent(Contact contact)
        {
            var crud = new EventCrudFactory();
            crud.AddContactToEvent(contact);
        }

        public List<Contact> RetrieveAllContactToEvent(int idEvent)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveAllContactToEvent<Contact>(idEvent);
        }

        public void DeleteContactToEvent(Contact contact)
        {
            var crud = new EventCrudFactory();
            crud.DeleteContactToEvent(contact);

        }
        #endregion

        #region"Category"
        public void AddCategoryToEvent(int idCategory, int idEvent)
        {
            var crud = new EventCrudFactory();
            crud.AddCategoryToEvent(idCategory, idEvent);
        }

        public void DeleteCategoryToEvent(int idCategory, int idEvent)
        {
            var crud = new EventCrudFactory();
            crud.DeleteCategoryToEvent(idCategory, idEvent);
        }

        public List<Category> RetrieveAllCategoryToEvent(int idEvent)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveAllCategoryToEvent<Category>(idEvent);
        }


        #endregion

        #region"Images"
        public void AddImageToEvent(Image image)
        {
            var crud = new EventCrudFactory();
            crud.AddImageToEvent(image);
        }

        public void DeleteImageToEvent(Image image)
        {
            var crud = new EventCrudFactory();
            crud.DeleteImageToEvent(image);
        }

        public List<Image> RetrieveAllImageToEvent(Image image)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveAllImageToEvent<Image>(image);
        }

        #endregion

        #region"Group"
        public void AddGroupToEvent(int idEvent, int idGroup)
        {
            var crud = new EventCrudFactory();
            crud.AddGroupToEvent(idGroup,idEvent);
        }

        public List<Event> RetrieveAllGroupsForEvent(int idGroup)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveAllGroupsForEvent<Event>(idGroup);
        }

        public void DeleteGroupFromEvent(int idEvent, int idGroup)
        {
            var crud = new EventCrudFactory();
            crud.DeleteGroupToEvent(idGroup,idEvent);
        }
        #endregion

        #region"Scenery"
        public void AddSceneryToEvent(int idEvent, int idScenery)
        {
            var crud = new EventCrudFactory();
            crud.AddSceneryToEvent(idEvent,idScenery);
        }

        public List<Scenery> RetrieveSceneryToEvent(int idEvent)
        {
            var crud = new EventCrudFactory();
            return crud.RetrieveSceneryToEvent<Scenery>(idEvent);
        }

        public void DeleteSceneryToEvent(int idEvent, int idScenery)
        {
            var crud = new EventCrudFactory();
            crud.DeleteSceneryToEvent(idEvent, idScenery);
        }
        #endregion
    }
}
