using Microsoft.EntityFrameworkCore;
using N5.UserPermissions.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UserPermissions.Test.Controllers.Base
{
    public abstract class ControllerTestBase
    {
        protected ApplicationDbContext BuildContext(string connectionString)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(connectionString).Options;

            var context = new ApplicationDbContext(opciones);
            return context;
        }
    }
}
