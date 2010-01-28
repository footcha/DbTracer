using System;

namespace DbTracker.MsSql.Model
{
    public class SqlScript : IComparable<SqlScript>
    {
        private ScripActionType status;
        private int deep;

        public SqlScript(int deepvalue, string sqlScript, int dependenciesCount, ScripActionType action)
        {
            Sql = sqlScript;
            Dependencies = dependenciesCount;
            status = action;
            deep = deepvalue;
            //childs = new SQLScriptList();
        }

        public SqlScript(string sqlScript, int dependenciesCount, ScripActionType action)
        {
            Sql = sqlScript;
            Dependencies = dependenciesCount;
            status = action;
            //childs = new SQLScriptList();
        }

        /*public SQLScriptList Childs
        {
            get { return childs; }
            set { childs = value; }
        }*/

        public int Deep
        {
            get { return deep; }
            set { deep = value; }
        }

        public ScripActionType Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Dependencies { get; set; }

        public string Sql { get; set; }

        public bool IsDropAction
        {
            get
            {
                return ((status == ScripActionType.DropView) || (status == ScripActionType.DropFunction) || (status == ScripActionType.DropStoreProcedure));
            }
        }

        public bool IsAddAction
        {
            get
            {
                return ((status == ScripActionType.AddView) || (status == ScripActionType.AddFunction) || (status == ScripActionType.AddStoreProcedure));
            }
        }

        public int CompareTo(SqlScript other)
        {
            if (deep == other.deep)
            {
                if (Status == other.Status)
                {
                    switch (Status)
                    {
                        case ScripActionType.DropTrigger:
                        case ScripActionType.DropConstraint:
                        case ScripActionType.DropTable:
                            return other.Dependencies.CompareTo(this.Dependencies);
                        default:
                            return Dependencies.CompareTo(other.Dependencies);
                    }
                }
                return Status.CompareTo(other.Status);
            }
            return Deep.CompareTo(other.Deep);
        }
    }
}