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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissions = await _permissionService.GetAll();

                if (permissions == null) return NotFound(permissions);

                return Ok(permissions);
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
                var permissions = await _permissionService.Get();

                if (permissions == null) return NotFound(permissions);

                return Ok(permissions);

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
                var permissions = await _permissionService.Get(id);

                if (permissions == null) return NotFound(permissions);

                return Ok(permissions);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionRequestDTO permission)
        {
            try
            {

                var response = await _permissionService.Post(permission);

                if (response) return new ObjectResult(permission) { StatusCode = StatusCodes.Status201Created };
                else return BadRequest(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionRequestDTO permission)
        {
            try
            {

                if (id <= 0 && permission.Id <= 0) { return new ObjectResult(permission) { StatusCode = StatusCodes.Status304NotModified }; }

                if (permission.Id <= 0 && id > 0)
                {
                    permission = permission.Clone(id);
                }

                var response = await _permissionService.Put(permission);

                if (response) return new ObjectResult(permission) { StatusCode = StatusCodes.Status201Created };
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
                var response = await _permissionService.Delete(id);

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
