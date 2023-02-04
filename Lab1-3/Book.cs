namespace DB
{
    class Book
    {
        public uint Id;
        public string? Writer;
        public string? Name;
        public uint Publication;
        public uint CaseNumber;
        public uint ShelfNumber;

        public Book(uint id, string writer, string name, uint publication, uint caseNumber, uint shelfNumber)
        {
            Id = id;
            Writer = writer;
            Name = name;
            Publication = publication;
            CaseNumber = caseNumber;
            ShelfNumber = shelfNumber;
        }
    }
}
