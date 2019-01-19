using Microsoft.EntityFrameworkCore;
using Portal.Application.Students;
using Portal.Persistance;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portal.Tests.Units
{
    public class StudentTests
    {
        [Fact]
        public async Task Same_Student_Can_Not_Be_Added_To_Class()
        {
            var options = new DbContextOptionsBuilder<PortalDbContext>()
              .UseInMemoryDatabase(databaseName: "Same_Student_Db")
              .Options;

            using (var context = new PortalDbContext(options))
            {
                var service = new StudentService(context);
                await service.Add(new Domain.Entities.Student() { ClassId = 1, Age = 19, GPA = 3.2f, Name = "Jones" });

                await Assert.ThrowsAsync<Exception>(async () =>
                {
                    await service.Add(new Domain.Entities.Student() { ClassId = 1, Age = 18, GPA = 3.0f, Name = "Jones" });
                });

            }


        }

        [Fact]
        public async Task New_Student_Can_Be_Added_To_Class()
        {
            var options = new DbContextOptionsBuilder<PortalDbContext>()
              .UseInMemoryDatabase(databaseName: "Not_Same_Student_Db")
              .Options;

            using (var context = new PortalDbContext(options))
            {
                var service = new StudentService(context);
                var count = (await service.GetAll()).Count();
                await service.Add(new Domain.Entities.Student() { ClassId = 1, Age = 19, GPA = 3.2f, Name = "Jones" });
                await service.Add(new Domain.Entities.Student() { ClassId = 1, Age = 18, GPA = 3.0f, Name = "David" });
                var countAfter = (await service.GetAll()).Count();

                Assert.Equal(countAfter, count + 2);
                

            }


        }
    }
}
