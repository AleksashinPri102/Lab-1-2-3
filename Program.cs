using System.Collections.Generic;
using System.IO;

namespace Dummy_Db
{
    class Programm
    {
        static void Main()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName!;
            string studentPath = string.Concat(projectPath, "\\Student.csv");
            string booksPath = string.Concat(projectPath, "\\Book.csv");
            string studentsWithBookPath = string.Concat(projectPath, "\\StudentsWithBook.csv");

            List<Student> students = new();
            List<Book> books = new();
            List<StudentWithBook> studentsWithBook = new();

            studentsWithBook = CsvParser.ParseStudentWithBook(studentsWithBookPath, studentsWithBook);
            students = CsvParser.ParseStudent(studentPath, students);
            books = CsvParser.ParseBook(booksPath, books);

            WriterTable.WriteTable(studentsWithBook, books, students);
        }
    }
}
