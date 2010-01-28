namespace DbTracker.MsSql.Model
{
    public class ColumnMap : SqlClassMap<Column>
    {
        protected override string TableName
        {
            get { return "sys.columns"; }
        }

        protected override void Configure()
        {
            ReadOnly();
            Table(TableName);
            CompositeId()
                .KeyProperty(obj => obj.Id, "object_id")
                .KeyProperty(obj => obj.ColumnId, "column_id");
            Map(obj => obj.Name, "name");
            References(o => o.SystemType)
                .Class<Type>()
                .Column("system_type_id")
                .Not.LazyLoad();
            References(o => o.UserType)
                .Class<Type>()
                .Column("user_type_id")
                .Not.LazyLoad();
            //Map(o => o.Schema, "schema_id");
            Map(o => o.MaxLength, "max_length");
            Map(o => o.Precision, "precision");
            Map(o => o.Scale, "scale");
            Map(o => o.Collation, "collation_name");
            Map(o => o.IsNullable, "is_nullable");
            Map(o => o.IsAnsiPadded, "is_ansi_padded");
            Map(o => o.IsRowGuidCol, "is_rowguidcol");
            Map(o => o.IsIdentity, "is_identity");
            Map(o => o.IsComputed, "is_computed");
            Map(o => o.IsFileStream, "is_filestream");
            Map(o => o.IsReplicated, "is_replicated");
            Map(o => o.IsNonSqlSubscribed, "is_non_sql_subscribed");
            Map(o => o.IsMergePublished, "is_merge_published");
            Map(o => o.IsDtsReplicated, "is_dts_replicated");
            Map(o => o.IsXmlDocument, "is_xml_document");
            Map(o => o.XmlCollectionId, "xml_collection_id");
            Map(o => o.DefaultObjectId, "default_object_id");
            Map(o => o.RuleObjectId, "rule_object_id");
        }
    }
}