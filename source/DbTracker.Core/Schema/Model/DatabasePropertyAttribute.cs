using System;

namespace DbTracker.Core.Schema.Model
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DatabasePropertyAttribute : Attribute
    {
        public DatabasePropertyAttribute()
        {
            Depricated = false;
        }

        public string SqlName { get; set; }
        public bool Depricated { get; set; }
    }
}