using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class SqlAction
    {
        private ObjectStatus action;
        private readonly List<SqlAction> childs;

        public SqlAction(SchemaBase item)
        {
            if ((item.ObjectType1 == ObjectType1.Column) || (item.ObjectType1 == ObjectType1.Index) || (item.ObjectType1 == ObjectType1.Constraint))
                Name = item.Name;
            else
                Name = item.FullName;
            action = item.Status;
            Type1 = item.ObjectType1;
            childs = new List<SqlAction>();
        }

        public void Add(SchemaBase item)
        {
            childs.Add(new SqlAction(item));
        }

        public SqlAction this[string name]
        {
            get
            {
                for (var j = 0; j < childs.Count; j++)
                {
                    if (childs[j].Name.Equals(name))
                        return childs[j];
                }
                return null;
            }
        }

        public string Name { get; private set; }

        public ObjectType1 Type1 { get; set; }

        public ObjectStatus Action
        {
            get { return action; }
            set { action = value; }
        }

        public List<SqlAction> Childs
        {
            get { return childs; }
        }

        private string GetTypeName()
        {
            if (Type1 == ObjectType1.Table) return "TABLE";
            if (Type1 == ObjectType1.Column) return "COLUMN";
            if (Type1 == ObjectType1.Constraint) return "CONSTRAINT";
            if (Type1 == ObjectType1.Index) return "INDEX";
            if (Type1 == ObjectType1.View) return "VIEW";
            if (Type1 == ObjectType1.StoreProcedure) return "STORE PROCEDURE";
            if (Type1 == ObjectType1.Synonym) return "SYNONYM";
            if (Type1 == ObjectType1.Function) return "FUNCTION";
            if (Type1 == ObjectType1.Assembly) return "ASSEMBLY";
            if (Type1 == ObjectType1.Trigger) return "TRIGGER";
            return "";
        }

        private bool IsRoot
        {
            get
            {
                return ((Type1 != ObjectType1.Function) && (Type1 != ObjectType1.StoreProcedure) && (Type1 != ObjectType1.View) && (Type1 != ObjectType1.Table) && (Type1 != ObjectType1.Database));
            }
        }

        public string Message
        {
            get
            {
                var message = "";
                if (action == ObjectStatus.DropStatus)
                    message = "DROP " + GetTypeName() + " " + Name + "\r\n";
                if (action == ObjectStatus.CreateStatus)
                    message = "ADD " + GetTypeName() + " " + Name + "\r\n";
                if ((action == ObjectStatus.AlterStatus) || (action == ObjectStatus.RebuildStatus) || (action == ObjectStatus.RebuildDependenciesStatus))
                    message = "MODIFY " + GetTypeName() + " " + Name + "\r\n";

                childs.ForEach(item =>
                                   {
                                       if (item.IsRoot)
                                           message += "    ";
                                       message += item.Message;
                                   });
                return message;
            }
        }
    }
}