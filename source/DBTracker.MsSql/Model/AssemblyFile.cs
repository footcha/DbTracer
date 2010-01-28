
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class AssemblyFile : MsSqlSchemaBase
    {
        private string content;

        public AssemblyFile(ISchema parent, AssemblyFile assemblyFile, ObjectStatus status)
            : base(parent, MsSql.ObjectType1.AssemblyFile)
        {
            Name = assemblyFile.Name;
            content = assemblyFile.content;
            Status = status;
        }

        public AssemblyFile(ISchema parent, string name, string content)
            : base(parent,MsSql.ObjectType1.AssemblyFile)
        {
            Name = name;
            this.content = content;
        }

        public override string FullName
        {
            get { return "[" + Name + "]"; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}