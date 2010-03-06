using System;

namespace DbTracer.MsSql.Model
{
    /// <summary>
    /// Clase de constraints de Columnas (Default Constraint y Check Constraint)
    /// </summary>
    public class ColumnConstraint : MsSqlSchemaBase
    {
        public ColumnConstraint()
            : base(ObjectType1.Constraint)
        { }

        /// <summary>
        /// Clona el objeto ColumnConstraint en una nueva instancia.
        /// </summary>
        public new ColumnConstraint Clone()
        {
            return new ColumnConstraint
            {
                Name = Name,
                Type = Type,
                Definition = Definition,
                Status = Status,
                Disabled = Disabled,
                Owner = Owner
            };
        }

        /// <summary>
        /// Indica si la constraint esta deshabilitada.
        /// </summary>
        public Boolean Disabled { get; set; }

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
        /// Valor de la constraint.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Indica el tipo de constraint (Default o Check constraint).
        /// </summary>
        public Constraint.ConstraintType Type { get; set; }

        /// <summary>
        /// Compara dos campos y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(ColumnConstraint origen, ColumnConstraint destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.NotForReplication != destino.NotForReplication) return false;
            if (origen.Disabled != destino.Disabled) return false;
            if ((!origen.Definition.Equals(destino.Definition)) && (!origen.Definition.Equals("(" + destino.Definition + ")"))) return false;
            return true;
        }

        public Boolean CanCreate
        {
            get
            {
                return true;
                //var tableStatus = Parent.Parent.Status;
                //var columnStatus = Parent.Status;
                //return ((columnStatus != ObjectStatus.DropStatus) && (((tableStatus == ObjectStatus.AlterStatus) || (tableStatus == ObjectStatus.OriginalStatus) || (tableStatus == ObjectStatus.RebuildDependenciesStatus)) && (Status == ObjectStatus.OriginalStatus)));
            }
        }
    }
}