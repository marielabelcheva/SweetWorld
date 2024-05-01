using Microsoft.EntityFrameworkCore;
using SweetWorld.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Tests.Mock
{
    public class DbMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("SweetWorldInMemoryDb").Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
