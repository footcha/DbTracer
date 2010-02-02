namespace DbTracer.MsSql.Options
{
    public class SqlOptionDefault
    {
        public SqlOptionDefault()
        {
            DefaultIntegerValue = "0";
            DefaultRealValue = "0.0";
            DefaultTextValue = "''";
            DefaultDateValue = "getdate()";
            DefaultVariantValue = "''";
            DefaultNTextValue = "N''";
            DefaultBlobValue = "0x";
            DefaultUniqueValue = "NEWID()";
            DefaultTime = "00:00:00";
            DefaultXml = "";
            UseDefaultValueIfExists = true;
        }

        public string DefaultXml { get; set; }

        public string DefaultTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use default value if exists.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if use default value if exists; otherwise, <c>false</c>.
        /// </value>
        public bool UseDefaultValueIfExists { get; set; }

        /// <summary>
        /// Gets or sets the default unique (uniqueidentifier) values.
        /// </summary>
        /// <value>The default unique value.</value>
        public string DefaultUniqueValue { get; set; }

        /// <summary>
        /// Gets or sets the default BLOB (varbinary,image, bynary) values.
        /// </summary>
        /// <value>The default BLOB value.</value>
        public string DefaultBlobValue { get; set; }

        /// <summary>
        /// Gets or sets the default Unicode text (nvarchar,nchar,ntext) values.
        /// </summary>
        /// <value>The default N text value.</value>
        public string DefaultNTextValue { get; set; }

        /// <summary>
        /// Gets or sets the default sql_variant values.
        /// </summary>
        /// <value>The default variant value.</value>
        public string DefaultVariantValue { get; set; }

        /// <summary>
        /// Gets or sets the default date (datetime,smalldatetime) values.
        /// </summary>
        /// <value>The default date value.</value>
        public string DefaultDateValue { get; set; }

        /// <summary>
        /// Gets or sets the default text (varchar,char,text) values.
        /// </summary>
        /// <value>The default text value.</value>
        public string DefaultTextValue { get; set; }

        /// <summary>
        /// Gets or sets the default real (decimal,money,numeric,float) value.
        /// </summary>
        /// <value>The default real value.</value>
        public string DefaultRealValue { get; set; }

        /// <summary>
        /// Gets or sets the default integer (int, smallint, bigint, tinyint, bit) value.
        /// </summary>
        /// <value>The default integer value.</value>
        public string DefaultIntegerValue { get; set; }
    }
}