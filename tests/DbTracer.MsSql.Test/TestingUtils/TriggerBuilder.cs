using System;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Test.TestingUtils
{
    public class TriggerBuilder
    {
        private Schema schema;
        private Table table;

        public TriggerBuilder With(Schema schema)
        {
            this.schema = schema;
            return this;
        }

        public TriggerBuilder With(Table table)
        {
            this.table = table;
            return this;
        }

        public Trigger Build(Trigger trigger)
        {
            if (table == null) table = new TableBuilder().Build();
            table.Triggers.Add(trigger);
            trigger.ParentObject = table;
            trigger.Schema = schema ?? new SchemaBuilder().Build();
            trigger.Type = SqlObjectType.SqlDmlTrigger;


            return trigger;
        }

        public Trigger Build()
        {
            var trigger = new Trigger
            {
                CreateDate = new DateTime(2010, 6, 15),
                Definition = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END",
                Id = -1,
                IsDisabled = true,
                IsInsteadOfTrigger = false,
                IsMsShipped = true,
                IsNotForReplication = true,
                IsPublished = true,
                IsSchemaPublished = true,
                ModifyDate = new DateTime(2010, 7, 20),
                Name = "test_trigger",
                Type = SqlObjectType.SqlDmlTrigger
            };

            return Build(trigger);
        }
    }
}