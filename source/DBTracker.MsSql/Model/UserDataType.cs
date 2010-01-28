using System;
using System.Collections.Generic;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class UserDataType : MsSqlSchemaBase
    {
        public UserDataType()
            : base(ObjectType1.UserDataType)
        {
            Default = new Default();
            Rule = new Rule();
            Dependencys = new List<ObjectDependency>();
        }

        public List<ObjectDependency> Dependencys { get; private set; }

        public Rule Rule { get; private set; }

        public Default Default { get; private set; }

        public string AssemblyName { get; set; }

        public Boolean IsAssembly { get; set; }

        public string AssemblyClass { get; set; }

        public int AssemblyId { get; set; }

        /// <summary>
        /// Cantidad de digitos que permite el campo (solo para campos Numeric).
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Cantidad de decimales que permite el campo (solo para campos Numeric).
        /// </summary>
        public int Precision { get; set; }

        public Boolean AllowNull { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }

        public String AssemblyFullName
        {
            get
            {
                if (IsAssembly)
                    return AssemblyName + "." + AssemblyClass;
                return "";
            }
        }

        /// <summary>
        /// Clona el objeto Column en una nueva instancia.
        /// </summary>
        public override ISchema Clone()
        {
            return new UserDataType
            {
                Name = Name,
                Id = Id,
                Owner = Owner,
                AllowNull = AllowNull,
                Precision = Precision,
                Scale = Scale,
                Size = Size,
                Type = Type,
                Default = Default.Clone(),
                Rule = Rule.Clone(),
                Dependencys = Dependencys,
                IsAssembly = IsAssembly,
                AssemblyClass = AssemblyClass,
                AssemblyId = AssemblyId,
                AssemblyName = AssemblyName
            };
        }

        public static Boolean CompareRule(UserDataType origen, UserDataType destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if ((origen.Rule.Name != null) && (destino.Rule.Name == null)) return false;
            if ((origen.Rule.Name == null) && (destino.Rule.Name != null)) return false;
            if (origen.Rule.Name != null)
                if (!origen.Rule.Name.Equals(destino.Rule.Name)) return false;
            return true;
        }

        public static Boolean CompareDefault(UserDataType origen, UserDataType destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if ((origen.Default.Name != null) && (destino.Default.Name == null)) return false;
            if ((origen.Default.Name == null) && (destino.Default.Name != null)) return false;
            if (origen.Default.Name != null)
                if (!origen.Default.Name.Equals(destino.Default.Name)) return false;
            return true;
        }

        public bool Compare(UserDataType obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (Scale != obj.Scale) return false;
            if (Precision != obj.Precision) return false;
            if (AllowNull != obj.AllowNull) return false;
            if (Size != obj.Size) return false;
            if (!Type.Equals(obj.Type)) return false;
            if (IsAssembly != obj.IsAssembly) return false;
            if (!AssemblyClass.Equals(obj.AssemblyClass)) return false;
            if (!AssemblyName.Equals(obj.AssemblyName)) return false;
            return CompareDefault(this, obj) && CompareRule(this, obj);
        }
    }
}