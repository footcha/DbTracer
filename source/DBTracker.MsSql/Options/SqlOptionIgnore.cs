using System;

namespace DbTracker.MsSql.Options
{
    public class SqlOptionIgnore
    {
        public SqlOptionIgnore(Boolean defaultValue)
        {
            FilterPartitionFunction = true;
            FilterPartitionScheme = true;
            FilterIndexFilter = true;
            FilterIndex = true;
            FilterConstraintPk = true;
            FilterConstraintFk = true;
            FilterConstraintUk = true;
            FilterConstraintCheck = true;
            FilterIndexFillFactor = true;
            FilterIndexIncludeColumns = true;
            FilterColumnIdentity = true;
            FilterColumnOrder = true;
            FilterIndexRowLock = true;
            FilterColumnCollation = true;
            FilterNotForReplication = true;
            FilterFullText = true;
            FilterTableChangeTracking = true;
            FilterTableLockEscalation = true;
            FilterUsers = true;
            FilterRoles = true;
            FilterClrFunction = true;
            FilterClrTrigger = true;
            FilterClrUdt = true;
            FilterClrStoreProcedure = true;
            FilterConstraint = defaultValue;
            FilterFunction = defaultValue;
            FilterStoreProcedure = defaultValue;
            FilterView = defaultValue;
            FilterTable = defaultValue;
            FilterTableOption = defaultValue;
            FilterUserDataType = defaultValue;
            FilterTrigger = defaultValue;
            FilterSchema = defaultValue;
            FilterXmlSchema = defaultValue;
            FilterTableFileGroup = defaultValue;
            FilterExtendedPropertys = defaultValue;
            FilterDdlTriggers = defaultValue;
            FilterSynonyms = defaultValue;
            FilterRules = defaultValue;
            FilterAssemblies = defaultValue;
        }

        public bool FilterTableChangeTracking { get; set; }

        public bool FilterTableLockEscalation { get; set; }

        public Boolean FilterFullTextPath { get; set; }

        public bool FilterFullText { get; set; }

        public bool FilterClrStoreProcedure { get; set; }

        public bool FilterClrUdt { get; set; }

        public bool FilterClrTrigger { get; set; }

        public bool FilterClrFunction { get; set; }

        public bool FilterRoles { get; set; }

        public bool FilterUsers { get; set; }

        public bool FilterNotForReplication { get; set; }

        public bool FilterColumnCollation { get; set; }

        public bool FilterColumnIdentity { get; set; }

        public bool FilterColumnOrder { get; set; }

        public bool FilterIndexRowLock { get; set; }

        public bool FilterIndexIncludeColumns { get; set; }

        public bool FilterIndexFillFactor { get; set; }

        public bool FilterAssemblies { get; set; }

        public bool FilterRules { get; set; }

        public bool FilterSynonyms { get; set; }

        public bool FilterDdlTriggers { get; set; }

        public bool FilterExtendedPropertys { get; set; }

        public bool FilterTableFileGroup { get; set; }

        public bool FilterFunction { get; set; }

        public bool FilterStoreProcedure { get; set; }

        public bool FilterView { get; set; }

        public bool FilterTable { get; set; }

        public bool FilterTableOption { get; set; }

        public bool FilterUserDataType { get; set; }

        public bool FilterTrigger { get; set; }

        public bool FilterXmlSchema { get; set; }

        public bool FilterSchema { get; set; }

        public bool FilterConstraint { get; set; }

        public bool FilterConstraintCheck { get; set; }

        public bool FilterConstraintUk { get; set; }

        public bool FilterConstraintFk { get; set; }

        public bool FilterConstraintPk { get; set; }

        public bool FilterIndex { get; set; }

        public bool FilterIndexFilter { get; set; }

        public bool FilterPartitionScheme { get; set; }

        public bool FilterPartitionFunction { get; set; }
    }
}