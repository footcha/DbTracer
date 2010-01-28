using System.Collections;
using System.Collections.Generic;

namespace DbTracker.MsSql.Model
{
    public class View : ICode
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }

        public virtual string Definition { get; set; }

        public virtual IDictionary<int, Trigger> Triggers { get; set; }
    }
    //public class View : Code
    //{
    //    public View()
    //        : base(ObjectType1.View, ScripActionType.AddView, ScripActionType.DropView)
    //    {
    //        Indexes = new SchemaList<Index, View>(this);
    //        //Triggers = new SchemaList<Trigger, View>(this);
    //        ClrTriggers = new SchemaList<ClrTrigger, View>(this);
    //    }

    //    /// <summary>
    //    /// Clona el objeto en una nueva instancia.
    //    /// </summary>
    //    public override ISchema Clone()
    //    {
    //        var item = new View
    //        {
    //            Text = Text,
    //            Status = Status,
    //            Name = Name,
    //            Id = Id,
    //            Owner = Owner,
    //            IsSchemaBinding = IsSchemaBinding,
    //            DependenciesIn = DependenciesIn,
    //            DependenciesOut = DependenciesOut
    //        };
    //        item.Indexes = Indexes.Clone();
    //        //item.Triggers = Triggers.Clone();
    //        return item;
    //    }

    //    [Description("CLR Triggers")]
    //    public SchemaList<ClrTrigger, View> ClrTriggers { get; set; }

    //    //public SchemaList<Trigger, View> Triggers { get; set; }

    //    public SchemaList<Index, View> Indexes { get; set; }

    //    public override Boolean IsCodeType
    //    {
    //        get { return true; }
    //    }
    //}
}