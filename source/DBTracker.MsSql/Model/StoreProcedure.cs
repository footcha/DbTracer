using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class StoreProcedure : Code
    {
        public StoreProcedure()
            : base(ObjectType1.StoreProcedure, ScripActionType.AddStoreProcedure, ScripActionType.DropStoreProcedure)
        {

        }

        /// <summary>
        /// Clona el objeto en una nueva instancia.
        /// </summary>
        public override ISchema Clone()
        {
            return new StoreProcedure
            {
                Text = Text,
                Status = Status,
                Name = Name,
                Id = Id,
                Owner = Owner
            };
        }

        public override Boolean IsCodeType
        {
            get { return true; }
        }
    }
}