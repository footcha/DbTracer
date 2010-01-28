namespace DbTracker.MsSql.Model
{
    public class Rule : Code
    {
        public Rule()
            : base(ObjectType1.Rule, ScripActionType.AddRule, ScripActionType.DropRule)
        {
        }

        public new Rule Clone()
        {
            var item = new Rule
            {
                Id = Id,
                Name = Name,
                Owner = Owner,
                Text = Text,
            };
            return item;
        }
    }
}