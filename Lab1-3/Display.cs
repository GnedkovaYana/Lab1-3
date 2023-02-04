using System.Text;

namespace DB
{
    class Display
    {
        public static void Output(List<Book> books, List<ReaderBook> readerBooks)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Список всех книг:");

            foreach (Book book in books)
            {
                Console.WriteLine($"Автор: {book.Writer}, Название:\"{book.Name}\"");
                foreach (ReaderBook readerBook in readerBooks)
                {
                    if (book.Id == readerBook.Book.Id && readerBook.ReturnDate == null)
                        Console.Write($"Взял книгу: {readerBook.Reader.FullName}, Дата получения: {readerBook.TakeDate.ToShortDateString()}");
                }
                Console.WriteLine();
            }
        }
    }

}
