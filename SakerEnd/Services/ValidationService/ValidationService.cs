using SakerEnd.Model;
using System.Net;

namespace SakerEnd.Services.ValidationService
{
    public class ValidationService : IValidationService
    {
        public bool ValidateAddress(string ip ,string port)
        {

            return ValidIP(ip) && ValidPort(port);
        }
        private bool ValidIP(string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }
        private bool ValidPort(string port)
        {
            int p;
            return int.TryParse(port, out p) && p > 1 && p < 65535;
        }
    }
}
