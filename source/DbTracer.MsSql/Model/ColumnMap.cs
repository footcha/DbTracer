using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class ColumnMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<Column>(j =>
            {
                j.Schema("sys");
                j.Table("columns");
                j.Id(e => e.Id, m => m.Column("column_id"));
                j.Property(t => t.Name, m => m.Column("name"));
                j.Property(t => t.MaxLength, m => m.Column("max_length"));
                j.Property(t => t.Precision, m => m.Column("precision"));
                j.Property(t => t.Scale, m => m.Column("scale"));
                j.Property(t => t.Collation, m => m.Column("collation_name"));
                j.Property(t => t.IsNullable, m => m.Column("is_nullable"));
                j.Property(t => t.IsAnsiPadded, m => m.Column("is_ansi_padded"));
                j.Property(t => t.IsRowGuidCol, m => m.Column("is_rowguidcol"));
                j.Property(t => t.IsIdentity, m => m.Column("is_identity"));
                j.Property(t => t.IsComputed, m => m.Column("is_computed"));
                j.Property(t => t.IsFileStream, m => m.Column("is_filestream"));
                j.Property(t => t.IsReplicated, m => m.Column("is_replicated"));
                j.Property(t => t.IsNonSqlSubscribed, m => m.Column("is_non_sql_subscribed"));
                j.Property(t => t.IsMergePublished, m => m.Column("is_merge_published"));
                j.Property(t => t.IsDtsReplicated, m => m.Column("is_dts_replicated"));
                j.Property(t => t.IsXmlDocument, m => m.Column("is_xml_document"));
                j.Property(t => t.XmlCollectionId, m => m.Column("xml_collection_id"));
                j.ManyToOne(o => o.ParentObject, c => c.Column("object_id"));
                j.ManyToOne(o => o.SystemType, c => c.Column("system_type_id"));
                j.ManyToOne(o => o.UserType, c => c.Column("user_type_id"));
                j.ManyToOne(o => o.Default, c => c.Column("default_object_id"));
                //j.ManyToOne(e => e.ParentColumn, m => m.Columns(
                //    c => c.Name("parent_object_id"),
                //    c => c.Name("parent_column_id")
                //    ));
            });

            orm.ExcludeProperty<Column>(c => c.Rule);
            orm.TablePerClass<Column>();
            orm.NaturalId<Column>(e => e.Id, e => e.ParentObject);
            entities.Add(typeof(Column));
        }

        //protected override string TableName
        //{
        //    get { return "sys.columns"; }
        //}

        //protected override void Configure()
        //{
        //    CompositeId()
        //        .KeyReference(obj => obj.ParentObject, "object_id")
        //        .KeyProperty(obj => obj.Id, "column_id");
        //    References(obj => obj.Rule)
        //        .Column("rule_object_id")
        //        .Not.LazyLoad()
        //        .NotFound.Ignore();
        //}
    }
}