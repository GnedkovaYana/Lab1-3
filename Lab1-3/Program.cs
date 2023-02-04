namespace DB
{

    class Program
    {
        static void Main()
        {
            var test = new Test();
            List<Book> books = test.ListBooks($".\\books.csv", "books.csv");
            List<Reader> readers = test.ListReader($".\\readers.csv", "readers.csv");
            List<ReaderBook> readerBooks = test.ListReaderBook($".\\readerBook.csv", "readerBook.csv", readers, books);
            Display.Output(books, readerBooks);
        }
    }
}
