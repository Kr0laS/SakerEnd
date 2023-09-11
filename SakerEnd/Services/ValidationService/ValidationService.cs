using SakerEnd.Model;
using System.Net;
using System.Net.Sockets;

namespace SakerEnd.Services.ValidationService;

public static class ValidationService
{
    public static bool ValidateAddress(string ip, string port)
    {
        return ValidIP(ip) && ValidPort(port);
    }

    private static bool ValidIP(string ip)
    {
        if (ip.Length < 7) return false;
        IPAddress address;
        return IPAddress.TryParse(ip, out address) && address.AddressFamily == AddressFamily.InterNetwork;
    }

    private static bool ValidPort(string port)
    {
        if (int.TryParse(port, out int p))
        {
            return p > 0 && p <= 65535;
        }
        return false;
    }
}
