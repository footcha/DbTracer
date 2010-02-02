using System.Collections.Generic;
using System.Text;

namespace DbTracer.MsSql.Model
{
    public class SqlScriptList
    {
        private List<SqlScript> list;

        public void Sort()
        {
            if (list != null) list.Sort();
        }

        public void Add(SqlScript item, int deep)
        {
            if (list == null) list = new List<SqlScript>();
            if (item != null)
            {
                item.Deep = deep;
                list.Add(item);
            }
        }

        public void Add(SqlScript item)
        {
            if (list == null) list = new List<SqlScript>();
            if (item != null) list.Add(item);
        }

        public void Add(string SQL, int dependencies, ScripActionType type)
        {
            if (list == null) list = new List<SqlScript>();
            list.Add(new SqlScript(SQL, dependencies, type));
        }

        public void AddRange(SqlScriptList items)
        {
            for (int j = 0; j < items.Count; j++)
            {
                if (list == null) list = new List<SqlScript>();
                list.Add(items[j]);
            }
        }

        public int Count
        {
            get { return (list == null) ? 0 : list.Count; }
        }

        public SqlScript this[int index]
        {
            get { return list[index]; }
        }

        /*private string ToSqlDown(SqlScript item)
        {
            string sql = "";
            for (int i = 0; i < item.Childs.Count; i++)
            {
                for (int k = 0; k < item.Childs[i].Childs.Count; k++)
                {
                    for (int h = 0; h < item.Childs[i].Childs[k].Childs.Count; h++)
                    {
                        for (int l = 0; l < item.Childs[i].Childs[k].Childs[h].Childs.Count; l++)
                        {
                            for (int m = 0; m < item.Childs[i].Childs[k].Childs[h].Childs[l].Childs.Count; m++)
                            {
                                sql += item.Childs[i].Childs[k].Childs[h].Childs[l].Childs[m].Sql;
                            }
                            sql += item.Childs[i].Childs[k].Childs[h].Childs[l].Sql;
                        }
                        sql += item.Childs[i].Childs[k].Childs[h].Sql;
                    }
                    sql += item.Childs[i].Childs[k].Sql;
                }
                sql += item.Childs[i].Sql;
            }
            sql += item.Sql;
            return sql;
        }*/

        public string ToSQL()
        {
            StringBuilder sql = new StringBuilder();
            Sort(); /*Ordena la lista antes de generar el script*/
            if (list != null)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    //if ((list[j].IsDropAction) || (!list[j].IsAddAction))
                    sql.Append(list[j].Sql); //ToSqlDown(list[j]);
                }
                /*for (int j = list.Count-1; j >= 0; j--)
                {
                    if (list[j].IsAddAction)
                        sql.Append(list[j].Sql);
                }*/

            }
            return sql.ToString();
        }

        public SqlScriptList FindAlter()
        {
            SqlScriptList alter = new SqlScriptList();
            list.ForEach(item => { if ((item.Status == ScripActionType.AlterView) || (item.Status == ScripActionType.AlterFunction) || (item.Status == ScripActionType.AlterProcedure)) alter.Add(item); });
            return alter;
        }
    }
}