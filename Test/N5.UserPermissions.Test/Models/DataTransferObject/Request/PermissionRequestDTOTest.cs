using Microsoft.VisualStudio.TestTools.UnitTesting;
using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.Test.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UserPermissions.Test.Models.DataTransferObject.Request
{
    [TestClass]
    public class PermissionRequestDTOTest
    {
        private readonly DateTime _dateTimeNow = DateTime.UtcNow;

        [TestMethod]
        public void ConstructorByEntity()
        {
            // Data preparation
            var entity = new Entity.Permission()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            var result = new PermissionRequestDTO()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new PermissionRequestDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new PermissionRequestDTO()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            var result = new Entity.Permission()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var convertionToEntity = dto.ToEntity();

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, convertionToEntity));
        }

        [TestMethod]
        public void Clone()
        {
            // Data preparation
            var dto = new PermissionRequestDTO()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            var result = new PermissionRequestDTO()
            {
                Id = 2,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionTypeId = 1,
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var clonation = dto.Clone(2);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, clonation));
        }
    }
}
