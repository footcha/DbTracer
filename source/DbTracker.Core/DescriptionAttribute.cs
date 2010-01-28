using System;

namespace DbTracker.Core
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
