using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DbTracker.Core.Reflection;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class DatabaseProperties : IEnumerable<KeyValuePair<PropertyInfo, DatabasePropertyAttribute>>
    {
        #region Properties

        public virtual string Database { get; set; }

        [DatabaseProperty]
        public virtual string Collation { get; set; }

        [DatabaseProperty]
        public virtual int ComparisonStyle { get; set; }

        [DatabaseProperty]
        public virtual bool IsAnsiNullDefault { get; set; }

        [DatabaseProperty]
        public virtual bool IsAnsiNullsEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsAnsiPaddingEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsAnsiWarningsEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsArithmeticAbortEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsAutoClose { get; set; }

        [DatabaseProperty]
        public virtual bool IsAutoCreateStatistics { get; set; }

        [DatabaseProperty]
        public virtual bool IsAutoShrink { get; set; }

        [DatabaseProperty]
        public virtual bool IsAutoUpdateStatistics { get; set; }

        [DatabaseProperty]
        public virtual bool IsCloseCursorsOnCommitEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsFulltextEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsInStandBy { get; set; }

        [DatabaseProperty]
        public virtual bool IsLocalCursorsDefault { get; set; }

        [DatabaseProperty]
        public virtual bool IsMergePublished { get; set; }

        [DatabaseProperty]
        public virtual bool IsNullConcat { get; set; }

        [DatabaseProperty]
        public virtual bool IsNumericRoundAbortEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsParameterizationForced { get; set; }

        [DatabaseProperty]
        public virtual bool IsQuotedIdentifiersEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsPublished { get; set; }

        [DatabaseProperty]
        public virtual bool IsRecursiveTriggersEnabled { get; set; }

        [DatabaseProperty]
        public virtual bool IsSubscribed { get; set; }

        [DatabaseProperty]
        public virtual bool IsSyncWithBackup { get; set; }

        [DatabaseProperty]
        public virtual bool IsTornPageDetectionEnabled { get; set; }

        [DatabaseProperty(SqlName = "LCID")]
        public virtual int Lcid { get; set; }

        [DatabaseProperty]
        public virtual string Recovery { get; set; }

        [DatabaseProperty(SqlName = "SQLSortOrder")]
        public virtual int SqlSortOrder { get; set; }

        [DatabaseProperty]
        public virtual string Status { get; set; }

        [DatabaseProperty]
        public virtual string Updateability { get; set; }

        [DatabaseProperty]
        public virtual string UserAccess { get; set; }

        [DatabaseProperty]
        public virtual int Version { get; set; }

        #endregion

        private static IDictionary<PropertyInfo, DatabasePropertyAttribute> GetProperties()
        {
            return Search.GetPropertiesWithAttribute<DatabasePropertyAttribute>(typeof(DatabaseProperties));
        }

        public virtual IEnumerator<KeyValuePair<PropertyInfo, DatabasePropertyAttribute>> GetEnumerator()
        {
            return GetProperties().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}