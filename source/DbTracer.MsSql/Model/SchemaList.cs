using System;
using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class SchemaList<TSchemaType, TParentType> : List<TSchemaType>//, ISchemaList<TSchemaType, TParentType>
        where TSchemaType : SchemaBase
        where TParentType : SchemaBase
    {
        private Dictionary<string, int> nameMap = new Dictionary<string, int>();
        private StringComparison comparion;
        private bool IsCaseSensity;

        public SchemaList()
        {
            comparion = StringComparison.CurrentCultureIgnoreCase;
        }

        public SchemaList(TParentType parent)
        {
            Parent = parent;
        }

        public SchemaList<TSchemaType, TParentType> Clone()
        {
            var options = new SchemaList<TSchemaType, TParentType>();
            ForEach(item => options.Add((TSchemaType)item.Clone()));
            return options;
        }

        protected StringComparison Comparion
        {
            get { return comparion; }
        }

        public new void Add(TSchemaType item)
        {
            base.Add(item);

            var name = item.FullName;
            IsCaseSensity = item.Database.IsCaseSensitive;
            if (!IsCaseSensity)
                name = name.ToUpper();

            if (!nameMap.ContainsKey(name))
                nameMap.Add(name, Count - 1);
        }

        public TParentType Parent { get; set; }

        public TSchemaType Find(int id)
        {
            return Find(item => item.Id == id);
        }

        public Boolean Exists(string name)
        {
            return IsCaseSensity ? nameMap.ContainsKey(name) : nameMap.ContainsKey(name.ToUpper());
        }

        public virtual TSchemaType this[string name]
        {
            get
            {
                try
                {
                    return IsCaseSensity ? this[nameMap[name]] : this[nameMap[name.ToUpper()]];
                }
                catch
                {
                    return default(TSchemaType);
                }
            }
            set
            {
                if (IsCaseSensity)
                    base[nameMap[name]] = value;
                else
                    base[nameMap[name.ToUpper()]] = value;
            }
        }
    }
}