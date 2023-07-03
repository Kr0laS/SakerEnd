using SakerEnd.Model;

namespace SakerEnd.Services.ValidationService
{
    public interface IValidationService
    {
        public bool ValidateAddress(string ip, string port);
    }
}
