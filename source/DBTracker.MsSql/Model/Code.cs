using System;
using System.Collections.Generic;

namespace DbTracker.MsSql.Model
{
    public abstract class Code : MsSqlSchemaBase
    {
        protected string sql;
        protected string TypeName = "";
        private readonly int deepMin;

        protected Code(ObjectType1 type1, ScripActionType addAction, ScripActionType dropAction)
            : base(type1)
        {
            DependenciesIn = new List<String>();
            DependenciesOut = new List<String>();
            TypeName = GetObjectTypeName(ObjectType1);
            /*Por el momento, solo los Assemblys manejan deep de dependencias*/
            if (ObjectType1 == ObjectType1.Assembly)
            {
                deepMin = 500;
            }
        }

        public int DeepMin
        {
            get { return deepMin; }
        }

        private static string GetObjectTypeName(ObjectType1 type1)
        {
            switch (type1)
            {
                case ObjectType1.Rule:
                    return "RULE";
                case ObjectType1.Trigger:
                    return "TRIGGER";
                case ObjectType1.View:
                    return "VIEW";
                case ObjectType1.Function:
                    return "FUNCTION";
                case ObjectType1.StoreProcedure:
                    return "PROCEDURE";
                case ObjectType1.ClrStoreProcedure:
                    return "PROCEDURE";
                case ObjectType1.ClrTrigger:
                    return "TRIGGER";
                case ObjectType1.ClrFunction:
                    return "FUNCTION";
                case ObjectType1.Assembly:
                    return "ASSEMBLY";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Coleccion de objetos dependientes de la funcion.
        /// </summary>
        public List<String> DependenciesOut { get; set; }

        /// <summary>
        /// Coleccion de nombres de objetos de los cuales la funcion depende.
        /// </summary>
        public List<String> DependenciesIn { get; set; }

        public Boolean IsSchemaBinding { get; set; }

        public string Text { get; set; }

        //public override int DependenciesCount
        //{
        //    get
        //    {
        //        var iCount = 0;
        //        if (DependenciesOut.Count > 0)
        //        {
        //            var depencyTracker = new Dictionary<string, bool>();
        //            iCount = DependenciesCountFilter(FullName, depencyTracker);
        //        }
        //        return iCount;
        //    }
        //}

        //private int DependenciesCountFilter(string fullNamePar, IDictionary<string, bool> depencyTracker)
        //{
        //    var count = 0;
        //    ICode item;
        //    try
        //    {
        //        item = (ICode)((Database)Parent).Find(fullNamePar);
        //        if (item != null)
        //        {
        //            for (var j = 0; j < item.DependenciesOut.Count; j++)
        //            {
        //                if (!depencyTracker.ContainsKey(fullNamePar.ToUpper()))
        //                {
        //                    depencyTracker.Add(fullNamePar.ToUpper(), true);
        //                }
        //                count += 1 + DependenciesCountFilter(item.DependenciesOut[j], depencyTracker);
        //            }
        //        }
        //        return count;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        //public Boolean HasToRebuild
        //{
        //    get
        //    {
        //        for (var j = 0; j < DependenciesIn.Count; j++)
        //        {
        //            var item = ((Database)Parent).Find(DependenciesIn[j]);
        //            if (item == null) continue;
        //            if ((item.Status == ObjectStatus.RebuildStatus) || (item.Status == ObjectStatus.RebuildDependenciesStatus))
        //                return true;
        //        }
        //        return IsSchemaBinding;
        //    }
        //}

        //public virtual bool Compare(ICode obj)
        //{
        //    if (obj == null) throw new ArgumentNullException("obj");
        //    string sql1 = this.ToSql();
        //    string sql2 = obj.ToSql();
        //    if (((Database)Database).Options.Comparison.IgnoreWhiteSpacesInCode)
        //    {
        //        Regex whitespace = new Regex(@"\s");
        //        sql1 = whitespace.Replace(this.ToSql(), "");
        //        sql2 = whitespace.Replace(obj.ToSql(), "");
        //    }
        //    if (((Database)Database).Options.Comparison.CaseSensityInCode == Options.SqlOptionComparison.CaseSensityOptions.CaseInsensity)
        //        return (sql1.Equals(sql2, StringComparison.InvariantCultureIgnoreCase));

        //    return (sql1.Equals(sql2, StringComparison.InvariantCulture));
        //}
    }
}