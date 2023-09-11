using Microsoft.AspNetCore.Mvc;
using SakerEnd.Exceptions;
using SakerEnd.Services;
using SakerEnd.Services.ValidationService;

namespace SakerEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("SendConfiguration")]
        public async Task<IActionResult> SendDeviceConfiguration([FromBody]ConfigurationDto dto)
        {
            if (!ValidationService.ValidateAddress(dto.IP, dto.Port))
                return BadRequest("Invalid IP or port");

            try
            {
                var config = await _deviceService.Sendconfiguration(dto);
                return Ok(config);
            }
            catch(DeviceException dex)
            {
                return StatusCode(500, dex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("SendSubscription")]
        public async Task<IActionResult> SendDeviceSubscription([FromBody] ConfigurationDto dto)
        {
            if (!ValidationService.ValidateAddress(dto.IP, dto.Port))
                return BadRequest("Invalid IP or port");

            try
            {
                var statusReport = await _deviceService.Sendconfiguration(dto);
                return Ok(statusReport);
            }
            catch (DeviceException dex)
            {
                return StatusCode(500, dex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetDevice([FromBody]DeviceDto dto)
        {
            try
            {
                var device = _deviceService.GetDevice(dto);
                if (device is null)
                    return BadRequest("no such device...");
                return Ok(device);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
