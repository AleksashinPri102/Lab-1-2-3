using System.Collections.Generic;

namespace Dummy_Db
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();
            List<Book> books = new();
            List<StudentsBook> studentsBook = new();

            studentsBook = CsvParser.ParseStudentsBook(studentsBook);
            students = CsvParser.ParseStudent(students);
            books = CsvParser.ParseBook(books);

            WriterTable.WriteTable(studentsBook, books, students);
        }
    }
}
