using System;
using System.Collections.Generic;

namespace Dummy_Db
{
    static class WriterTable
    {
        static int GetAuthorLength(List<Book> books, int maxAuthor = 0)
        {
            foreach (var book in books)
            {
                maxAuthor = Math.Max(maxAuthor, book.AuthorName!.Length);
            }
            return maxAuthor;
        }

        static int GetBookLength(List<Book> books, int maxBookName = 0)
        {
            foreach (var book in books)
            {
                maxBookName = Math.Max(maxBookName, book.Name!.Length);
            }
            return maxBookName;
        }

        static int GetStudentLength(List<Student> students, int maxStudentName = 0)
        {
            foreach (var student in students)
            {
                maxStudentName = Math.Max(maxStudentName, student.ReaderName!.Length);
            }
            return maxStudentName;
        }

        static int GetDateLength(List<StudentWithBook> studentsWithBook, int dateLength = 0)
        {
            foreach (var item in studentsWithBook)
            {
                string date = item.DateOfGetting.ToString("dd.MM.yyyy");
                dateLength = Math.Max(date.Length, dateLength);
            }
            return dateLength;
        }

        public static void WriteTable(List<StudentWithBook> studentsWithBook, List<Book> books, List<Student> students)
        {
            int maxAuthor = GetAuthorLength(books);
            int maxBookName = GetBookLength(books);
            int maxReader = GetStudentLength(students);
            int maxDateLength = GetDateLength(studentsWithBook);

            int lengthOfLine = maxBookName + maxAuthor + maxReader + 15; // 13 represents the length of separators and padding

            Console.WriteLine(new string('-', lengthOfLine));
            Console.WriteLine($"|{"Имя читателя".PadRight(maxReader)}|{"Название".PadRight(maxBookName)}|{"Автор".PadRight(maxAuthor)}|{"Взял".PadRight(maxDateLength)}|");
            Console.WriteLine(new string('-', lengthOfLine));

            foreach (var item in studentsWithBook)
            {
                var student = students.Find(s => s.Id == item.PersonId);
                var book = books.Find(b => b.Id == item.BookId);

                string dateOfGetting = item.DateOfGetting.ToString("dd.MM.yyyy");

                Console.Write("|");
                Console.Write(student!.ReaderName!.PadRight(maxReader));
                Console.Write("|");
                Console.Write(book!.Name!.PadRight(maxBookName));
                Console.Write("|");
                Console.Write(book!.AuthorName!.PadRight(maxAuthor));
                Console.Write("|");
                Console.Write(dateOfGetting.PadRight(maxDateLength));
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', lengthOfLine));
        }
    }
}
