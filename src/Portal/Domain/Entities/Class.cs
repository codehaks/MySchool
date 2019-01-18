using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Teacher { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
