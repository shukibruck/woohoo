using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Whoohoo.Model;
using Whoohoo.Services.Interfaces;

namespace Whoohoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<CameraModel> GetAll()
        {
            return _cameraService.GetAll();
        }

        [HttpGet]
        [Route("GetDivided")]
        public CamerasDividedModel GetDivided()
        {
            return _cameraService.GetDivided();
        }
    }
}
