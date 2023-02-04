namespace DB
{
    class Test
    {
        public List<uint> IdBook = new List<uint>();
        public List<uint> IdReader = new List<uint>();

        public string? BooksFile;
        public string? ReaderFile;
        public string? ReaderBookFile;
        public List<Book> ListBooks(string path, string fileName)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(path);
            BooksFile = fileName;
            BookСolumnСount(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] el = lines[i].Split(';');
                books.Add(
                    new Book(
                        BookId(el[0], i),
                        BookWriter(el[1], i),
                        BookName(el[2], i),
                        BookPublication(el[3], i),
                        BookCaseNum(el[4], i),
                        BookShelfNum(el[5], i)));
            }
            return books;
        }

        public void BookСolumnСount(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(';').Length != 6)
                {
                    throw new ArgumentException($"\nОшибка в файле {BooksFile}: количество столбцов задано неверно\n");
                }
            }
        }

        public uint BookId(string el, int i)
        {
            if (!uint.TryParse(el, out uint bookId))
                throw new ArgumentException($"\nОшибка в файле {BooksFile}: неверный тип данных в столбце id в строке {i + 1}\n");
            if (IdBook.Contains(bookId))
                throw new ArgumentException($"\nОшибка в файле {BooksFile}: повторяющийся id в строке {i + 1}\n");

            IdBook.Add(bookId);
            return bookId;
        }

        public string BookWriter(string el, int i)
        {
            if (el == "")
                throw new ArgumentException($"\nОшибка в файле {BooksFile}:  отсутствует имя автора в строке {i + 1}\n");
            return el;
        }

        public string BookName(string el, int i)
        {
            if (el == "")
                throw new ArgumentException($"\nОшибка в файле {BooksFile}: отсутствует название книги в строке {i + 1}\n");
            return el;
        }

        public uint BookPublication(string el, int i)
        {
            if (!uint.TryParse(el, out uint publicDate))
                throw new ArgumentException($"\nОшибка в файле {BooksFile}: указана неверная дата публикации книги  в строке {i + 1}\n");
            return publicDate;
        }

        public uint BookCaseNum(string el, int i)
        {
            if (!uint.TryParse(el, out uint bookCase))
                throw new ArgumentException($"\nОшибка в файле {BooksFile}: указан неверный номер шкафа в строке {i + 1}\n");
            return bookCase;
        }

        public uint BookShelfNum(string el, int i)
        {
            if (!uint.TryParse(el, out uint bookShelf))
                throw new ArgumentException($"Ошибка в файле {BooksFile}: указан неверный номер полки в строке {i + 1}");
            return bookShelf;
        }

        public List<Reader> ListReader(string path, string fileName)
        {
            List<Reader> readers = new List<Reader>();
            string[] lines = File.ReadAllLines(path);
            ReaderFile = fileName;
            ReaderСolumnСount(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] el = lines[i].Split(';');
                readers.Add(
                    new Reader(
                        ReaderId(el[0], i),
                        ReaderFullName(el[1], i)));
            }
            return readers;
        }

        public void ReaderСolumnСount(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(';').Length != 2)
                {
                    throw new ArgumentException($"Ошибка в файле {ReaderFile}: количество столбцов задано неверно");
                }
            }
        }

        public uint ReaderId(string el, int i)
        {
            if (!uint.TryParse(el, out uint readerId))
                throw new ArgumentException($"Ошибка в файле {ReaderFile}: неверный тип данных в столбце id в строке {i + 1}");
            if (IdReader.Contains(readerId))
                throw new ArgumentException($"Ошибка в файле {ReaderFile}: повторяющийся id в строке {i + 1}");
            IdReader.Add(readerId);
            return readerId;
        }

        public string ReaderFullName(string el, int i)
        {
            if (el == "")
                throw new ArgumentException($"Ошибка в файле {ReaderFile}:  отсутствует имя читателя в строке {i + 1}");
            return el;
        }

        public List<ReaderBook> ListReaderBook(string parth, string fileName, List<Reader> readers, List<Book> books)
        {
            List<ReaderBook> readerBooks = new List<ReaderBook>();
            string[] lines = File.ReadAllLines(parth);
            ReaderBookFile = fileName;
            ReaderBookСolumnСount(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] el = lines[i].Split(";");
                readerBooks.Add(
                    new ReaderBook(
                        CheckReader(el[0], i, readers),
                        CheckReaderBook(el[1], i, books),
                        ReaderTakeDate(el[2], i),
                        ReaderReturnDate(el[3], i)));
            }
            return readerBooks;
        }

        public void ReaderBookСolumnСount(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(';').Length != 4)
                {
                    throw new ArgumentException($"Ошибка в файле {ReaderBookFile}: количество столбцов задано неверно");
                }
            }
        }

        public Reader CheckReader(string el, int i, List<Reader> readers)
        {
            if (!uint.TryParse(el, out uint readerId))
                throw new ArgumentException($"Ошибка в файле {ReaderBookFile}:  неверный тип данных в столбце readerId в строке {i + 1}");
            foreach (Reader reader in readers)
            {
                if (reader.Id == readerId)
                    return reader;
            }
            throw new ArgumentException($"Ошибка в файле {ReaderBookFile}: нет данных о читателе с Id {readerId} в строке {i + 1}");
        }

        public Book CheckReaderBook(string el, int i, List<Book> books)
        {
            if (!uint.TryParse(el, out uint bookId))
                throw new ArgumentException($"Ошибка в файле {ReaderBookFile}:  неверный тип данных в столбце bookId в строке {i + 1}");
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                    return book;
            }
            throw new ArgumentException($"Ошибка в файле {ReaderBookFile}: нет данных о книге с Id {bookId} в строке {i + 1}");
        }

        public DateTime ReaderTakeDate(string el, int i)
        {
            if (!DateTime.TryParse(el, out DateTime takeDate))
                throw new ArgumentException($"Ошибка в файле {ReaderBookFile}: указана неверная дата получения книги  в строке {i + 1}");
            return takeDate;
        }

        public DateTime? ReaderReturnDate(string el, int i)
        {
            if (el == "")
                return null;
            if (!DateTime.TryParse(el, out DateTime returnDate))
                throw new ArgumentException($"Ошибка в файле {ReaderBookFile}: указана неверная дата возврата книги  в строке {i + 1}");
            return returnDate;
        }
    }
}