using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.CRUD
{
    public class OTPCRUDFactory : CrudFactory
    {
        private OTPMapper _mapper;

        public OTPCRUDFactory()
        {
            _dao = SqlDao.GetInstance();
            _mapper = new OTPMapper();
        }

        public override void Create(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = _mapper.GetCreateStatement(dto);
            _dao.ExecuteQueryProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = _mapper.GetDeleteStatement(dto);
            _dao.ExecuteQueryProcedure(sqlOperation);
        }

      

        public override List<T> RetrieveAll<T>()
        {
            var lstOTP = new List<T>();
            var sqlOperation = _mapper.GetRetrieveAllStatement();

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstResults);
                foreach (var obj in objs)
                {
                    lstOTP.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstOTP;
        }

        public override T RetrieveById<T>(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var lstOTP = new List<T>();
            var sqlOperation = _mapper.GetRetrieveByIDStatement(dto);

            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                var objs = _mapper.BuildObjects(result);
                foreach (var obj in objs)
                {
                    lstOTP.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            if (lstOTP.Count > 0)
            {
                return lstOTP[0];
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
            var otp = (OTP)dto;
            var sqlOperation = _mapper.GetUpdateStatement(dto);
            _dao.ExecuteQueryProcedure(sqlOperation);
        }

        public string Generate(OTP otp)
        {
            var random = new Random();
            var otpCode = random.Next(100000, 999999).ToString();

            otp.OTPCode = otpCode;

            return otpCode;
        }

        public bool Validate(string generatedOTP, string enteredOTP)
        {
            return generatedOTP == enteredOTP;
        }

       
    }
}