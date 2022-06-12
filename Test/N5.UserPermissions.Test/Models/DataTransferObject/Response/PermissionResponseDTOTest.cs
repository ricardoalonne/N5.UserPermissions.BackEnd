using Microsoft.VisualStudio.TestTools.UnitTesting;
using N5.UserPermissions.DataTransferObject.Response;
using N5.UserPermissions.Test.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UserPermissions.Test.Models.DataTransferObject.Response
{
    [TestClass]
    public class PermissionResponseDTOTest
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

            var result = new PermissionResponseDTO()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new PermissionTypeResponseDTO() { Id = 1, },
                PermitDate = _dateTimeNow,
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new PermissionResponseDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new PermissionResponseDTO()
            {
                Id = 1,
                EmployeeName = "Luis",
                EmployeeLastName = "Martinez",
                PermissionType = new PermissionTypeResponseDTO() { Id = 1, Description = "Type 2", IsActive = true },
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
    }
}
