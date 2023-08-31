using Core;
using DTOs.Events;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        #region"Events"
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> CreateEvent(Event eevent){
            try
            {
                var um = new EventManager();
                um.CreateEvent(eevent);

                return Ok(eevent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllEvents")]
        public async Task<IActionResult> RetrieveAllEvents()
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveAllEvent();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByIdEvent")]
        public async Task<IActionResult> RetrieveByIdEvent(Event eevent)
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveByIdEvent(eevent);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(Event eevent)
        {
            try
            {
                var um = new EventManager();
                um.UpdateEvent(eevent);

                return Ok(eevent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(Event eevent)
        {
            try
            {
                var um = new EventManager();
                um.DeleteEvent(eevent);
                return Ok(eevent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region"Contacts"
        [HttpPost]
        [Route("AddContactToEvent")]
        public async Task<IActionResult> AddContactToEvent(Contact contact)
        {
            try
            {
                var um = new EventManager();
                um.AddContactToEvent(contact);

                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllContactToEvent")]
        public async Task<IActionResult> RetrieveAllContactToEvent(int idEvent)
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveAllContactToEvent(idEvent);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteContactToEvent")]
        public async Task<IActionResult> DeleteContactToEvent(Contact contact)
        {
            try
            {
                var um = new EventManager();
                um.DeleteContactToEvent(contact);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
#endregion

        #region "Images"
        [HttpPost]
        [Route("AddImageToEvent")]
        public async Task<IActionResult> AddImageToEvent(DTOs.Events.Image image)
        {
            try
            {
                var um = new EventManager();
                um.AddImageToEvent(image);
                return Ok(image);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllImageToEvent")]
        public async Task<IActionResult> RetrieveAllImageToEvent(int id)
        {
            try
            {

                var image = new DTOs.Events.Image
                {
                IdEvent = id 
                };

                var mm = new EventManager();
                var results = mm.RetrieveAllImageToEvent(image);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteImageToEvent")]
        public async Task<IActionResult> DeleteImageToEvent(DTOs.Events.Image image)
        {
            try
            {
                var um = new EventManager();
                um.DeleteImageToEvent(image);
                return Ok(image);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region"Category"
        [HttpPost]
        [Route("AddCategoryToEvent")]
        public async Task<IActionResult> AddCategoryToEvent(int idCategory, int idEvent)
        {
            try
            {
                var um = new EventManager();
                um.AddCategoryToEvent(idCategory, idEvent);

                return Ok(idCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllCategoryToEvent")]
        public async Task<IActionResult> RetrieveAllCategoryToEvent(int idEvent)
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveAllCategoryToEvent(idEvent);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategoryToEvent")]
        public async Task<IActionResult> DeleteCategoryToEvent(int idCategory,int idEvent)
        {
            try
            {
                var um = new EventManager();
                um.DeleteCategoryToEvent(idCategory,idEvent);

                return Ok(idCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region"Group"
        [HttpPost]
        [Route("AddEventToGroup")]
        public async Task<IActionResult> AddEventToGroup(int idEvent, int idGroup)
        {
            try
            {
                var um = new EventManager();
                um.AddGroupToEvent(idEvent, idGroup);

                return Ok(idGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllEventsToGroups")]
        public async Task<IActionResult> RetrieveAllEventsToGroups(int idGroup)
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveAllGroupsForEvent(idGroup);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEventToGroup")]
        public async Task<IActionResult> DeleteEventToGroup(int idEvent, int idGroup)
        {
            try
            {
                var um = new EventManager();
                um.DeleteGroupFromEvent(idEvent, idGroup);
                return Ok(idGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region"Scenery"
        [HttpPost]
        [Route("AddSceneryToEvent")]
        public async Task<IActionResult> AddSceneryToEvent(int idEvent, int idScenery)
        {
            try
            {
                var um = new EventManager();
                um.AddSceneryToEvent(idEvent, idScenery);

                return Ok(idScenery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveSceneryToEvent")]
        public async Task<IActionResult> RetrieveSceneryToEvent(int idEvent)
        {
            try
            {
                var mm = new EventManager();
                var results = mm.RetrieveSceneryToEvent(idEvent);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSceneryToEvent")]
        public async Task<IActionResult> DeleteSceneryToEvent(int idEvent, int idScenery)
        {
            try
            {
                var um = new EventManager();
                um.DeleteSceneryToEvent(idEvent,idScenery);
                return Ok(idScenery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


    }
}
