using System;
using System.Text;

namespace DbTracer.Core.Schema.SqlGenerator
{
    public class SqlBuilder
    {
        private readonly StringBuilder buffer;

        public Indent Indent { get; private set; }

        public string NewLine { get; set; }

        public SqlBuilder()
        {
            buffer = new StringBuilder();
            Indent = new Indent();
            NewLine = Environment.NewLine;
        }

        public SqlBuilder AppendFormat(string format, params string[] texts)
        {
            AppendIndent();
            return AppendFormatRaw(format, texts);
        }

        public SqlBuilder AppendFormatLine(string format, params string[] texts)
        {
            return AppendFormat(format, texts).AppendLine();
        }

        public SqlBuilder Append(string text)
        {
            AppendIndent();
            return AppendRaw(text);
        }

        public SqlBuilder AppendLine()
        {
            return AppendRaw(NewLine);
        }

        private void AppendIndent()
        {
            AppendRaw(Indent.ToString());
        }

        private SqlBuilder AppendRaw(string text)
        {
            buffer.Append(text);

            return this;
        }

        private SqlBuilder AppendFormatRaw(string format, params string[] texts)
        {
            buffer.AppendFormat(format, texts);

            return this;
        }


        public SqlBuilder AppendLine(string text)
        {
            return Append(text).AppendLine();
        }

        public override string ToString()
        {
            return buffer.ToString();
        }
    }
}