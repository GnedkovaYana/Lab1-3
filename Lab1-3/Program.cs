namespace DB
{

    class Program
    {
        static void Main()
        {
            Test test = new Test();
            Table table = new Table();
            List<Book> books = test.ListBooks($".\\books.csv", "books.csv");
            List<Reader> readers = test.ListReader($".\\readers.csv", "readers.csv");
            List<ReaderBook> readerBooks = test.ListReaderBook($".\\readerBook.csv", "readerBook.csv", readers, books);
            table.TableDisplay(books, readerBooks, readers);
        }
    }
}
