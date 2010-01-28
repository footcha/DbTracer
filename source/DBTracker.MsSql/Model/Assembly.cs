using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class Assembly : Code
    {
        public Assembly()
            : base(ObjectType1.Assembly, ScripActionType.AddAssembly, ScripActionType.DropAssembly)
        {
            Files = new SchemaList<AssemblyFile, Assembly>();
        }

        public override ISchema Clone()
        {
            var item = new Assembly
            {
                Id = Id,
                Name = Name,
                Owner = Owner,
                Visible = Visible,
                Text = Text,
                PermissionSet = PermissionSet,
                ClrName = ClrName,
                Files = Files
            };
            DependenciesOut.ForEach(dep => item.DependenciesOut.Add(dep));
            ExtendedProperties.ForEach(ep => item.ExtendedProperties.Add(ep));
            return item;
        }

        public SchemaList<AssemblyFile, Assembly> Files { get; set; }

        public override string FullName
        {
            get { return "[" + Name + "]"; }
        }

        public string ClrName { get; set; }

        public bool Visible { get; set; }

        public string PermissionSet { get; set; }

        public bool Compare(Assembly obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!ClrName.Equals(obj.ClrName)) return false;
            if (!PermissionSet.Equals(obj.PermissionSet)) return false;
            if (!Owner.Equals(obj.Owner)) return false;
            if (!Text.Equals(obj.Text)) return false;
            if (Files.Count != obj.Files.Count) return false;
            for (var j = 0; j < Files.Count; j++)
                if (!Files[j].Content.Equals(obj.Files[j].Content)) return false;
            return true;
        }

        public override Boolean IsCodeType
        {
            get { return true; }
        }
    }
}