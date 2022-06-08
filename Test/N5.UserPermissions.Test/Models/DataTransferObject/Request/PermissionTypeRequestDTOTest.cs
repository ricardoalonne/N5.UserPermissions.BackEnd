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
    public class PermissionTypeRequestDTOTest
    {
        [TestMethod]
        public void ConstructorByEntity()
        {
            // Data preparation
            var entity = new Entity.PermissionType()
            {
                Id = 1,
                Description = "Type 1",
                IsActive = true,
            };

            var result = new PermissionTypeRequestDTO()
            {
                Id = 1,
                Description = "Type 1",
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new PermissionTypeRequestDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new PermissionTypeRequestDTO()
            {
                Id = 1,
                Description = "Type 1",
                IsActive = true,
            };

            var result = new Entity.PermissionType()
            {
                Id = 1,
                Description = "Type 1",
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
            var dto = new PermissionTypeRequestDTO()
            {
                Id = 1,
                Description = "Type 1",
                IsActive = true,
            };

            var result = new PermissionTypeRequestDTO()
            {
                Id = 2,
                Description = "Type 1",
                IsActive = true,
            };

            //Testing
            var clonation = dto.Clone(2);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, clonation));
        }
    }
}
