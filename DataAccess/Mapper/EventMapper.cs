using DataAccess.DAO;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class EventMapper : ISqlStatements, IObjectMapper
    {
        #region"IObjectMapper"

        #region"Events"
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var eventDTO = new Event
            {
                Id = (int)row["IdEvent"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                Slogan = row["Slogan"] != DBNull.Value ? (string)row["Slogan"] : string.Empty,
                Description = row["Description"] != DBNull.Value ? (string)row["Description"] : string.Empty,
                Modality = row["Modality"] != DBNull.Value ? (string)row["Modality"] : string.Empty,
                EventDate = row["EventDate"] != DBNull.Value ? (string)row["EventDate"] : string.Empty,
                TotalTickets = row["TotalTickets"] != DBNull.Value ? (int)row["TotalTickets"] : 0,
                Information = row["Information"] != DBNull.Value ? (string)row["Information"] : string.Empty,
                PaymentMethod = row["PaymentMethod"] != DBNull.Value ? (string)row["PaymentMethod"] : string.Empty,
                FreeTickets = row["FreeTickets"] != DBNull.Value ? (int)row["FreeTickets"] : 0,
                OwnedBy = row["OwnedBy"] != DBNull.Value ? (int)row["OwnedBy"] : 0,
                State = row["State"] != DBNull.Value ? (string)row["State"] : string.Empty,
            };

            return eventDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var eventDTO = BuildObject(item);
                lstResults.Add(eventDTO);
            }

            return lstResults;
        }
        #endregion

        #region"Contacts"

        public Contact BuildContactObject(Dictionary<string, object> row)
        {
            var contact = new Contact
            {
                IdEvent = (int)row["IdEvent"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                TextContact = row["Contact"] != DBNull.Value ? (string)row["Contact"] : string.Empty
            };

            return contact;
        }

        public List<Contact> BuildContactObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<Contact>();

            foreach (var item in lstRows)
            {
                var contact = BuildContactObject(item);
                lstResults.Add(contact);
            }

            return lstResults;
        }

        #endregion

        #region"Category"
        public BaseDTO BuildObjectCategory(Dictionary<string, object> row)
        {
            var categoryDTO = new Category
            {
                Id = (int)row["IdCategory"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty
            };

            return categoryDTO;
        }

        public List<BaseDTO> BuildObjectsCategory(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var categoryDTO = BuildObjectCategory(item);
                lstResults.Add(categoryDTO);
            }

            return lstResults;
        }
        #endregion

        #region"Images"
        public Image BuildImage(Dictionary<string, object> row)
        {
            var imageDTO = new Image
            {
                Id = (int)row["IdImage"],
                IdEvent = (int)row["IdEvent"],
                URL = row["URL"] != DBNull.Value ? (string)row["URL"] : string.Empty,
            };

            return imageDTO;
        }

        public List<Image> BuildImages(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<Image>();

            foreach (var item in lstRows)
            {
                var imageDTO = BuildImage(item);
                lstResults.Add(imageDTO);
            }

            return lstResults;
        }
        #endregion

        #region"Scenery"
        public BaseDTO BuildObjectScenery(Dictionary<string, object> row)
        {
            var sceneryDTO = new Scenery
            {
                Id = (int)row["IdScenery"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                Location = row["Location"] != DBNull.Value ? (string)row["Location"] : string.Empty
            };

            return sceneryDTO;
        }

        public List<BaseDTO> BuildObjectsScenery(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var sceneryDTO = BuildObjectScenery(item);
                lstResults.Add(sceneryDTO);
            }

            return lstResults;
        }
        #endregion

        #endregion

        #region"ISqlStatements"

        #region"Events"
        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_PR";

            var eevent = (Event)dto;

            sqlOperation.AddVarcharParam("P_NAME", eevent.Name);
            sqlOperation.AddVarcharParam("P_SLOGAN", eevent.Slogan);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", eevent.Description);
            sqlOperation.AddVarcharParam("P_MODALITY", eevent.Modality);
            sqlOperation.AddVarcharParam("P_EVENTDATE", eevent.EventDate.ToString());
            sqlOperation.AddIntParam("P_TOTALTICKETS", eevent.TotalTickets);
            sqlOperation.AddVarcharParam("P_INFORMATION", eevent.Information);
            sqlOperation.AddVarcharParam("P_PAYMENTMETHOD", eevent.PaymentMethod);
            sqlOperation.AddIntParam("P_FREETICKETS", eevent.FreeTickets);
            sqlOperation.AddIntParam("P_OWNEDBY", eevent.OwnedBy);
            sqlOperation.AddVarcharParam("P_STATE", eevent.State);

            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_PR";

            var eevent = (Event)dto;

            sqlOperation.AddIntParam("P_IDEVENT", eevent.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENTS_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ID_EVENTS_PR";

            var eevent = (Event)dto;

            sqlOperation.AddVarcharParam("@P_NAME",eevent.Name);
            sqlOperation.AddVarcharParam("@P_SLOGAN", eevent.Slogan);
            sqlOperation.AddVarcharParam("@P_DESCRIPTION", eevent.Description);
            sqlOperation.AddVarcharParam("@P_INFORMATION", eevent.Information);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_EVENT_PR";

            var eevent = (Event)dto;


            sqlOperation.AddIntParam("P_IDEVENT", eevent.Id); 
            sqlOperation.AddVarcharParam("P_NAME", eevent.Name);
            sqlOperation.AddVarcharParam("P_SLOGAN", eevent.Slogan);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", eevent.Description);
            sqlOperation.AddVarcharParam("P_MODALITY", eevent.Modality);
            sqlOperation.AddVarcharParam("P_EVENTDATE", eevent.EventDate);
            sqlOperation.AddIntParam("P_TOTALTICKETS", eevent.TotalTickets);
            sqlOperation.AddVarcharParam("P_INFORMATION", eevent.Information);
            sqlOperation.AddVarcharParam("P_PAYMENTMETHOD", eevent.PaymentMethod);
            sqlOperation.AddIntParam("P_FREETICKETS", eevent.FreeTickets);
            sqlOperation.AddIntParam("P_OWNEDBY", eevent.OwnedBy);
            sqlOperation.AddVarcharParam("P_STATE", eevent.State);

            return sqlOperation;
        }
        #endregion

        #region"Contacts"

        public SQLOperation GetAddContactToEvent(Contact contact)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_CONTACT_PR";

            sqlOperation.AddIntParam("P_IDEVENT", contact.IdEvent);
            sqlOperation.AddVarcharParam("P_NAME", contact.Name);
            sqlOperation.AddVarcharParam("P_CONTACT", contact.TextContact);
           
            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllContactToEvent(int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENT_CONTACT_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);

            return sqlOperation;
        }

        public SQLOperation GetDeleteContactToEvent(Contact contact)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_CONTACT_PR";

            sqlOperation.AddIntParam("P_IDEVENT", contact.IdEvent);
            sqlOperation.AddVarcharParam("P_NAME", contact.Name);
            sqlOperation.AddVarcharParam("P_CONTACT", contact.TextContact);

            return sqlOperation;
        }

        #endregion

        #region"Category"
        public SQLOperation GetAddCategoryToEvent(int idCategory,int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_CATEGORY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDCATEGORY", idCategory);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllCategoryToEvent(int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENT_CATEGORY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);

            return sqlOperation;
        }

        public SQLOperation GetDeleteCategoryToEvent(int idCategory, int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_CATEGORY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDCATEGORY", idCategory);

            return sqlOperation;
        }
        #endregion

        #region"Images"
        public SQLOperation GetCreateImageToEvent(Image image)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_IMAGE_PR";

            sqlOperation.AddIntParam("P_IDEVENT", image.IdEvent);
            sqlOperation.AddVarcharParam("P_URL", image.URL);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllImagesToEvent(Image image)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENT_IMAGE_PR";

            sqlOperation.AddIntParam("P_IDEVENT", image.IdEvent);

            return sqlOperation;
        }

        public SQLOperation GetDeleteImageToEvent(Image image)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_IMAGE_PR";

            sqlOperation.AddIntParam("P_IDEVENT", image.IdEvent);
            sqlOperation.AddIntParam("P_IDIMAGE", image.Id); 

            return sqlOperation;
        }
        #endregion

        #region"Group"
        public SQLOperation GetAddGroupToEvent(int idGroup, int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_GROUP_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDGROUP", idGroup);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllGroupsToEvent(int idGroup)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENT_GROUP_PR";

            sqlOperation.AddIntParam("P_IDGROUP", idGroup);

            return sqlOperation;
        }

        public SQLOperation GetDeleteGroupToEvent(int idGroup, int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_GROUP_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDGROUP", idGroup);

            return sqlOperation;
        }

        #endregion

        #region"Scenery"
        public SQLOperation GetAddSceneryToEvent(int idEvent,int idScenery)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_EVENT_SCENERY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);

            return sqlOperation;
        }

        public SQLOperation GetDeleteSceneryToEvent(int idEvent, int idScenery)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_EVENT_SCENERY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);
            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllSceneryToEvent(int idEvent)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_EVENT_SCENERY_PR";

            sqlOperation.AddIntParam("P_IDEVENT", idEvent);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
