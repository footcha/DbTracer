using System;
using System.Text;

namespace DbTracer.Core.Schema.SqlGenerator
{
    public class Indent : IDisposable
    {
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                if (level == value) return;
                level = value;
                CreateCache();
            }
        }

        private string s;
        public string String
        {
            get { return s; }
            set
            {
                if (s == value) return;

                s = value ?? "";
                CreateCache();
            }
        }

        public Indent()
        {
            String = "\t";
            Level = 0;
        }

        private Indent parent = nullParent;

        private static readonly Indent nullParent = new Indent {String = ""};

        private string cache;

        private void CreateCache()
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= Level; ++i) sb.Append(String);
            cache = sb.ToString();
        }

        public Indent Create()
        {
            var newIndent = new Indent
            {
                String = String,
                Level = Level,
                parent = this
            };
            ++Level;

            return newIndent;
        }

        public override string ToString()
        {
            return cache;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            --parent.Level;
        }
    }
}