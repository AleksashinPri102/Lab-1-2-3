using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dummy_Db
{
    static class CsvParser
    {
        public static List<StudentWithBook> ParseStudentWithBook(string studentsWithBookPath, List<StudentWithBook> studentsWithBook)
        {
            int expectedCount = 4;
            var lines = File.ReadLines(studentsWithBookPath).ToArray();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(";");
                CheckInequality(splitted.Length, studentsWithBookPath, expectedCount);
                StudentWithBook studentWithBook = new();
                studentWithBook.BookId = ValueTryParse(i, splitted[0], studentsWithBookPath);
                studentWithBook.PersonId = ValueTryParse(i, splitted[1], studentsWithBookPath);
                studentWithBook.DateOfGetting = DateTime.Parse(splitted[2]);
                studentWithBook.DateOfReturn = DateTime.Parse(splitted[3]);
                studentsWithBook.Add(studentWithBook);
            }

            return studentsWithBook;
        }
        public static List<Student> ParseStudent(string studentPath, List<Student> students)
        {
            int expectedCount = 2;
            var lines = File.ReadLines(studentPath).ToArray();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(";");
                CheckInequality(splitted.Length, studentPath, expectedCount);
                Student student = new();
                student.Id = ValueTryParse(i, splitted[0], studentPath);
                student.ReaderName = splitted[1];
                students.Add(student);
            }

            return students;
        }

        public static List<Book> ParseBook(string booksPath, List<Book> books)
        {
            int expectedCount = 6;
            var lines = File.ReadLines(booksPath).ToArray();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(";");
                CheckInequality(splitted.Length, booksPath, expectedCount);
                Book book = new();
                book.Id = ValueTryParse(i, splitted[0], booksPath);
                book.Name = splitted[1];
                book.AuthorName = splitted[2];
                book.YearOfPublication = ValueTryParse(i, splitted[3], booksPath);
                book.Case = ValueTryParse(i, splitted[4], booksPath);
                book.Shelf = ValueTryParse(i, splitted[5], booksPath);
                books.Add(book);
            }

            return books;
        }
        public static int ValueTryParse(int i, string data, string path)
        {
            if (!int.TryParse(data, out int value))
                throw new Exception($"Данные в файле {path}  в {i} строке должен быть целым числом");
            return value;
        }

        public static void CheckInequality(int actualCount, string path, int expectedCount)
        {
            if (actualCount != expectedCount)
                throw new Exception($"error: Количество данных в каждой строке файла {path} должно быть равно {expectedCount}");
        }
    }
}
