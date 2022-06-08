using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.Service.Interface;
using System;
using System.Threading.Tasks;

namespace N5.UserPermissions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService _permissionTypeService;

        public PermissionTypeController(IPermissionTypeService permissionTypeService)
        {
            _permissionTypeService = permissionTypeService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissionTypes = await _permissionTypeService.GetAll();

                if (permissionTypes == null) return NotFound(permissionTypes);

                return Ok(permissionTypes);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissionTypes = await _permissionTypeService.Get();

                if (permissionTypes == null) return NotFound(permissionTypes);

                return Ok(permissionTypes);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var permissionTypes = await _permissionTypeService.Get(id);

                if (permissionTypes == null) return NotFound(permissionTypes);

                return Ok(permissionTypes);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionTypeRequestDTO permissionType)
        {
            try
            {

                var response = await _permissionTypeService.Post(permissionType);

                if (response) return new ObjectResult(permissionType) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionTypeRequestDTO permissionType)
        {
            try
            {

                if (id <= 0 && permissionType.Id <= 0) { return new ObjectResult(permissionType) { StatusCode = StatusCodes.Status304NotModified }; }

                if (permissionType.Id <= 0 && id > 0)
                {
                    permissionType = permissionType.Clone(id);
                }

                var response = await _permissionTypeService.Put(permissionType);

                if (response) return new ObjectResult(permissionType) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _permissionTypeService.Delete(id);

                if (response) return Ok(response);
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
