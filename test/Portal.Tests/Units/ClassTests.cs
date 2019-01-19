using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Portal.Tests.Units
{
    public class ClassTests
    {
        
        [Fact]
        public void Class_With_Empty_Name_Is_Not_Valid()
        {
            var validator = new Portal.Application.Classes.ClassValidator();
            var result=validator.Validate(new Domain.Entities.Class() { Name = "", Location = "Location", Teacher = "Teacher" });
            Assert.True(result.IsValid == false);
            
        }
    }
}
