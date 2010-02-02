using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Constraint : MsSqlSchemaBase
    {
        public enum ConstraintType
        {
            None = 0,
            PrimaryKey = 1,
            ForeignKey = 2,
            Default = 3,
            Unique = 4,
            Check = 5
        }

        public Constraint()
            : base(ObjectType1.Constraint)
        {
            Columns = new ConstraintColumns();
            Index = new Index();
        }

        /// <summary>
        /// Clona el objeto Column en una nueva instancia.
        /// </summary>
        public override ISchema Clone()
        {
            return new Constraint
            {
                Id = Id,
                Name = Name,
                NotForReplication = NotForReplication,
                RelationalTableFullName = RelationalTableFullName,
                Status = Status,
                Type = Type,
                WithNoCheck = WithNoCheck,
                OnDeleteCascade = OnDeleteCascade,
                OnUpdateCascade = OnUpdateCascade,
                Owner = Owner,
                Columns = Columns.Clone(),
                //Index = (Index)Index.Clone(),
                IsDisabled = IsDisabled,
                Definition = Definition
            };
        }

        /// <summary>
        /// Informacion sobre le indice asociado al Constraint.
        /// </summary>
        public Index Index { get; set; }

        /// <summary>
        /// Coleccion de columnas de la constraint.
        /// </summary>
        public ConstraintColumns Columns { get; set; }

        /// <summary>
        /// Indica si la constraint tiene asociada un indice Clustered.
        /// </summary>
        public Boolean HasClusteredIndex
        {
            get
            {
                //if (Index != null)
                //    return (Index.Type == Index.IndexType.Clustered);
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this constraint is disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this constraint is disabled; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsDisabled { get; set; }

        /// <summary>
        /// Gets or sets the on delete cascade (only for FK).
        /// </summary>
        /// <value>The on delete cascade.</value>
        public int OnDeleteCascade { get; set; }

        /// <summary>
        /// Gets or sets the on update cascade (only for FK).
        /// </summary>
        /// <value>The on update cascade.</value>
        public int OnUpdateCascade { get; set; }

        /// <summary>
        /// Valor de la constraint (se usa para los Check Constraint).
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Indica si la constraint va a ser usada en replicacion.
        /// </summary>
        public Boolean NotForReplication { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [with no check].
        /// </summary>
        /// <value><c>true</c> if [with no check]; otherwise, <c>false</c>.</value>
        public Boolean WithNoCheck { get; set; }

        /// <summary>
        /// Indica el tipo de constraint (PrimaryKey, ForeignKey, Unique o Default).
        /// </summary>
        public ConstraintType Type { get; set; }

        /// <summary>
        /// ID de la tabla relacionada a la que hace referencia (solo aplica a FK)
        /// </summary>
        public int RelationalTableId { get; set; }

        /// <summary>
        /// Nombre de la tabla relacionada a la que hace referencia (solo aplica a FK)
        /// </summary>
        public string RelationalTableFullName { get; set; }

        /// <summary>
        /// Compara dos campos y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(Constraint origen, Constraint destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.NotForReplication != destino.NotForReplication) return false;
            if ((origen.RelationalTableFullName == null) && (destino.RelationalTableFullName != null)) return false;
            if (origen.RelationalTableFullName != null)
                if (!origen.RelationalTableFullName.Equals(destino.RelationalTableFullName, StringComparison.CurrentCultureIgnoreCase)) return false;
            if ((origen.Definition == null) && (destino.Definition != null)) return false;
            if (origen.Definition != null)
                if ((!origen.Definition.Equals(destino.Definition)) && (!origen.Definition.Equals("(" + destino.Definition + ")"))) return false;
            /*Solo si la constraint esta habilitada, se chequea el is_trusted*/
            if (!destino.IsDisabled)
                if (origen.WithNoCheck != destino.WithNoCheck) return false;
            if (origen.OnUpdateCascade != destino.OnUpdateCascade) return false;
            if (origen.OnDeleteCascade != destino.OnDeleteCascade) return false;
            if (!ConstraintColumns.Compare(origen.Columns, destino.Columns)) return false;
            //if ((origen.Index != null) && (destino.Index != null))
            //    return Index.Compare(origen.Index, destino.Index);
            return true;
        }
    }
}