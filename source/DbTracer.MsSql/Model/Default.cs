namespace DbTracer.MsSql.Model
{
    public class Default : MsSqlSchemaBase
    {
        public Default()
            : base(ObjectType1.Default)
        {
        }

        public new Default Clone()
        {
            return new Default
            {
                Id = Id,
                Name = Name,
                Owner = Owner,
                Value = Value
            };
        }

        public string Value { get; set; }
    }
}