using System;

namespace Dummy_Db
{
    public class StudentsBook
    {
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfGetting { get; set; }
        public DateTime DateOfReturning { get; set; }
    }
}