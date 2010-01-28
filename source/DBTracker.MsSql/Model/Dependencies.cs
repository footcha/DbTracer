using System;
using System.Collections.Generic;

using System.Linq;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    internal class Dependencies : List<Dependence>
    {
        private Database database;

        public Database Database
        {
            get { return database; }
        }

        public void Add(Database databasePar, int tableId, int columnId, int ownerTableId, int typeId, ISchema constraint)
        {
            var depends = new Dependence
            {
                SubObjectId = columnId,
                ObjectId = tableId,
                OwnerTableId = ownerTableId,
                FullName = constraint.FullName,
                Type1 = (ObjectType1) constraint.ObjectType,
                DataTypeId = typeId
            };

            database = databasePar;
            Add(depends);
        }

        public void Add(Database databasePar, int objectId, ISchema objectSchema)
        {
            var depends = new Dependence
            {
                ObjectId = objectId,
                FullName = objectSchema.FullName,
                Type1 = (ObjectType1) objectSchema.ObjectType
            };
            database = databasePar;
            Add(depends);
        }

        //public List<ISchema> FindNotOwner(int tableId, ObjectType1 type)
        //{
        //    var cons = new List<ISchema>();
        //    ForEach(depens =>
        //                {
        //                    if (depens.Type1 == type)
        //                    {
        //                        var item = database.Find(depens.FullName);
        //                        if (depens.Type1 == ObjectType1.Constraint)
        //                        {
        //                            if ((depens.ObjectId == tableId) && (((Constraint)item).Type1 == Constraint.ConstraintType.ForeignKey))
        //                                cons.Add(item);
        //                        }
        //                        else
        //                            if (depens.ObjectId == tableId)
        //                                cons.Add(item);
        //                    }

        //                });
        //    return cons;
        //}


        /// <summary>
        /// Devuelve todos las constraints dependientes de una tabla.
        /// </summary>
        /*public void Set(int tableId, Constraint constraint)
        {
            this.ForEach(item =>
            {
                if (item.Type1 == Enums.ObjectType1.Constraint)
                    if ((item.ObjectId == tableId) && (item.ObjectSchema.Name.Equals(constraint.Name)))
                        item.ObjectSchema = constraint;
            });           
        }*/

        //public List<ISchema> Find(int tableId)
        //{
        //    return Find(tableId, 0, 0);
        //}

        //public int DependenciesCount(int objectId, ObjectType1 type)
        //{
        //    var depencyTracker = new Dictionary<int, bool>();
        //    return DependenciesCount(objectId, type, depencyTracker);
        //}

        //private int DependenciesCount(int tableId, ObjectType1 type, IDictionary<int, bool> depencyTracker)
        //{
        //    var count = 0;
        //    var putItem = false;
        //    var constraints = FindNotOwner(tableId, type);
        //    for (var index = 0; index < constraints.Count; index++)
        //    {
        //        var cons = constraints[index];
        //        if (cons.ObjectType1 == (Enum) type)
        //        {
        //            if (type == ObjectType1.Constraint)
        //            {
        //                var relationalTableId = ((Constraint)cons).RelationalTableId;
        //                putItem = (relationalTableId == tableId);
        //            }
        //        }
        //        if (!putItem) continue;
        //        if (depencyTracker.ContainsKey(tableId)) continue;
        //        depencyTracker.Add(tableId, true);
        //        count += 1 + DependenciesCount(cons.Parent.Id, type, depencyTracker);
        //    }
        //    return count;
        //}
        
        //public List<ISchema> Find(int tableId, int columnId, int dataTypeId)
        //{
        //    var real = new List<ISchema>();

        //    List<string> cons = (from depends in this
        //                 where (depends.Type1 == ObjectType1.Constraint || depends.Type1 == ObjectType1.Index) &&
        //                       ((depends.DataTypeId == dataTypeId || dataTypeId == 0) && (depends.SubObjectId == columnId || columnId == 0) && (depends.ObjectId == tableId))
        //                 select depends.FullName)
        //        .Concat(from depends in this
        //                where (depends.Type1 == ObjectType1.View || depends.Type1 == ObjectType1.Function) &&
        //                      (depends.ObjectId == tableId)
        //                select depends.FullName).ToList();

        //    cons.ForEach(item =>
        //                     {
        //                         var schema = database.Find(item);
        //                         if (schema != null) real.Add(schema);
        //                     }
        //        );
        //    return real;
        //}
    }
}