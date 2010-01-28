using System;
using System.Collections.Generic;

namespace DbTracker.MsSql.Model
{
    public class SearchSchemaBase
    {
        private readonly Dictionary<String, ObjectType1> objectTypes;
        private readonly Dictionary<String, String> objectParent;
        private readonly Dictionary<Int32, String> objectId;

        public SearchSchemaBase()
        {
            objectTypes = new Dictionary<string, ObjectType1>();
            objectParent = new Dictionary<string, string>();
            objectId = new Dictionary<Int32, string>();
        }

        public void Add(SchemaBase item)
        {
            if (objectTypes.ContainsKey(item.FullName.ToUpper()))
                objectTypes.Remove(item.FullName.ToUpper());
            objectTypes.Add(item.FullName.ToUpper(), item.ObjectType1);
            if ((((item.ObjectType1 != ObjectType1.Constraint) && (item.ObjectType1 != ObjectType1.Index)) &&
                 (item.ObjectType1 != ObjectType1.Trigger)) && (item.ObjectType1 != ObjectType1.ClrTrigger)) return;
            if (objectParent.ContainsKey(item.FullName.ToUpper()))
                objectParent.Remove(item.FullName.ToUpper());
            objectParent.Add(item.FullName.ToUpper(), item.Parent.FullName);

            if (objectId.ContainsKey(item.Id))
                objectId.Remove(item.Id);
            objectId.Add(item.Id, item.FullName);
        }

        public ObjectType1 GetType(string fullName)
        {
            return objectTypes[fullName.ToUpper()];
        }

        public string GetParentName(string fullName)
        {
            return objectParent[fullName.ToUpper()];
        }

        public string GetFullName(int id)
        {
            return objectId[id];
        }
    }
}