using System.Text;
using FluentNHibernate.Mapping;
using NHibernate;

namespace DbTracker.MsSql.Model
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

            foreach (var item in new DatabaseProperties())
            {
                var property = item.Key;
                var sqlName = item.Value.SqlName ?? property.Name; 
                Map(property, sqlName);
            }
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