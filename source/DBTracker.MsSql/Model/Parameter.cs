namespace DbTracker.MsSql.Model
{
    public class Parameter
    {
        public bool Output { get; set; }

        public byte Scale { get; set; }

        public byte Precision { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }
    }
}