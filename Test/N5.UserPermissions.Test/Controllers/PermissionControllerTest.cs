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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.UserPermissions.Test.Controllers
{
    [TestClass]
    public class PermissionControllerTest : ControllerTestBase
    {
        public readonly string _connectionString;
        public PermissionControllerTest()
        {
            _connectionString = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task GetAll()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            });
            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Alonso",
                EmployeeLastName = "Guerra",
                PermissionType = new Entity.PermissionType() { Description = "Type 1", IsActive = false },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            var response = await permissionController.GetAll() as ObjectResult;

            //Check
            var permissions = response.Value as List<PermissionResponseDTO>;
            Assert.AreEqual(2, permissions.Count);
        }

        [TestMethod]
        public async Task Get()
        {
            //Data preparation
            var context = BuildContext(_connectionString);

            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            });
            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Alonso",
                EmployeeLastName = "Guerra",
                PermissionType = new Entity.PermissionType() { Description = "Type 1", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = false,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            var response = await permissionController.Get() as ObjectResult;

            //Check
            var permissions = response.Value as List<PermissionResponseDTO>;
            Assert.AreEqual(1, permissions.Count);
        }

        [TestMethod]
        public async Task GetById()
        {
            //Data preparation
            var context = BuildContext(_connectionString);

            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            });
            await context.Permissions.AddAsync(new Entity.Permission()
            {
                EmployeeName = "Alonso",
                EmployeeLastName = "Guerra",
                PermissionType = new Entity.PermissionType() { Description = "Type 1", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = false,
            });
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            var permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            var response = await permissionController.Get(1) as ObjectResult;

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
            var newPermission = new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            };
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(context);
            IPermissionService permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            var response = await permissionController.Post(new PermissionRequestDTO(newPermission));
            var result = response as ObjectResult;
            Assert.IsNotNull(result.Value);

            //Testing
            var contextTesting = BuildContext(_connectionString);
            var count = await contextTesting.Permissions.CountAsync();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task Put()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTest = new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            };
            await context.Permissions.AddAsync(permissionTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionService permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            permissionTest.EmployeeName = "Lucho";
            permissionTest.EmployeeLastName = "Marquez";
            var response = await permissionController.Put(1, new PermissionRequestDTO(permissionTest)) as ObjectResult;
            Assert.AreEqual(201, response.StatusCode);

            //Testing
            var contextTestingDb = BuildContext(_connectionString);
            var exist = await contextTestingDb.Permissions.AnyAsync(type => type.EmployeeName == permissionTest.EmployeeName && type.EmployeeLastName == permissionTest.EmployeeLastName);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public async Task Delete()
        {
            //Data preparation
            var context = BuildContext(_connectionString);
            var permissionTest = new Entity.Permission()
            {
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new Entity.PermissionType() { Description = "Type 2", IsActive = true },
                PermitDate = DateTime.UtcNow,
                IsActive = true,
            };
            await context.Permissions.AddAsync(permissionTest);
            await context.SaveChangesAsync();

            //Testing
            var contextTesting = BuildContext(_connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork.Implementation.UnitOfWork(contextTesting);
            IPermissionService permissionService = new PermissionService(unitOfWork);
            var permissionController = new PermissionController(permissionService);
            var response = await permissionController.Delete(1) as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

            var contextTestingDb = BuildContext(_connectionString);
            var permissionInDb = await contextTestingDb.Permissions.SingleOrDefaultAsync(type => type.Id == 1);
            Assert.IsFalse(permissionInDb.IsActive);
        }
    }
}
