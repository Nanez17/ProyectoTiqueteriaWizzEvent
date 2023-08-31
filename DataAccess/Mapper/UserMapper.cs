using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UserMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var userDTO = new User
            {
                Id = (int)row["IdUser"],
                Nombre = (string)row["Nombre"],
                Apellidos = (string)row["Apellidos"],
                TipoIdentificacion = (string)row["TipoIdentificacion"],
                NumeroIdentificacion = (string)row["NumeroIdentificacion"],
                Email = (string)row["Email"],
                Telefono = (string)row["Telefono"],
                CedulaImagen = (string)row["CedulaImagen"],
                Password = (string)row["Password"],
                ConfirmPassword = (string)row["ConfirmPassword"],
                Ubicacion = (string)row["Ubicacion"]
            };
            return userDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> row)
        {
            var lstResults = new List<BaseDTO>();
            foreach (var item in row)
            {
                var userDTO = BuildObject(item);
                lstResults.Add(userDTO);
            }
            return lstResults;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_USER_CLIENT_PR";

            var user = (User)dto;

            sqlOperation.AddVarcharParam("P_NOMBRE", user.Nombre);
            sqlOperation.AddVarcharParam("P_APELLIDOS", user.Apellidos);
            sqlOperation.AddVarcharParam("P_TIPO_IDENTIFICACION", user.TipoIdentificacion);
            sqlOperation.AddVarcharParam("P_NUMERO_IDENTIFICACION", user.NumeroIdentificacion);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_TELEFONO", user.Telefono);
            sqlOperation.AddVarcharParam("P_CEDULA_IMAGEN", user.CedulaImagen);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_CONFIRM_PASSWORD", user.ConfirmPassword);
            sqlOperation.AddVarcharParam("P_UBICACION", user.Ubicacion);
            sqlOperation.AddVarcharParam("P_ROL", "1");


            return sqlOperation;
        }
        public SQLOperation GetCreateGEStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_USER_GE_PR";

            var user = (User)dto;

            sqlOperation.AddVarcharParam("P_NOMBRE", user.Nombre);
            sqlOperation.AddVarcharParam("P_APELLIDOS", user.Apellidos);
            sqlOperation.AddVarcharParam("P_TIPO_IDENTIFICACION", user.TipoIdentificacion);
            sqlOperation.AddVarcharParam("P_NUMERO_IDENTIFICACION", user.NumeroIdentificacion);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_TELEFONO", user.Telefono);
            sqlOperation.AddVarcharParam("P_CEDULA_IMAGEN", user.CedulaImagen);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_CONFIRM_PASSWORD", user.ConfirmPassword);
            sqlOperation.AddVarcharParam("P_UBICACION", user.Ubicacion);
            sqlOperation.AddVarcharParam("P_ROL", "3");


            return sqlOperation;
        }

        public SQLOperation GetCreateUserGEStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CRE_USER_CLIENT_PR";

            var user = (User)dto;

            sqlOperation.AddVarcharParam("P_NOMBRE", user.Nombre);
            sqlOperation.AddVarcharParam("P_APELLIDOS", user.Apellidos);
            sqlOperation.AddVarcharParam("P_TIPO_IDENTIFICACION", user.TipoIdentificacion);
            sqlOperation.AddVarcharParam("P_NUMERO_IDENTIFICACION", user.NumeroIdentificacion);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_TELEFONO", user.Telefono);
            sqlOperation.AddVarcharParam("P_CEDULA_IMAGEN", user.CedulaImagen);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_CONFIRM_PASSWORD", user.ConfirmPassword);
            sqlOperation.AddVarcharParam("P_UBICACION", user.Ubicacion);
            sqlOperation.AddVarcharParam("P_ROL", "3");


            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DEL_USER_WITH_ROLES_PR";

            var user = (User)dto;

            sqlOperation.AddIntParam("P_IdUser", user.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_ALL_USERS_PR";
            return sqlOperation;
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_BY_ID_USER_PR";

            var user = (User)dto;
            sqlOperation.AddIntParam("P_ID", user.Id);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            var user = (User)dto;

            sqlOperation.AddIntParam("P_ID", user.Id);
            sqlOperation.AddVarcharParam("P_NOMBRE", user.Nombre);
            sqlOperation.AddVarcharParam("P_APELLIDOS", user.Apellidos);
            sqlOperation.AddVarcharParam("P_TIPO_IDENTIFICACION", user.TipoIdentificacion);
            sqlOperation.AddVarcharParam("P_NUMERO_IDENTIFICACION", user.NumeroIdentificacion);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_TELEFONO", user.Telefono);
            sqlOperation.AddVarcharParam("P_CEDULA_IMAGEN", user.CedulaImagen);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_CONFIRM_PASSWORD", user.ConfirmPassword);

            return sqlOperation;
        }

        public SQLOperation GetUpdatePasswordStatement(string email,string password) {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPD_USER_PASSWORD_PR";
            sqlOperation.AddVarcharParam("P_EMAIL", email);
            sqlOperation.AddVarcharParam("P_PASSWORD", password); 
            
            return sqlOperation;

        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_BY_EMAIL_AND_PASSWORD_USER_PR";

            var user = (User)dto;
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmail(string email)
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RET_BY_EMAIL_USER_PR";
            sqlOperation.AddVarcharParam("P_EMAIL", email);
           

            return sqlOperation;
        }
    }
}