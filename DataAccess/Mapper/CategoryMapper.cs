
using DataAccess.DAO;
using DTOs;
using DTOs.Events;
using System;


namespace DataAccess.Mapper
{
    public class CategoryMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var categoryDTO = new Category
            {
                Id = (int)row["IdCategory"],
                Name = row["Name"] != DBNull.Value ? (string)row["Name"] : string.Empty
            };

            return categoryDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var categoryDTO = BuildObject(item);
                lstResults.Add(categoryDTO);
            }

            return lstResults;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_CATEGORY_PR";

            var category = (Category)dto;

            sqlOperation.AddVarcharParam("P_NAME", category.Name);

            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_CATEGORY_PR";

            var category = (Category)dto;

            sqlOperation.AddIntParam("P_IDCATEGORY", category.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_CATEGORY_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_CATEGORY_PR";

            var category = (Category)dto;

            sqlOperation.AddIntParam("P_IDCATEGORY", category.Id);
            sqlOperation.AddVarcharParam("P_NAME", category.Name);

            return sqlOperation;
        }

    }
}
