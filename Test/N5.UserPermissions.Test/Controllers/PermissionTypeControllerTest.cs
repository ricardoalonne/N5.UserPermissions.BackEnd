using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.DataTransferObject.Response;
using N5.UserPermissions.Service.Implementation;
using N5.UserPermissions.Service.Interface;
using N5.UserPermissions.Test.Controllers.Base;
using N5.UserPermissions.UnitOfWork.Interface;
using N5.UserPermissions.WebApi.Controllers;

namespace N5.UserPermissions.Test.Controllers
{
    [TestClass]
    public class PermissionTypeControllerTest : ControllerTestBase
    {
        public readonly string _connectionString;

        public PermissionTypeControllerTest()
        {
            _connectionString = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task GetAll()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 1.", IsActive = true });
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 2.", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            var response = await permissionTypeController.GetAll() as ObjectResult;

            //Check
            var permissions = response.Value as List<PermissionTypeResponseDTO>;
            Assert.AreEqual(2, permissions.Count);
        }

        [TestMethod]
        public async Task Get()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 1.", IsActive = true });
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 2.", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            var response = await permissionTypeController.Get() as ObjectResult;

            //Check
            var permissions = response.Value as List<PermissionTypeResponseDTO>;
            Assert.AreEqual(1, permissions.Count);
        }

        [TestMethod]
        public async Task GetById()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 1.", IsActive = true });
            await context.PermissionTypes.AddAsync(new Entity.PermissionType() { Description = "Type 2.", IsActive = false });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            var response = await permissionTypeController.Get(1) as ObjectResult;

            //Check
            var result = response.StatusCode;
            //Assert.AreEqual(404, result);
            Assert.AreEqual(200, result);
        }


        [TestMethod]
        public async Task Post()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var newPermissionType = new Entity.PermissionType() { Description = "Type 1.", IsActive = true };
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(context);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            var response = await permissionTypeController.Post(new PermissionTypeRequestDTO(newPermissionType));
            var result = response as ObjectResult;
            Assert.IsNotNull(result.Value);

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var count = await contextTesting.PermissionTypes.CountAsync();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task Put()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTypeTest = new Entity.PermissionType() { Description = "Type 1.", IsActive = true };
            await context.PermissionTypes.AddAsync(permissionTypeTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            permissionTypeTest.Description = "Type 1.2";
            var response = await permissionTypeController.Put(1, new PermissionTypeRequestDTO(permissionTypeTest)) as ObjectResult;
            Assert.AreEqual(201, response.StatusCode);

            //Testing
            var contextTestingDb = BuildContext(_connectionString);
            var exist = await contextTestingDb.PermissionTypes.AnyAsync(type => type.Description == permissionTypeTest.Description);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTypeTest = new Entity.PermissionType() { Description = "Type 1.", IsActive = true };
            await context.PermissionTypes.AddAsync(permissionTypeTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionTypeService permissionTypeService = new PermissionTypeService(unitOfWork);
            var permissionTypeController = new PermissionTypeController(permissionTypeService);
            var response = await permissionTypeController.Delete(1) as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

            var contextTestingDb = BuildContext(_connectionString);
            var permissionTypeInDb = await contextTestingDb.PermissionTypes.SingleOrDefaultAsync(type => type.Id == 1);
            Assert.IsFalse(permissionTypeInDb.IsActive);
        }
    }
}
