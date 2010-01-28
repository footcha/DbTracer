using System;
using System.Collections.Generic;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class FullTextIndex : MsSqlSchemaBase
    {
        public FullTextIndex()
            : base(ObjectType1.FullTextIndex)
        {
            Columns = new List<FullTextIndexColumn>();
        }

        public override ISchema Clone()
        {
            var clone = new FullTextIndex
            {
                ChangeTrackingState = ChangeTrackingState,
                FullText = FullText,
                Name = Name,
                FileGroup = FileGroup,
                Id = Id,
                Index = Index,
                IsDisabled = IsDisabled,
                Status = Status,
                Owner = Owner,
                Columns = Columns
            };
            ExtendedProperties.ForEach(item => clone.ExtendedProperties.Add(item));
            return clone;
        }

        public string FileGroup { get; set; }

        public Boolean IsDisabled { get; set; }

        public string Index { get; set; }

        public string FullText { get; set; }

        public string ChangeTrackingState { get; set; }

        public override string FullName
        {
            get
            {
                return Name;
            }
        }

        public List<FullTextIndexColumn> Columns { get; set; }

        public Boolean Compare(FullTextIndex destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (!ChangeTrackingState.Equals(destino.ChangeTrackingState)) return false;
            if (!FullText.Equals(destino.FullText)) return false;
            if (!Index.Equals(destino.Index)) return false;
            if (IsDisabled != destino.IsDisabled) return false;
            if (Columns.Count != destino.Columns.Count) return false;
            if (Columns.Exists(item => !destino.Columns.Exists(item2 => item2.ColumnName.Equals(item.ColumnName)))) return false;
            return !destino.Columns.Exists(item => !Columns.Exists(item2 => item2.ColumnName.Equals(item.ColumnName)));
        }
    }
}