using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  

namespace Lesson2
{
   
        public static class FileManager
        {
            public static void WriteBooksToFile(List<Book> books, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Title},{book.Author},{book.Price},{book.Description}");
                    }
                }
            }

            public static List<Book> ReadBooksFromFile(string filePath)
            {
                List<Book> books = new List<Book>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            string title = parts[0];
                            string author = parts[1];
                            double price = double.Parse(parts[2]);
                            string desc = parts[3];
                            books.Add(new Book("ספר", 1, author, price, title, desc));
                        }
                    }
                }

                return books;
            }
        }
    }



