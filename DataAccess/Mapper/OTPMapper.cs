using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.Mapper
{
    public class OTPMapper : ISqlStatements, IObjectMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var otpDTO = new OTP
            {
                Id = (int)row["IdOTP"],
                UserId = (int)row["UserId"],
                OTPCode = (string)row["OTPCode"],
                DeliveryMethod = (string)row["DeliveryMethod"],
                DeliveryAddress = (string)row["DeliveryAddress"],
            };
            return otpDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var otpList = new List<BaseDTO>();
            foreach (var row in rows)
            {
                var otpDTO = BuildObject(row);
                otpList.Add(otpDTO);
            }
            return otpList;
        }

        public SQLOperation GetCreateStatement(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "CREATE_OTP_PR";

            sqlOperation.AddIntParam("P_USER_ID", otp.UserId);
            sqlOperation.AddVarcharParam("P_OTP_CODE", otp.OTPCode);
            sqlOperation.AddVarcharParam("P_DELIVERY_METHOD", otp.DeliveryMethod);
            sqlOperation.AddVarcharParam("P_DELIVERY_ADDRESS", otp.DeliveryAddress);

            return sqlOperation;
        }

        public SQLOperation GetDeleteStatement(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "DELETE_OTP_PR";

            sqlOperation.AddIntParam("P_OTP_ID", otp.Id);

            return sqlOperation;
        }

        public SQLOperation GetRetrieveAllStatement()
        {
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RETRIEVE_ALL_OTP_PR";

            return sqlOperation;
        }

        public SQLOperation GetRetrieveByEmailAndPassword(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public SQLOperation GetRetrieveByIDStatement(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "RETRIEVE_BY_ID_OTP_PR";

            sqlOperation.AddIntParam("P_OTP_ID", otp.Id);

            return sqlOperation;
        }

        public SQLOperation GetUpdateStatement(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = new SQLOperation();
            sqlOperation.ProcedureName = "UPDATE_OTP_PR";

            sqlOperation.AddIntParam("P_OTP_ID", otp.Id);
            sqlOperation.AddIntParam("P_USER_ID", otp.UserId);
            sqlOperation.AddVarcharParam("P_OTP_CODE", otp.OTPCode);
            sqlOperation.AddVarcharParam("P_DELIVERY_METHOD", otp.DeliveryMethod);
            sqlOperation.AddVarcharParam("P_DELIVERY_ADDRESS", otp.DeliveryAddress);

            return sqlOperation;
        }
    }
}