namespace DB
{
    class Table
    {
        public int MaxLenNameReader(List<Reader> readers, List<Book> books, List<ReaderBook> readerBooks)
        {
            int maxLenNameReader = 0;
            foreach (Book book in books)
            {
                foreach(ReaderBook readerBook in readerBooks)
                {
                    if (book.Id == readerBook.Book.Id)
                        maxLenNameReader = Math.Max(maxLenNameReader, readerBook.Reader.FullName.Length);
                }
            }
            return maxLenNameReader;
        }

        public int MaxLenWriter(List<Book> books)
        {
            int maxLenWriter = 0;
            foreach (Book book in books)
            {
                maxLenWriter = Math.Max(maxLenWriter, book.Writer.Length);
            }
            return maxLenWriter;
        }

        public int MaxLenNameBook(List<Book> books)
        {
            int maxLenBook = 0;
            foreach(Book book in books)
            {
                maxLenBook = Math.Max(maxLenBook, book.Name.Length);
            }
            return maxLenBook;
        }

        public void Headline(int maxLenNameReader, int maxLenWriter, int maxLenNameBook)
        {

            Console.Write("┌");
            Console.Write(new string('─', maxLenWriter + maxLenNameBook + maxLenNameReader + 10 + 3));
            Console.WriteLine("┐");

            Console.Write("│");
            Console.Write("Автор".PadRight(maxLenWriter));
            Console.Write("│");
            Console.Write("Название".PadRight(maxLenNameBook));
            Console.Write("│");
            Console.Write("Читает".PadRight(maxLenNameReader));
            Console.Write("│");
            Console.Write("Взял".PadRight(10));
            Console.WriteLine("│");

            Console.Write("│");
            Console.Write(new string('─', maxLenWriter));
            Console.Write("│");
            Console.Write(new string('─', maxLenNameBook));
            Console.Write("│");
            Console.Write(new string('─', maxLenNameReader));
            Console.Write("│");
            Console.Write(new string('─', 10));
            Console.WriteLine("│");
        }

        public void TableOfContents(List<Book> books, List<ReaderBook> readerBooks, int maxLenNameReader, int maxLenWriter, int maxLenNameBook)
        {
            foreach (Book book in books)
            {
                Console.Write("│");
                Console.Write(book.Writer.PadRight(maxLenWriter));
                Console.Write("│");

                Console.Write(book.Name.PadRight(maxLenNameBook));
                Console.Write("│");

                string readerName = "";
                DateTime takeDate = DateTime.MinValue;
                foreach (ReaderBook readerBook in readerBooks)
                {
                    if (readerBook.Book.Id == book.Id && readerBook.ReturnDate == null)
                    {
                        readerName = readerBook.Reader.FullName;
                        takeDate = readerBook.TakeDate;
                    }
                }

                Console.Write(readerName.PadRight(maxLenNameReader));
                Console.Write("│");

                if (takeDate != DateTime.MinValue)
                {
                    Console.Write(takeDate.ToShortDateString());
                }
                else
                {
                    Console.Write(new string(' ', 10));
                }

                Console.WriteLine("│");
            }
            Console.Write("└");
            Console.Write(new string('─', maxLenWriter + maxLenNameBook + maxLenNameReader + 10+3));
            Console.WriteLine("┘");
        }

        public void TableDisplay(List<Book> books, List<ReaderBook> readerBooks, List<Reader> readers)
        {
            int maxLenWriter = MaxLenWriter(books);
            int maxLenNameBook = MaxLenNameBook(books);
            int maxLenNameReader = MaxLenNameReader(readers, books, readerBooks);

            Headline(maxLenNameReader, maxLenWriter, maxLenNameBook);
            TableOfContents(books, readerBooks, maxLenNameReader, maxLenWriter, maxLenNameBook);
        }
    }
}
