using Microsoft.AspNetCore.Mvc;
using SakerEnd.Services.DeviceService;
using SakerEnd.Services.ValidationService;

namespace SakerEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IValidationService _validationService;
        private IDeviceService _deviceService;

        public DeviceController(IValidationService validationService,
            IDeviceService deviceService)
        {
            _validationService = validationService;
            _deviceService = deviceService;
        }

        [HttpPost("SendConfiguration")]
        public IActionResult SendDeviceConfiguration([FromBody]ConfigurationDto dto)
        {
            if (!_validationService.ValidateAddress(dto.IP,dto.Port)) return BadRequest("bad ip");

            try
            {
                _deviceService.RegisterDevice(dto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

            return Ok(200);
        }

    }
}
