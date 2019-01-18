namespace Portal.Domain.Entities
{
    public class Student
    {
        //public int Id { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public string Name { get; set; }

        public byte Age { get; set; }

        public float GPA { get; set; }

    }
}
