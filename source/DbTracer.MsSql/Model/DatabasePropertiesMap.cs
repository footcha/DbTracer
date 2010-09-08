using System.Text;
using FluentNHibernate.Mapping;
using NHibernate;

namespace DbTracer.MsSql.Model
{
    public class DatabasePropertiesMap : ClassMap<DatabaseProperties>
    {
        public DatabasePropertiesMap()
        {
            Configure();
        }

        private void Configure()
        {
            ReadOnly();
            Id(obj => obj.Database);

            Map(p => p.Collation);
            Map(p => p.ComparisonStyle);
            Map(p => p.Database);
            Map(p => p.IsAnsiNullDefault);
            Map(p => p.IsAnsiNullsEnabled);
            Map(p => p.IsAnsiPaddingEnabled);
            Map(p => p.IsAnsiWarningsEnabled);
            Map(p => p.IsArithmeticAbortEnabled);
            Map(p => p.IsAutoClose);
            Map(p => p.IsAutoCreateStatistics);
            Map(p => p.IsAutoShrink);
            Map(p => p.IsAutoUpdateStatistics);
            Map(p => p.IsCloseCursorsOnCommitEnabled);
            Map(p => p.IsFulltextEnabled);
            Map(p => p.IsInStandBy);
            Map(p => p.IsLocalCursorsDefault);
            Map(p => p.IsMergePublished);
            Map(p => p.IsNullConcat);
            Map(p => p.IsNumericRoundAbortEnabled);
            Map(p => p.IsParameterizationForced);
            Map(p => p.IsPublished);
            Map(p => p.IsQuotedIdentifiersEnabled);
            Map(p => p.IsRecursiveTriggersEnabled);
            Map(p => p.IsSubscribed);
            Map(p => p.IsSyncWithBackup);
            Map(p => p.IsTornPageDetectionEnabled);
            Map(p => p.Lcid);
            Map(p => p.Recovery);
            Map(p => p.SqlSortOrder);
            Map(p => p.Status);
            Map(p => p.Updateability);
            Map(p => p.UserAccess);
            Map(p => p.Version);
        }

        public static ISQLQuery CreateQuery(ISession session)
        {
            var databaseName = session.Connection.Database;
            var sb = new StringBuilder();
            foreach (var property in new DatabaseProperties())
            {
                var propertyName = property.Key.Name;
                var sqlName = property.Value.SqlName ?? propertyName;
                sb.AppendFormat("DATABASEPROPERTYEX('{0}', '{1}') AS '{2}', ",
                    databaseName, sqlName, propertyName);
            }
            sb.Remove(sb.Length - 2, 2);
            var sql = string.Format("SELECT '{0}' AS 'database', {1}", databaseName, sb);
            return session.CreateSQLQuery(sql)
                .AddEntity(typeof(DatabaseProperties));
        }
    }
}