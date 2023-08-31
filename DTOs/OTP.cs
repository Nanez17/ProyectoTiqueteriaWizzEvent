using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OTP : BaseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OTPCode { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryAddress { get; set; }
    }
    public class OTPRequestData : BaseDTO
    {
        public int UserId { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryAddress { get; set; }
    }

    public class OTPValidationData : BaseDTO
    {
        public string GeneratedOTP { get; set; }
        public string EnteredOTP { get; set; }

    }

}