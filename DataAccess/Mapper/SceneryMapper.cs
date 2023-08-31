using DataAccess.DAO;
using DTOs;
using DTOs.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class SceneryMapper : IObjectMapper, ISqlStatements
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var sceneryDTO = new Scenery
            {
                Id = (int)row["IdScenery"],
                IdEvent = (int)row["IdEvent"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                Location = row["Location"] != DBNull.Value ? (string)row["Location"] : string.Empty
            };

            return sceneryDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var sceneryDTO = BuildObject(item);
                lstResults.Add(sceneryDTO);
            }

            return lstResults;
        }

        public int BuildObjectCantAvailable(Dictionary<string, object> row)
        {
            var cantidad = new 
            {
                Cant = (int)row["CantSeats"],
            };

            return cantidad.Cant;
        }

        public int BuildObjectsCantAvailable(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<int>();

            foreach (var item in lstRows)
            {
                var cantidad = BuildObjectCantAvailable(item);
                lstResults.Add(cantidad);
            }

            return lstResults[0];
        }

        public BaseDTO BuildSectorObject(Dictionary<string, object> row)
        {
            var sectorDTO = new Sector
            {
                Id = (int)row["IdSector"],
                IdScenery = (int)row["IdScenery"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                Price = (decimal)row["Price"],
                State = row["State"] != DBNull.Value ? (string)row["State"] : string.Empty,
                SeatsNumber = row["SeatsNumber"] != DBNull.Value ? (int)row["SeatsNumber"] : 0
            };

            return sectorDTO;
        }

        public List<BaseDTO> BuildObjectsSector(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var sector = BuildSectorObject(item);
                lstResults.Add(sector);
            }

            return lstResults;
        }

        public BaseDTO BuildSeatObject(Dictionary<string, object> row)
        {
            var seatDTO = new Seat
            {
                Id = (int)row["IdSeat"],
                IdScenery = (int)row["IdScenery"],
                IdSector = (int)row["IdSector"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty,
                State = row["State"] != DBNull.Value ? (string)row["State"] : string.Empty
            };

            return seatDTO;
        }

        public List<BaseDTO> BuildObjectsSeat(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var seat = BuildSeatObject(item);
                lstResults.Add(seat);
            }

            return lstResults;
        }


        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_SCENERY_PR";

            var scenery = (Scenery)dto;

            sqlOperation.AddIntParam("P_IDEVENT", scenery.IdEvent);
            sqlOperation.AddVarcharParam("P_NAME", scenery.Name);
            sqlOperation.AddVarcharParam("P_LOCATION", scenery.Location);

            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_SCENERY_PR";

            var scenery = (Scenery)dto;

            sqlOperation.AddIntParam("P_IDSCENERY", scenery.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_SCENERIES_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByIDStatement(int IdEvent)
        {
            var sqlOperation = new SQLOperation();

            sqlOperation.ProcedureName = "RET_BY_ID_SCENERY_PR";
            sqlOperation.AddIntParam("P_IDEVENT",IdEvent);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_SCENERY_PR";

            var scenery = (Scenery)dto;

            sqlOperation.AddIntParam("P_IDSCENERY", scenery.Id);
            sqlOperation.AddVarcharParam("P_NAME", scenery.Name);
            sqlOperation.AddVarcharParam("P_LOCATION", scenery.Location);

            return sqlOperation;
        }

        public SQLOperation GetCreateSectorStatement(int idScenery, Sector sector)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_SCENERY_SECTOR_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);
            sqlOperation.AddVarcharParam("P_NAME", sector.Name);
            sqlOperation.AddVarcharParam("P_STATE", sector.State);
            sqlOperation.AddDecimalParam("P_PRICE", sector.Price);
            sqlOperation.AddIntParam("P_SEATSNUMBER", sector.SeatsNumber);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllSectorStatement(int idScenery)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_SCENERY_SECTOR_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);

            return sqlOperation;
        }

        public SQLOperation GetDeleteSectorStatement(int idScenery, int idSector)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_SCENERY_SECTOR_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);
            sqlOperation.AddIntParam("P_IDSECTOR", idSector);

            return sqlOperation;
        }

        public SQLOperation GetCreateSeatStatement(Seat seat, int totalSeats)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_SECTOR_SEAT_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", seat.IdScenery);
            sqlOperation.AddIntParam("P_IDSECTOR", seat.IdSector);
            sqlOperation.AddIntParam("P_NUM_SEATS", totalSeats);
            sqlOperation.AddVarcharParam("P_STATE", seat.State);
            sqlOperation.AddVarcharParam("P_NAME", seat.Name);

            return sqlOperation;
        }

        public SQLOperation GetDeleteSeatStatement(Seat seat)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_SECTOR_SEAT_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", seat.IdScenery);
            sqlOperation.AddIntParam("P_IDSEAT", seat.Id);
            sqlOperation.AddIntParam("P_IDSECTOR", seat.IdSector);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllSeatsOfSectorStatement(int idScenery, int idSector)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_SECTOR_SEAT_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", idScenery);
            sqlOperation.AddIntParam("P_IDSECTOR", idSector);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDSectorStatement(int idEvent, string sector)
        {
            var sqlOperation = new SQLOperation();

            sqlOperation.ProcedureName = "RET_BY_ID_SCENERY_SECTOR_PR";

            sqlOperation.AddIntParam("P_IDSCENERY", idEvent);
            sqlOperation.AddVarcharParam("P_NAME", sector);

            return sqlOperation;
        }

        public SQLOperation RetrieveCantSeatsAvailable(int idSector)
        {
            var sqlOperation = new SQLOperation();

            sqlOperation.ProcedureName = "GET_CANT_SEATS_AVAILABLE_PR";

            sqlOperation.AddIntParam("P_IDSECTOR", idSector);

            return sqlOperation;
        }
    }
}
