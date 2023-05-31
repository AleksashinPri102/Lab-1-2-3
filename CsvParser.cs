using System;
using System.Collections.Generic;
using System.IO;

namespace Dummy_Db
{
    public static class CsvParser
    {
        public static List<StudentsBook> ParseStudentsBook(List<StudentsBook> studentsBook)
        {
            int count = default;
            foreach (string line in File.ReadLines("studentsBook.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] cell = line.Split(";");
                if (cell.Length == 4)
                {
                    StudentsBook studentBook = new();
                    if (int.TryParse(cell[0], out int value))
                        studentBook.BookId = value;
                    else
                        throw new Exception($"error: Id книги в файле studentsBook.csv в  {count} строке должен быть целым числом");
                    if (int.TryParse(cell[1], out value))
                        studentBook.StudentId = value;
                    else
                        throw new Exception($"error: Id человека в файле studentsBook.csv в  {count} строке должен быть целым числом");
                    studentBook.DateOfGetting = DateTime.Parse(cell[2]);
                    studentBook.DateOfReturning = DateTime.Parse(cell[3]);
                    if (studentBook.DateOfGetting > studentBook.DateOfReturning)
                        throw new Exception($"error: в файле studentsBook.csv в  {count} строке дата взятия книги не может быть позже даты возвращения");
                    studentsBook.Add(studentBook);
                    count++;
                }
                else
                    throw new Exception($"error: Количество данных в {count} строке файла studentsBook.csv должно быть равно 4");
            }
            return studentsBook;
        }
        public static List<Student> ParseStudent(List<Student> students)
        {
            int count = default;
            foreach (string line in File.ReadLines("student.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] cell = line.Split(";");
                if (cell.Length == 2)
                {
                    Student student = new();
                    if (int.TryParse(cell[0], out int value))
                        student.Id = value;
                    else
                        throw new Exception($"error: Id в файле student.csv  в {count} строке должен быть целым числом");
                    student.Name = cell[1];
                    students.Add(student);
                }
                else if (cell.Length != 2)
                    throw new Exception($"error: Количество данных в {count} строке файла student.csv должно быть равно 2");
                count++;
            }
            return students;
        }

        public static List<Book> ParseBook(List<Book> books)
        {
            int count = default;
            foreach (string line in File.ReadLines("book.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] cell = line.Split(";");
                if (cell.Length == 6)
                {
                    Book book = new();
                    if (int.TryParse(cell[0], out int value))
                        book.Id = value;
                    else
                        throw new Exception($"error: Id в файле book.csv  в {count} строке должен быть целым числом");
                    book.Name = cell[1];
                    book.AuthorName = cell[2];
                    if (int.TryParse(cell[3], out value))
                        book.YearOfPublication = value;
                    else
                        throw new Exception($"Год публикации в файле book.csv  в {count} строке должен быть целым числом");
                    if (int.TryParse(cell[4], out value))
                        book.Case = value;
                    else
                        throw new Exception($"error: номер шкафа в файле book.csv  в {count} строке должен быть целым числом");
                    if (int.TryParse(cell[5], out value))
                        book.Shelf = value;
                    else
                        throw new Exception($"error: номер полки в файле book.csv  в {count} строке должен быть целым числом");
                    books.Add(book);
                }
                else 
                    throw new Exception($"error: Количество данных в {count} строке файла book.csv должно быть равно 6");
                count++;
            }
            return books;
        }
    }
}