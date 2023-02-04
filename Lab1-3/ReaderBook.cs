namespace DB
{
    class ReaderBook
    {
        public Reader? Reader;
        public Book? Book;
        public DateTime TakeDate;
        public DateTime? ReturnDate;

        public ReaderBook(Reader reader, Book book, DateTime takeDate, DateTime? returnDate)
        {
            Reader = reader;
            Book = book;
            TakeDate = takeDate;
            ReturnDate = returnDate;
        }
    }
}
