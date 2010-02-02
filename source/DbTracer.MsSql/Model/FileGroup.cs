using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class FileGroup : MsSqlSchemaBase
    {
        public FileGroup()
            : base(ObjectType1.FileGroup)
        {
            Files = new FileGroupFiles(this);
        }

        public override ISchema Clone()
        {
            var file = new FileGroup
            {
                IsDefaultFileGroup = IsDefaultFileGroup,
                IsReadOnly = IsReadOnly,
                Name = Name,
                Id = Id
            };
            file.Files = Files.Clone(file);
            file.IsFileStream = IsFileStream;
            return file;
        }

        public FileGroupFiles Files { get; set; }

        public Boolean IsFileStream { get; set; }

        public Boolean IsDefaultFileGroup { get; set; }

        public Boolean IsReadOnly { get; set; }

        public static Boolean Compare(FileGroup origen, FileGroup destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.IsReadOnly != destino.IsReadOnly) return false;
            if (origen.IsDefaultFileGroup != destino.IsDefaultFileGroup) return false;
            return origen.IsFileStream == destino.IsFileStream;
        }
    }
}