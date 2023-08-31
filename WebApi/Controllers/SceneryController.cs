using Core;
using DTOs.Events;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SceneryController : Controller
    {
        #region"Scenery"
        [HttpPost]
        [Route("CreateScenery")]
        public async Task<IActionResult> CreateScenery(Scenery scenery)
        {
            try
            {
                var um = new SceneryManager();
                um.CreateScenery(scenery);
                return Ok(scenery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllScenery")]
        public async Task<IActionResult> RetrieveAllScenery()
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveAllSceneries();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByIdScenery")]
        public async Task<IActionResult> RetrieveByIdScenery(int IdEvent)
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveByIdScenery(IdEvent);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateScenery")]
        public async Task<IActionResult> UpdateScenery(Scenery scenery)
        {
            try
            {
                var um = new SceneryManager();
                um.UpdateScenery(scenery);
                return Ok(scenery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteScenery")]
        public async Task<IActionResult> DeleteScenery(Scenery scenery)
        {
            try
            {
                var um = new SceneryManager();
                um.DeleteScenery(scenery);
                return Ok(scenery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region"Sector"
        [HttpPost]
        [Route("CreateSectorToScenery")]
        public async Task<IActionResult> CreateSectorToScenery(Sector sector)
        {
            try
            {
                var um = new SceneryManager();
                um.CreateSector(sector);
                return Ok(sector);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllSectorToScenery")]
        public async Task<IActionResult> RetrieveAllSectorToScenery(int idScenery)
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveAllSector(idScenery);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByIdSector")]
        public async Task<IActionResult> RetrieveByIdSector(int IdScenery, string Sector)
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveByIdSector(IdScenery, Sector);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSectorToScenery")]
        public async Task<IActionResult> DeleteSectorToScenery(Sector sector)
        {
            try
            {
                var um = new SceneryManager();
                um.DeleteSector(sector);
                return Ok(sector);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region"Seat"
        [HttpPost]
        [Route("CreateSeatToSector")]
        public async Task<IActionResult> CreateSeatToSector(Seat seat,int totalSeats)
        {
            try
            {
                var um = new SceneryManager();
                um.CreateSeat(seat,totalSeats);
                return Ok(seat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllSeatToSector")]
        public async Task<IActionResult> RetrieveAllSeatToSector(int idScenery, int idSector)
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveAllSeatsOfSector(idScenery,idSector);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveCantSeatsAvailable")]
        public async Task<IActionResult> RetrieveCantSeatsAvailable(int idSector)
        {
            try
            {
                var mm = new SceneryManager();
                var results = mm.RetrieveCantSeatsAvailable(idSector);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSeatToSector")]
        public async Task<IActionResult> DeleteSeatToSector(Seat seat)
        {
            try
            {
                var um = new SceneryManager();
                um.DeleteSeat(seat);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
