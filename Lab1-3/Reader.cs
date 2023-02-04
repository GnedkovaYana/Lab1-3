namespace DB
{
    class Reader
    {
        public uint Id;
        public string? FullName;

        public Reader(uint id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
