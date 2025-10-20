namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shelf<Book>> bookShelves = new List<Shelf<Book>>
        {
            new Shelf<Book>(1, 1, 10),
            new Shelf<Book>(1, 2, 15),
            new Shelf<Book>(2, 1, 8)
        };
            bookShelves[0].Items.Add(new Book("MyBook",200,"T.R", 120,"Hi" ,"Baby"));
            bookShelves[0].Items.Add(new Book("MyBook1",600,"R.F",  200, "MyStory","Adult"));
            bookShelves[1].Items.Add(new Book("MyBook2",100,"S.F",  50,"Hello", "ForKids"));
            bookShelves[1].Items.Add(new Book("MyBook3",500,"R.V",  180,"My","Comics" ));
            bookShelves[2].Items.Add(new Book("MyBook4",340,"R.J",  150,"dear","History" ));



            //1
            Console.WriteLine("מדפים מלאים:");
            var fullShelves = bookShelves.Where(s => s.Items.Sum(i => i.Weight) >= s.MaxWeight);
            foreach (var shelf in fullShelves) Console.WriteLine(shelf);
            //2
            Console.WriteLine("\nמדפים עם ספרי ילדים:");
            var kidsShelves = bookShelves.Where(s => s.Items.Any(b => b.Description== "ForKids"));
            foreach (var shelf in kidsShelves) Console.WriteLine(shelf);
            //3
            Console.WriteLine("\nמדפים עם ספרים יקרים (מעל 150 ₪):");
            var expensiveShelves = bookShelves.Where(s => s.Items.Any(b => b.Price > 150));
            foreach (var shelf in expensiveShelves) Console.WriteLine(shelf);
            //4
            Console.WriteLine("\nמדף עם הספר הכי יקר:");
            var shelfWithMostExpensive = bookShelves
                .OrderByDescending(s => s.Items.Max(b => b.Price))
                .FirstOrDefault();
            Console.WriteLine(shelfWithMostExpensive);


            //5
            Console.WriteLine("\nספרים קלים (פחות מ-4 ק\"ג):");
            var lightBooks = bookShelves
                .SelectMany(s => s.Items)
                .Where(b => b.Weight < 4);

            foreach (var book in lightBooks)
                Console.WriteLine(book);

            var q2 = bookShelves[0].Search(b => b.Author == "R.V");

            var q3 = bookShelves[0].Search(b =>  b.Price < 100);

            var q4 = bookShelves[0].Search(b => b.Description== "History");
            var q1 = bookShelves[0].Search(b => b.Weight >100);

            try
            {
                var expensiveBooks = bookShelves[0].Search(b =>
                {
                    if (b.Price < 0) throw new Exception($" {b.Title} לא חוקי");
                    return b.Price > 60;
                });

                foreach (var book in expensiveBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("שגיאה בחיפוש: " + ex.Message);
            }

            List<Book> safeBooks;

            try
            {
                safeBooks = bookShelves[0].Search(b =>
                {
                    if (b.Price < 0)
                    {
                        throw new Exception($"מחיר שלילי בספר {b.Title} לא חוקי");
                    }
                    return b.Description=="ForKids";  
                });
            }
            catch
            {
                safeBooks = new List<Book>();
            }

            Console.WriteLine("ספרי ילדים :");
            foreach (var book in safeBooks)
            {
                Console.WriteLine(book.Title);
            }


            //  עשיתי שהוא שומר את רק את הספרים מהמדף הראשון כי זה היה לי יותר קל  וברור  
            string path = "books.txt";

            FileManager.WriteBooksToFile(bookShelves[0].Items, path);
            Console.WriteLine(" הספרים נשמרו לקובץ ");

            var booksFromFile = FileManager.ReadBooksFromFile(path);
            Console.WriteLine(" הספרים שנקראו מהקובץ");
            foreach (var book in booksFromFile)
            {
                Console.WriteLine($"{book.Title} - {book.Author} ({book.Price}₪)");
            }








        }
    }
}
