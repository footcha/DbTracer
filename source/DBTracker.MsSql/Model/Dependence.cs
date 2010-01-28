namespace DbTracker.MsSql.Model
{
    internal class Dependence
    {
        private int objectId;
        private int subObjectId;
        private int ownerTableId;
        private string fullName;
        private int typeId;
        private ObjectType1 type1;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int DataTypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        public ObjectType1 Type1
        {
            get { return type1; }
            set { type1 = value; }
        }

        public int SubObjectId
        {
            get { return subObjectId; }
            set { subObjectId = value; }
        }

        /// <summary>
        /// ID de la tabla a la que hace referencia la constraint.
        /// </summary>
        public int ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }

        /// <summary>
        /// ID de la tabla a la que pertenece la constraint.
        /// </summary>
        public int OwnerTableId
        {
            get { return ownerTableId; }
            set { ownerTableId = value; }
        }
    }
}