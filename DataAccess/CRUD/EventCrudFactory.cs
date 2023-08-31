using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class EventCrudFactory : CrudFactory
    {
        EventMapper _mapper;

        public EventCrudFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new EventMapper();
        }

        #region"Events"
        public override void Create(BaseDTO dto)
        {
            var eevent = (Event)dto;

            var sqlOperation = _mapper.GetCreateStatement(eevent);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            var eevent = (Event)dto;

            var sqlOperation = _mapper.GetDeleteStatement(eevent);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstEvents = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);

                foreach ( var obj in objs )
                { 
                    lstEvents.Add((T)Convert.ChangeType(obj, typeof(T)));
                } 
            }
            return lstEvents;
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            var eevent = (Event)dto;
            var lstEvents = new List<T>();

            var sqlOperation = _mapper.GetRetrieveByIDStatement(eevent);

            var result = _dao.ExecuteQueryProcedure(sqlOperation); ;

            if (result.Count > 0)
            {
                var objs = _mapper.BuildObjects(result);
                foreach (var obj in objs)
                {
                    lstEvents.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            if (result.Count > 0) 
            {
                return lstEvents[0];
            }

            return default(T);
        }


        public override void Update(BaseDTO dto)
        {
            var eevent = (Event)dto;

            var sqlOperation = _mapper.GetUpdateStatement(eevent);

            _dao.ExecuteProcedure(sqlOperation);
        }
        #endregion

        #region"Contacts"

        public void AddContactToEvent(Contact contact)
        {
            var sqlOperation = _mapper.GetAddContactToEvent(contact);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAllContactToEvent<T>(int idEvent)
        {
            var lstContacts = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllContactToEvent(idEvent);

            var lstResults = _dao.ExecuteQueryProcedure( sqlOperation );

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildContactObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstContacts.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstContacts;
        }

        public void DeleteContactToEvent(Contact contact)
        {
            var sqlOperation = _mapper.GetDeleteContactToEvent(contact);
            _dao.ExecuteProcedure(sqlOperation);
        }

        #endregion

        #region"Category"
        public void AddCategoryToEvent(int idCategory, int idEvent)
        {
            var sqlOperation = _mapper.GetAddCategoryToEvent(idCategory, idEvent);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void DeleteCategoryToEvent(int idCategory,int idEvent)
        {
            var sqlOperation = _mapper.GetDeleteCategoryToEvent(idCategory, idEvent);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAllCategoryToEvent<T>(int idEvent)
        {
            var lstCategory = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllCategoryToEvent(idEvent);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjectsCategory(lstResults);

                foreach (var obj in objs)
                {
                    lstCategory.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstCategory;
        }
        #endregion

        #region"Images"
        public void AddImageToEvent(Image image)
        {
            var sqlOperation = _mapper.GetCreateImageToEvent(image);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void DeleteImageToEvent(Image image)
        {
            var sqlOperation = _mapper.GetDeleteImageToEvent(image);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAllImageToEvent<T>(Image image)
        {
            var lstImages = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllImagesToEvent(image);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildImages(lstResults);

                foreach (var obj in objs)
                {
                    lstImages.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstImages;
        }
        #endregion

        #region"Groups"
        public void AddGroupToEvent(int idGroup, int idEvent)
        {
            var sqlOperation = _mapper.GetAddGroupToEvent(idGroup, idEvent);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void DeleteGroupToEvent(int idGroup, int idEvent)
        {
            var sqlOperation = _mapper.GetDeleteGroupToEvent(idGroup, idEvent);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAllGroupsForEvent<T>(int idGroup)
        {
            var lstGroups = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllGroupsToEvent(idGroup);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstGroups.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstGroups;
        }

        #endregion

        #region"Scenery"

        public void AddSceneryToEvent( int idEvent, int idScenery)
        {
            var sqlOperation = _mapper.GetAddSceneryToEvent( idEvent, idScenery);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void DeleteSceneryToEvent( int idEvent, int idScenery)
        {
            var sqlOperation = _mapper.GetDeleteSceneryToEvent(idEvent, idScenery);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveSceneryToEvent<T>(int idEvent)
        {
            var lstSceneries = new List<T>();

            var sqlOperation = _mapper.GetRetrieveAllSceneryToEvent(idEvent);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjectsScenery(lstResults);

                foreach ( var obj in objs) {
                    lstSceneries.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstSceneries;
        }


        #endregion
    }
}
