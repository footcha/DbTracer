using System;
using System.Diagnostics;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    [DebuggerDisplay("Id: {Id} - Name: {Name} - Status: {status}")]
    public abstract class SchemaBase : ISchema
    {
        private ObjectStatus status;
        private ISchema parent;
        protected readonly string NameCharacterOpen = "[";
        protected readonly string NameCharacterClose = "]";
        private Database database;

        protected SchemaBase(ObjectType1 objectType1)
        {
            Guid = System.Guid.NewGuid().ToString();
            ObjectType1 = objectType1;
            status = ObjectStatus.OriginalStatus;
        }

        public virtual ISchema Parent
        {
            get { return parent; }
            set
            {
                database = null;
                parent = value;
            }
        }

        public virtual Database Database
        {
            get
            {
                if (database != null) return database;

                var par = Parent;
                while (par != null)
                {
                    var db = par as Database;
                    if (db != null) database = db;
                    else par = par.Parent;
                }

                return database;
            }
        }

        IDatabase ISchema.Database
        {
            get { return Database; }
        }

        public virtual int CompareFullNameTo(string namePar, string myName)
        {
            return !Database.IsCaseSensitive
                ? myName.ToUpper().CompareTo(namePar.ToUpper())
                : myName.CompareTo(namePar);
        }

        public virtual ISchema Clone()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// GUID unico que identifica al objeto.
        /// </summary>
        public virtual string Guid { get; private set; }

        /// <summary>
        /// Tipo de objeto (Tabla, Column, Vista, etc)
        /// </summary>
        public virtual ObjectType1 ObjectType1 { get; set; }

        Enum ISchema.ObjectType
        {
            get { return ObjectType1; }
            set { ObjectType1 = (ObjectType1)value; }
        }

        /// <summary>
        /// ID del objeto.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Nombre completo del objeto, incluyendo el owner.
        /// </summary>
        public virtual string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(Owner))
                    return NameCharacterOpen + Name + NameCharacterClose;
                return NameCharacterOpen + Owner + NameCharacterClose + "." + NameCharacterOpen + Name + NameCharacterClose;
            }
        }

        /// <summary>
        /// Nombre de usuario del owner de la tabla.
        /// </summary>
        public virtual string Owner { get; set; }

        /// <summary>
        /// Nombre del objecto
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Determine if the database object if a System object or not
        /// </summary>
        public virtual Boolean IsSystem { get; set; }

        /// <summary>
        /// Indica el estado del objeto (si es propio, si debe borrarse o si es nuevo). Es solo valido
        /// para generar el Sql de diferencias entre 2 bases. 
        /// Por defecto es siempre Original.
        /// </summary>
        public virtual ObjectStatus Status
        {
            get { return status; }
            set
            {
                if ((status != ObjectStatus.RebuildStatus) && (status != ObjectStatus.RebuildDependenciesStatus))
                    status = value;
                if (Parent != null)
                {
                    //Si el estado de la tabla era el original, lo cambia, sino deja el actual estado.
                    if (Parent.Status == ObjectStatus.OriginalStatus || value == ObjectStatus.RebuildStatus || value == ObjectStatus.RebuildDependenciesStatus)
                    {
                        if ((value != ObjectStatus.OriginalStatus) && (value != ObjectStatus.RebuildStatus) && (value != ObjectStatus.RebuildDependenciesStatus))
                            Parent.Status = ObjectStatus.AlterStatus;
                        if (value == ObjectStatus.RebuildDependenciesStatus)
                            Parent.Status = ObjectStatus.RebuildDependenciesStatus;
                        if (value == ObjectStatus.RebuildStatus)
                            Parent.Status = ObjectStatus.RebuildStatus;
                    }
                }
            }
        }

        public virtual Boolean HasState(ObjectStatus statusFind)
        {
            return ((Status & statusFind) == statusFind);
        }

        public virtual Boolean IsCodeType
        {
            get { return false; }
        }

        public virtual int DependenciesCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Get if the Sql commands for the collection must build in one single statement
        /// or one statmente for each item of the collection.
        /// </summary>
        public virtual Boolean MustBuildSqlInLine
        {
            get { return false; }
        }
    }
}