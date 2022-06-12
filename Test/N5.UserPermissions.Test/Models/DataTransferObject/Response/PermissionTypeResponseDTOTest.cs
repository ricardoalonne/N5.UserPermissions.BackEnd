using Microsoft.VisualStudio.TestTools.UnitTesting;
using N5.UserPermissions.DataTransferObject.Response;
using N5.UserPermissions.Test.Utility;

namespace N5.UserPermissions.Test.Models.DataTransferObject.Response
{
    [TestClass]
    public class PermissionTypeResponseDTOTest
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

            var result = new PermissionTypeResponseDTO()
            {
                Id = 1,
                Description = "Type 1",
                IsActive = true,
            };

            //Testing
            var constructorByEntity = new PermissionTypeResponseDTO(entity);

            //Check
            Assert.IsTrue(ObjectComparerUtility.ObjectsAreEqual(result, constructorByEntity));
        }

        [TestMethod]
        public void ConvertToEntity()
        {
            // Data preparation
            var dto = new PermissionTypeResponseDTO()
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
    }
}
