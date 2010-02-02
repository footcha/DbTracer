using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class FullText : MsSqlSchemaBase
    {
        public FullText(ISchema parent)
            : base(parent, ObjectType1.FullText)
        {

        }

        public override string FullName
        {
            get { return "[" + Name + "]"; }
        }

        public string Path { get; set; }

        public Boolean IsDefault { get; set; }

        public Boolean IsAccentSensity { get; set; }

        public string FileGroupName { get; set; }

        /// <summary>
        /// Compara dos Synonyms y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public Boolean Compare(FullText destino)
        {
            var database = (Database)Parent;
            if (destino == null) throw new ArgumentNullException("destino");
            if (!IsAccentSensity.Equals(destino.IsAccentSensity)) return false;
            if (!IsDefault.Equals(destino.IsDefault)) return false;
            if ((!String.IsNullOrEmpty(FileGroupName)) && (!String.IsNullOrEmpty(destino.FileGroupName)))
                if (!FileGroupName.Equals(destino.FileGroupName)) return false;
            if (database.Options.Ignore.FilterFullTextPath)
                if ((!String.IsNullOrEmpty(Path)) && (!String.IsNullOrEmpty(destino.Path)))
                    return Path.Equals(destino.Path, StringComparison.CurrentCultureIgnoreCase);
            return true;
        }
    }
}