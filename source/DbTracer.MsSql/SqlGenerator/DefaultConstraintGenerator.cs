using System;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class DefaultConstraintGenerator : CodeGeneratorBase<DefaultConstraint>
    {
        public DefaultConstraintGenerator(DefaultConstraint sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { throw new NotImplementedException(); }
        }
    }
}