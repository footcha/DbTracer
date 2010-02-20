using System;
using System.Collections.Generic;
using DbTracer.Core;
using DbTracer.Core.Schema.Model;
using DbTracer.MsSql.Options;

namespace DbTracer.MsSql.Model
{
    public class Database : MsSqlSchemaBase, IDatabase
    {
        public Database()
            : base(ObjectType1.Database)
        {
            //AllObjects = new SearchSchemaBase();
            Assemblies = new SchemaList<Assembly, Database>(this);
            ClrFunctions = new SchemaList<ClrFunction, Database>(this);
            ClrProcedures = new SchemaList<ClrStoreProcedure, Database>(this);
            //DdlTriggers = new SchemaList<Trigger, Database>(this);
            Defaults = new SchemaList<Default, Database>(this);
            Dependencies = new Dependencies();
            FileGroups = new SchemaList<FileGroup, Database>();
            FullText = new SchemaList<FullText, Database>(this);
            //Functions = new SchemaList<Function, Database>(this);
            //IsCaseSensitive = true;
            //Options = 
            PartitionFunctions = new SchemaList<PartitionFunction, Database>(this);
            PartitionSchemes = new SchemaList<PartitionScheme, Database>(this);
            Procedures = new SchemaList<StoreProcedure, Database>(this);
            Properties = new DatabaseProperties();
            //Roles = new SchemaList<Role, Database>();
            Rules = new SchemaList<Rule, Database>(this);
            Schemas = new SchemaList<SchemaObsolete, Database>(this);
            Synonyms = new SchemaList<Synonym, Database>(this);
            //Tables = new SchemaList<Table, Database>(this);
            TablesTypes = new SchemaList<TableType, Database>(this);
            Users = new SchemaList<User, Database>(this);
            UserTypes = new SchemaList<UserDataType, Database>(this);
            //Views = new SchemaList<View, Database>(this);
            XmlSchemas = new SchemaList<XmlSchema, Database>(this);
        }

        //internal SearchSchemaBase AllObjects { get; private set; }

        #region Database objects

        [Description("Full Text Catalog")]
        public SchemaList<FullText, Database> FullText { get; private set; }

        [Description("Table Types")]
        public SchemaList<TableType, Database> TablesTypes { get; private set; }

        [Description("Partition Scheme")]
        public SchemaList<PartitionScheme, Database> PartitionSchemes { get; private set; }

        [Description("Partition Functions")]
        public SchemaList<PartitionFunction, Database> PartitionFunctions { get; private set; }

        [Description("Defaults")]
        public SchemaList<Default, Database> Defaults { get; private set; }

        //[Description("Roles")]
        //public SchemaList<Role, Database> Roles { get; private set; }

        //[Description("Functions")]
        //public SchemaList<Function, Database> Functions { get; private set; }

        [Description("Users")]
        public SchemaList<User, Database> Users { get; private set; }

        //[Description("Views")]
        //public SchemaList<View, Database> Views { get; private set; }

        [Description("Assemblies")]
        public SchemaList<Assembly, Database> Assemblies { get; private set; }

        [Description("Synonyms")]
        public SchemaList<Synonym, Database> Synonyms { get; private set; }

        //[Description("DLL Triggers")]
        //public SchemaList<Trigger, Database> DdlTriggers { get; private set; }

        [Description("File Groups")]
        public SchemaList<FileGroup, Database> FileGroups { get; private set; }

        [Description("Rules")]
        public SchemaList<Rule, Database> Rules { get; private set; }

        [Description("Stored Procedures")]
        public SchemaList<StoreProcedure, Database> Procedures { get; private set; }

        [Description("CLR Stored Procedures")]
        public SchemaList<ClrStoreProcedure, Database> ClrProcedures { get; private set; }

        [Description("CLR Functions")]
        public SchemaList<ClrFunction, Database> ClrFunctions { get; private set; }

        [Description("Schemas")]
        public SchemaList<SchemaObsolete, Database> Schemas { get; private set; }

        [Description("Xml Schemas")]
        public SchemaList<XmlSchema, Database> XmlSchemas { get; private set; }

        //[Description("Tables")]
        //public SchemaList<Table, Database> Tables { get; private set; }

        [Description("User Types")]
        public SchemaList<UserDataType, Database> UserTypes { get; private set; }

        public SqlOption Options { get; set; }

        public DatabaseProperties Properties { get; set; }

        #endregion

        internal Dependencies Dependencies { get; set; }

        public override ISchema Clone()
        {
            throw new NotSupportedException();
        }

        public Boolean IsCaseSensitive
        {
            get
            {
                var isCs = false;
                if (!String.IsNullOrEmpty(Properties.Collation))
                    isCs = Properties.Collation.IndexOf("_CS_") != -1;

                if (Options.Comparison.CaseSensityType == SqlOptionComparison.CaseSensityOptions.Automatic)
                    return isCs;
                return Options.Comparison.CaseSensityType == SqlOptionComparison.CaseSensityOptions.CaseSensity;
            }
        }

        public void BuildDependency()
        {
            ISchema schema;
            var indexes = new List<Index>();
            var constraints = new List<Constraint>();

            //Tables.ForEach(item => indexes.AddRange(item.Indexes));
            //Views.ForEach(item => indexes.AddRange(item.Indexes));
            //Tables.ForEach(item => constraints.AddRange(item.Constraints));

            //foreach (Index index in indexes)
            //{
            //    schema = index.Parent;
            //    foreach (IndexColumnObsolete icolumn in index.Columns)
            //    {
            //        Dependencies.Add(this, schema.Id, icolumn.Id, schema.Id, icolumn.DataTypeId, index);
            //    }
            //}

            foreach (Constraint con in constraints)
            {
                schema = con.Parent;
                if (con.Type != Constraint.ConstraintType.Check)
                {
                    foreach (ConstraintColumn ccolumn in con.Columns)
                    {
                        Dependencies.Add(this, schema.Id, ccolumn.Id, schema.Id, ccolumn.DataTypeId, con);
                        if (con.Type == Constraint.ConstraintType.ForeignKey)
                        {
                            Dependencies.Add(this, con.RelationalTableId, ccolumn.ColumnRelationalId, schema.Id,
                                             ccolumn.ColumnRelationalDataTypeId, con);
                        }
                        //else
                        //{
                            //if (
                            //    ((Table)schema).FullTextIndex.Exists(
                            //        item => { return item.Index.Equals(con.Name); }))
                            //{
                            //    Dependencies.Add(this, schema.Id, 0, schema.Id, 0, con);
                            //}
                        //}
                    }
                }
                else
                    Dependencies.Add(this, schema.Id, 0, schema.Id, 0, con);
            }
        }
    }
}