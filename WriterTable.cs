using System;
using System.Collections.Generic;

namespace Dummy_Db
{
    static class WriterTable
    {
        public static void WriteTable(List<StudentsBook> studentsBook, List<Book> books, List<Student> students)
        {
            int maxReader = GetStudentLength(students);
            int maxBookName = GetBookLength(books);
            int maxAuthor = GetAuthorLength(books);
            int maxDateLength = GetDateLength(studentsBook);

            int lengthOfLine = maxBookName + maxAuthor + maxReader + maxDateLength + 5;

            Console.WriteLine(new string('-', lengthOfLine));
            Console.WriteLine($"|{"Имя читателя".PadRight(maxReader)}|{"Название".PadRight(maxBookName)}|{"Автор".PadRight(maxAuthor)}|{"Взял".PadRight(maxDateLength)}|");
            Console.WriteLine(new string('-', lengthOfLine));

            foreach (var item in studentsBook)
            {
                var student = FindStudentById(students, item.StudentId);
                var book = FindBookById(books, item.BookId);

                string dateOfGetting = item.DateOfGetting.ToString("dd.MM.yyyy");

                Console.Write("|" + student.Name.PadRight(maxReader) + "|");
                Console.Write(book.Name.PadRight(maxBookName) + "|");
                Console.Write(book.AuthorName.PadRight(maxAuthor) + "|");
                Console.Write(dateOfGetting.PadRight(maxDateLength) + "|");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', lengthOfLine));
        }
        static int GetStudentLength(List<Student> students, int maxStudentName = 0)
        {
            foreach (var student in students)
            {
                string studentName = student.Name;
                if (maxStudentName < studentName.Length)
                    maxStudentName = studentName.Length;
            }
            return maxStudentName;
        }
        static int GetBookLength(List<Book> books, int maxBookName = 0)
        {
            foreach (var book in books)
            {
                string bookName = book.Name;
                if (maxBookName < bookName.Length)
                    maxBookName = bookName.Length;
            }
            return maxBookName;
        }
        static int GetAuthorLength(List<Book> books, int maxAuthor = 0)
        {
            foreach (var book in books)
            {
                string authorName = book.AuthorName;
                if (maxAuthor < authorName.Length)
                    maxAuthor = authorName.Length;
            }
            return maxAuthor;
        }
        static int GetDateLength(List<StudentsBook> studentsWithBook, int dateLength = 0)
        {
            foreach (var item in studentsWithBook)
            {
                string date = item.DateOfGetting.ToString("dd.MM.yyyy");
                if (date.Length > dateLength)
                    dateLength = date.Length;
            }
            return dateLength;
        }
        static Student FindStudentById(List<Student> students, int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                    return student;
            }
            return null;
        }
        static Book FindBookById(List<Book> books, int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }
    }
}
