using System;
using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class XmlSchema : MsSqlSchemaBase
    {
        public XmlSchema()
            : base(ObjectType1.XmlSchema)
        {
            Dependencies = new List<ObjectDependency>();
        }

        /// <summary>
        /// Clona el objeto en una nueva instancia.
        /// </summary>
        public new XmlSchema Clone()
        {
            return new XmlSchema
            {
                Text = Text,
                Status = Status,
                Name = Name,
                Id = Id,
                Owner = Owner,
                Dependencies = Dependencies
            };
        }

        public List<ObjectDependency> Dependencies { get; set; }

        public string Text { get; set; }

        public bool Compare(XmlSchema obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            return Text.Equals(obj.Text);
        }
    }
}